namespace Converters
{
    using System;
    using View = Client.Models.Notes;
    using Model = Models.Notes;

    public static class NoteCreationInfoConverter
    {
        public static View.NoteCreationInfo Convert(Model.NoteCreationInfo modelNoteCreationInfo)
        {
            if (modelNoteCreationInfo == null)
            {
                throw new ArgumentNullException(nameof(modelNoteCreationInfo));
            }

            var viewNoteCreationInfo = new View.NoteCreationInfo
            {
                Id = modelNoteCreationInfo.Id.ToString(),
                CreatedAt = modelNoteCreationInfo.CreatedAt,
            };

            return viewNoteCreationInfo;
        }
    }
}
