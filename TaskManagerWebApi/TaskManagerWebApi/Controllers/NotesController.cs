using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using TaskManagerWebApi.Models;
using TaskManagerWebApi.Repositories;

namespace TaskManagerWebApi.Controllers
{
    [RoutePrefix("api/notes")]
    [EnableCors("*", "*", "*")]
    public class NotesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            NotesRepository notesRepo = new NotesRepository();
            List<Note> notes = notesRepo.GetAll();

            return Ok(notes);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetById(int id)
        {
            NotesRepository notesRepo = new NotesRepository();
            Note note = notesRepo.GetByID(id);

            if (note == null || note.IsDeleted)
            {
                return NotFound();
            }

            return Ok(note);
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create([FromBody] Note model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            NotesRepository notesRepo = new NotesRepository();

            Note note = new Note();
            note.ID = model.ID;
            note.TaskID = model.TaskID;
            note.Title = model.Title;
            note.Content = model.Content;

            notesRepo.Save(note);

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

            NotesRepository notesRepo = new NotesRepository();
            Note note = notesRepo.GetByID(model.ID);

            if (note == null || note.IsDeleted)
            {
                return NotFound();
            }

            note.ID = model.ID;
            note.TaskID = model.TaskID;
            note.Title = model.Title;
            note.Content = model.Content;

            notesRepo.Save(note);

            return Ok();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            NotesRepository notesRepo = new NotesRepository();
            notesRepo.Delete(id);

            return Ok();
        }
    }
}
