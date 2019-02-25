namespace Converters
{
    using System;
    using View = Client.Models.Notes;
    using Model = Models.Notes;

    public static class NoteSearchQueryConverter
    {
        public static Model.NoteSearchQuery Convert(View.NoteSearchQuery viewNoteSearchQuery)
        {
            if (viewNoteSearchQuery == null)
            {
                throw new ArgumentNullException(nameof(viewNoteSearchQuery));
            }

            var modelNoteSearchQuery = new Model.NoteSearchQuery
            {
                Skip = viewNoteSearchQuery.Skip ?? 0,
                Take = viewNoteSearchQuery.Take ?? 10,
                Favorite = viewNoteSearchQuery.Favorite ?? false,
                FromDate = viewNoteSearchQuery.FromDate,
                ToDate = viewNoteSearchQuery.FromDate,
                Descending = viewNoteSearchQuery.Descending ?? false,
            };

            return modelNoteSearchQuery;
        }
    }
}
