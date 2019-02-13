using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace HttpQuest
{
    public static class HttpContextExtensions
    {
        private static readonly JsonSerializer Serializer = new JsonSerializer();

        public static string GetAbsoluteUrl(this HttpContext context, string relativeUrl)
        {
            var baseUrl = context.Request.Scheme + "://" + context.Request.Host + context.Request.PathBase;

            if (string.IsNullOrEmpty(relativeUrl) || relativeUrl == "/")
            {
                return baseUrl;
            }

            if (relativeUrl.StartsWith('/'))
            {
                return baseUrl + relativeUrl;
            }

            return baseUrl + "/" + relativeUrl;
        }

        public static Task WriteTextAsync(this HttpResponse response, string text)
        {
            response.ContentType = "text/plain";
            return response.WriteAsync(text);
        }

        public static Task WriteHtmlAsync(this HttpResponse response, string html)
        {
            response.ContentType = "text/html";
            return response.WriteAsync(html);
        }

        public static async Task WriteJsonAsync<T>(this HttpResponse response, T value)
        {
            response.ContentType = "application/json";

            using (var textWriter = new StringWriter())
            {
                Serializer.Serialize(textWriter, value, typeof(T));
                await response.WriteAsync(textWriter.GetStringBuilder().ToString());
            }
        }

        public static async Task<T> ReadJsonAsync<T>(this HttpRequest request)
        {
            using (var streamReader = new StreamReader(request.Body))
            {
                var json = await streamReader.ReadToEndAsync();

                using (var stringReader = new StringReader(json))
                {
                    return (T)Serializer.Deserialize(stringReader, typeof(T));
                }
            }
        }

        public static Task WriteHtmlResourceAsync(this HttpResponse response, string resourceName, object data = null)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (var stream = assembly.GetManifestResourceStream($"HttpQuest.{resourceName}"))
            using (var reader = new StreamReader(stream))
            {
                var html = reader.ReadToEnd();

                if (data != null)
                {
                    foreach (var property in data.GetType().GetProperties())
                    {
                        html = html.Replace("{" + property.Name + "}", property.GetValue(data)?.ToString());
                    }
                }

                return response.WriteHtmlAsync(html);
            }
        }
    }
}