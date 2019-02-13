using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace HttpQuest
{
    public class Game
    {
        private static readonly PathString StageStartPath = "/knock-knock";
        private static readonly PathString StageShowFormPath =  "/0cbad8c4.html";
        private static readonly PathString StageCheckFormPath = "/afe0ef50";
        private static readonly PathString StageLastDoorPath = "/last-door";
        private static readonly PathString StageExitPath = "/bye-bye";

        private static readonly string[] SupportedMediaTypes = new string[] { "text/*", "application/*", "text/html", "application/html" };

        private readonly ConcurrentDictionary<string, GameDoor> doors;
        private readonly ConcurrentDictionary<string, GameCaptcha> captches;
        private int counter = 1;

        public Game()
        {
            this.doors = new ConcurrentDictionary<string, GameDoor>();
            this.captches = new ConcurrentDictionary<string, GameCaptcha>();
        }

        public async Task ProcessAsync(HttpContext context)
        {
            var path = context.Request.Path;

            if (path == "/")
            {
                await this.WelcomeAsync(context);
            }
            else if (path == StageStartPath)
            {
                await this.AuthorizeAsync(context, this.StageStartAsync);
            }
            else if (path == StageShowFormPath)
            {
                await this.AuthorizeAsync(context, this.StageShowFormAsync);
            }
            else if (path == StageCheckFormPath)
            {
                await this.AuthorizeAsync(context, this.StageCheckFormAsync);
            }
            else if (path == StageLastDoorPath)
            {
                await this.AuthorizeAsync(context, this.StageLastDoorAsync);
            }
            else if (path == StageExitPath)
            {
                await this.AuthorizeAsync(context, this.StageExitAsync);
            }
            else
            {
                context.Response.StatusCode = Status404NotFound;
            }
        }

        private async Task WelcomeAsync(HttpContext context)
        {
            var request = context.Request;

            if (request.Method == HttpMethods.Options)
            {
                context.Response.StatusCode = 200;
                context.Response.Headers.Add("Allow", "OPTIONS, HELLO");
            }
            else if (string.Equals(request.Method, "HELLO", StringComparison.OrdinalIgnoreCase))
            {
                context.Response.StatusCode = 200;
                context.Response.Headers.Add("Location", context.GetAbsoluteUrl(StageStartPath));
                await context.Response.WriteAsync("Welcome!");
            }
            else
            {
                context.Response.StatusCode = 405;
            }
        }

        private Task StageStartAsync(HttpContext context)
        {
            return context.Response.WriteTextAsync($"Go deeper.. {StageShowFormPath}");
        } 

        private async Task StageShowFormAsync(HttpContext context)
        {
            var request = context.Request;

            if (request.Method != HttpMethods.Get)
            {
                context.Response.StatusCode = 405;
                return;
            }

            if (context.Request.Headers.TryGetValue("Accept", out var values))
            {
                if (!values.Any(x => SupportedMediaTypes.Contains(x)))
                {
                    context.Response.StatusCode = 406;
                    return;
                }
            }

            var key = this.GenerateKey();
            var captcha = GameCaptcha.Generate(3, TimeSpan.FromSeconds(60));

            this.captches.TryAdd(key, captcha);

            await context.Response.WriteHtmlResourceAsync("form.html", new
            {
                question = captcha.Question,
                action = StageCheckFormPath + "?key=" + key
            });
        }

        private async Task StageCheckFormAsync(HttpContext context)
        {
            var request = context.Request;
            var response = context.Response;

            if (request.Method != HttpMethods.Get)
            {
                response.StatusCode = 405;
                return;
            }

            var key = request.Query["key"];
            var answer = request.Query["answer"];

            if (string.IsNullOrEmpty(key) || 
                string.IsNullOrEmpty(answer) || 
                !this.captches.TryGetValue(key, out var captcha))
            {
                response.StatusCode = 400;
                return;
            }

            var expired = captcha.IsExpired();
            var html = string.Empty;

            if (captcha.IsExpired())
            {
                await response.WriteHtmlResourceAsync("form-expired.html", new { url = StageShowFormPath });
            }
            else
            {
                if (answer != captcha.Answer)
                {
                    response.StatusCode = Status400BadRequest;
                    return;
                }

                this.doors.TryAdd(key, new GameDoor());

                var url = StageLastDoorPath.Add(QueryString.Create("key", key));
                await response.WriteHtmlResourceAsync("form-success.html", new { url });
            }
        }

        private async Task StageLastDoorAsync(HttpContext context)
        {
            var request = context.Request;
            var response = context.Response;

            if (request.Method == "OPTIONS")
            {
                response.StatusCode = Status200OK;
                response.Headers.Add("Allow", "OPTIONS, GET, PUT");
                return;
            }

            var key = request.Query["key"];

            if (string.IsNullOrEmpty(key) || !this.doors.TryGetValue(key, out var door))
            {
                response.StatusCode = Status400BadRequest;
                return;
            }

            if (request.Method == "PUT")
            {
                GameDoor newDoor;

                try
                {
                    newDoor = await request.ReadJsonAsync<GameDoor>();
                }
                catch (Exception)
                {
                    response.StatusCode = Status400BadRequest;
                    return;
                }

                if (newDoor.Opened)
                {
                    door.Opened = true;
                    door.ExitLink = context.GetAbsoluteUrl(StageExitPath);
                }
            }

            await response.WriteJsonAsync(door);
        }

        private Task StageExitAsync(HttpContext context)
        {
            return context.Response.WriteHtmlResourceAsync("bye-bye.html");
        }

        private async Task AuthorizeAsync(HttpContext context, Func<HttpContext, Task> handler)
        {
            if (context.Request.Cookies.TryGetValue("Authorized", out var result))
            {
                if (result.Equals("true", StringComparison.OrdinalIgnoreCase))
                {
                    await handler(context);
                    return;
                }
            }

            context.Response.StatusCode = 401;
            context.Response.Headers.Add("WWW-Authenticate", "X-COOKIE-BASED");
            context.Response.Cookies.Append("Authorized", "false");
        }

        private string GenerateKey()
        {
            var counter = Interlocked.Increment(ref this.counter);
            return Guid.NewGuid().ToString().Substring(3) + counter.ToString();
        }
    }
}