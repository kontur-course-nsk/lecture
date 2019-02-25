namespace Converters
{
    using System;
    using View = Client.Models.Notes;
    using Model = Models.Notes;

    public static class NoteConverter
    {
        public static View.Note Convert(Model.Note modelNote)
        {
            if (modelNote == null)
            {
                throw new ArgumentNullException(nameof(modelNote));
            }

            var viewNote = new View.Note
            {
                Id = modelNote.Id.ToString(),
                Text = modelNote.Text,
                Title = modelNote.Title,
                Favorite = modelNote.Favorite,
                CreatedAt = modelNote.CreatedAt,
                UpdatedAt = modelNote.UpdatedAt,
            };

            return viewNote;
        }
    }
}
