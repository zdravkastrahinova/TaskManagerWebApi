using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TaskManagerWebApi.Models;
using TaskManagerWebApi.Services;

namespace TaskManagerWebApi.Controllers
{
    public class NotesController : BaseRestController<Note, NotesService>
    {
        public NotesController() : base(new NotesService()) { }

        [HttpGet]
        [Route("tasks/{taskId}/notes")]
        public IHttpActionResult GetNotes(int taskId)
        {
            List<Note> notes = this.Service.GetByTaskID(taskId).ToList();

            return Ok(notes);
        }
    }
}
