namespace Models.Notes
{
    using System;
    using System.Collections.Generic;

    public interface INotesRepository
    {
        NoteCreationInfo Create(NoteBuildInfo buildInfo);

        IReadOnlyList<Note> Search(NoteSearchQuery searchQuery);

        Note Get(Guid id);

        void Update(Guid id, NotePatchInfo patchInfo);

        void Delete(Guid id);

        void Favorite(Guid id);
    }
}
