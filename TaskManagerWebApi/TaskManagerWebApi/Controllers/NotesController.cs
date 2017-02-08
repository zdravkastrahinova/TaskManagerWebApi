using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TaskManagerWebApi.Models;
using TaskManagerWebApi.Services;

namespace TaskManagerWebApi.Controllers
{
    [RoutePrefix("notes")]
    public class NotesController : BaseRestController<Note, NotesService>
    {
        [HttpGet]
        [Route("{id}/notes")]
        public IHttpActionResult GetNotes(int id)
        {
            NotesService service = new NotesService();
            List<Note> notes = service.GetByTaskID(id).ToList();

            return Ok(notes);
        }
    }
}
