namespace Converters
{
    using System;
    using View = Client.Models.Notes;
    using Model = Models.Notes;

    public static class NotePatchInfoConverter
    {
        public static Model.NotePatchInfo Convert(View.NotePatchInfo viewNotePatchInfo)
        {
            if (viewNotePatchInfo == null)
            {
                throw new ArgumentNullException(nameof(viewNotePatchInfo));
            }

            var modelNotePatchInfo = new Model.NotePatchInfo
            {
                Title = viewNotePatchInfo.Title,
                Text = viewNotePatchInfo.Text,
            };

            return modelNotePatchInfo;
        }
    }
}
