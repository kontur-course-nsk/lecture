namespace Notes.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Notes.API.Errors;
    using Notes.Models.Converters.Notes;
    using Notes.Models.Notes.Repositories;
    using Model = global::Notes.Models;

    [Route("v1/notes")]
    public sealed class NotesController : Controller
    {
        private readonly INoteRepository repository;

        public NotesController(INoteRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            this.repository = repository;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateNoteAsync([FromBody]Client.Notes.NoteBuildInfo buildInfo, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (buildInfo == null)
            {
                var error = ServiceErrorResponses.BodyIsMissing("NoteBuildInfo");
                return this.BadRequest(error);
            }

            var userId = Guid.Empty.ToString(); // Нужно исправить

            var creationInfo = NoteBuildInfoConverter.Convert(userId, buildInfo);
            var modelNoteInfo = await this.repository.CreateAsync(creationInfo, cancellationToken).ConfigureAwait(false);

            var clientNoteInfo = NoteInfoConverter.Convert(modelNoteInfo);

            var routeParams = new Dictionary<string, object>
            {
                { "noteId", clientNoteInfo.Id }
            };

            return this.CreatedAtRoute("GetNoteRoute", routeParams, clientNoteInfo);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> SearchNotesAsync([FromQuery]Client.Notes.NoteInfoSearchQuery query, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var modelQuery = NoteInfoSearchQueryConverter.Convert(query ?? new Client.Notes.NoteInfoSearchQuery());
            var modelNotes = await this.repository.SearchAsync(modelQuery, cancellationToken).ConfigureAwait(false);
            var clientNotes = modelNotes.Select(note => NoteInfoConverter.Convert(note)).ToList();
            var clientNotesList = new Client.Notes.NoteList
            {
                Notes = clientNotes
            };

            return this.Ok(clientNotesList);
        }

        [HttpGet]
        [Route("{noteId}", Name = "GetNoteRoute")]
        public async Task<IActionResult> GetNoteAsync([FromRoute]string noteId, CancellationToken cancelltionToken)
        {
            cancelltionToken.ThrowIfCancellationRequested();

            if (!Guid.TryParse(noteId, out var modelNoteId))
            {
                var error = ServiceErrorResponses.NoteNotFound(noteId);
                return this.NotFound(error);
            }

            Model.Notes.Note modelNote = null;

            try
            {
                modelNote = await this.repository.GetAsync(modelNoteId, cancelltionToken).ConfigureAwait(false);
            }
            catch (Model.Notes.NoteNotFoundExcepction)
            {
                var error = ServiceErrorResponses.NoteNotFound(noteId);
                return this.NotFound(error);
            }

            var clientNote = NoteConverter.Convert(modelNote);

            return this.Ok(clientNote);
        }

        [HttpPatch]
        [Route("{noteId}")]
        public async Task<IActionResult> PatchNoteAsync([FromRoute]string noteId, [FromBody]Client.Notes.NotePatchInfo patchInfo, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (patchInfo == null)
            {
                var error = ServiceErrorResponses.BodyIsMissing("NotePatchInfo");
                return this.BadRequest(error);
            }

            if (!Guid.TryParse(noteId, out var noteIdGuid))
            {
                var error = ServiceErrorResponses.NoteNotFound(noteId);
                return this.NotFound(error);
            }

            var modelPathInfo = NotePathcInfoConverter.Convert(noteIdGuid, patchInfo);

            Model.Notes.Note modelNote = null;

            try
            {
                modelNote = await this.repository.PatchAsync(modelPathInfo, cancellationToken).ConfigureAwait(false);
            }
            catch (Model.Notes.NoteNotFoundExcepction)
            {
                var error = ServiceErrorResponses.NoteNotFound(noteId);
                return this.NotFound(error);
            }

            var clientNote = NoteConverter.Convert(modelNote);
            return this.Ok(clientNote);
        }

        [HttpDelete]
        [Route("{noteId}")]
        public async Task<IActionResult> DeleteNoteAsync([FromRoute]string noteId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (!Guid.TryParse(noteId, out var noteIdGuid))
            {
                var error = ServiceErrorResponses.NoteNotFound(noteId);
                return this.NotFound(error);
            }

            try
            {
                await this.repository.RemoveAsync(noteIdGuid, cancellationToken).ConfigureAwait(false);
            }
            catch (Model.Notes.NoteNotFoundExcepction)
            {
                var error = ServiceErrorResponses.NoteNotFound(noteId);
                return this.NotFound(error);
            }

            return this.NoContent();
        }
    }
}
