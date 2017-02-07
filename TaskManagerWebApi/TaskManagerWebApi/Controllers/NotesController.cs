using System.Web.Http;
using TaskManagerWebApi.Models;
using TaskManagerWebApi.Services;

namespace TaskManagerWebApi.Controllers
{
    [RoutePrefix("notes")]
    public class NotesController : BaseRestController<Note, NotesService>
    {
        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create([FromBody] Note model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            NotesService notesService = new NotesService();

            Note note = new Note();
            note.ID = model.ID;
            note.TaskID = model.TaskID;
            note.Title = model.Title;
            note.Content = model.Content;

            notesService.Save(note);

            return Ok(note);
        }

        [HttpPut]
        [Route("edit/{id}")]
        public IHttpActionResult Edit([FromBody] Note model, int id)
        {
            if (model.ID != id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            NotesService notesService = new NotesService();
            Note note = notesService.GetByID(model.ID);

            if (note == null || note.IsDeleted)
            {
                return NotFound();
            }

            note.ID = model.ID;
            note.TaskID = model.TaskID;
            note.Title = model.Title;
            note.Content = model.Content;

            notesService.Save(note);

            return Ok();
        }
    }
}
