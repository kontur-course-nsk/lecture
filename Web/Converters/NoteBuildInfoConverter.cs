namespace Converters
{
    using System;
    using View = Client.Models.Notes;
    using Model = Models.Notes;

    public static class NoteBuildInfoConverter
    {
        public static Model.NoteBuildInfo Convert(View.NoteBuildInfo viewNoteBuildInfo)
        {
            if (viewNoteBuildInfo == null)
            {
                throw new ArgumentNullException(nameof(viewNoteBuildInfo));
            }

            var modelNoteBuildInfo = new Model.NoteBuildInfo
            {
                Title = viewNoteBuildInfo.Title,
                Text = viewNoteBuildInfo.Text,
            };

            return modelNoteBuildInfo;
        }
    }
}
