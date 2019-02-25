namespace Models.Notes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NotesRepository : INotesRepository
    {
        private readonly IList<Note> notes = new List<Note>();

        public NoteCreationInfo Create(NoteBuildInfo buildInfo)
        {
            if (buildInfo == null)
            {
                throw new ArgumentNullException(nameof(buildInfo));
            }

            var utcNow = DateTime.UtcNow;
            var id = Guid.NewGuid();

            var note = new Note
            {
                Id = id,
                Title = buildInfo.Title,
                Text = buildInfo.Text,
                Favorite = false,
                CreatedAt = utcNow,
                UpdatedAt = utcNow,
            };

            this.notes.Add(note);

            var noteCreationInfo = new NoteCreationInfo
            {
                Id = id,
                CreatedAt = utcNow,
            };

            return noteCreationInfo;
        }

        public IReadOnlyList<Note> Search(NoteSearchQuery searchQuery)
        {
            if (searchQuery == null)
            {
                throw new ArgumentNullException(nameof(searchQuery));
            }

            var searchResult = this.notes.AsEnumerable();

            if (searchQuery.FromDate.HasValue)
            {
                searchResult = searchResult.Where(it => it.CreatedAt >= searchQuery.FromDate);
            }

            if (searchQuery.ToDate.HasValue)
            {
                searchResult = searchResult.Where(it => it.CreatedAt < searchQuery.ToDate);
            }

            if (searchQuery.Favorite == true)
            {
                searchResult = searchResult.Where(it => it.Favorite);
            }

            if (searchQuery.Descending == true)
            {
                searchResult = searchResult.OrderByDescending(it => it.CreatedAt);
            }
            else
            {
                searchResult = searchResult.OrderBy(it => it.CreatedAt);
            }

            searchResult = searchResult.Skip(searchQuery.Skip ?? 0);

            // ограничиваем количество получаемых заметок до 100 чтобы сервис не упал
            searchResult = searchResult.Take(Math.Min(searchQuery.Take ?? 10, 100));

            return searchResult.ToList();
        }

        public Note Get(Guid id)
        {
            var note = this.notes.FirstOrDefault(it => it.Id == id);

            if (note == null)
            {
                throw new NoteNotFoundException(id);
            }

            return note;
        }

        public void Update(Guid id, NotePatchInfo patchInfo)
        {
            if (patchInfo == null)
            {
                throw new ArgumentNullException(nameof(patchInfo));
            }

            var note = this.notes.FirstOrDefault(it => it.Id == id);

            if (note == null)
            {
                throw new NoteNotFoundException(id);
            }

            if (patchInfo.Title != null)
            {
                note.Title = patchInfo.Title;
            }

            if (patchInfo.Text != null)
            {
                note.Text = patchInfo.Text;
            }

            note.UpdatedAt = DateTime.UtcNow;
        }

        public void Delete(Guid id)
        {
            var note = this.notes.FirstOrDefault(it => it.Id == id);

            if (note == null)
            {
                throw new NoteNotFoundException(id);
            }

            this.notes.Remove(note);
        }

        public void Favorite(Guid id)
        {
            var note = this.notes.FirstOrDefault(it => it.Id == id);

            if (note == null)
            {
                throw new NoteNotFoundException(id);
            }

            note.Favorite = true;
            note.UpdatedAt = DateTime.UtcNow;
        }
    }
}
