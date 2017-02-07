using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using TaskManagerWebApi.Models;
using TaskManagerWebApi.Services;

namespace TaskManagerWebApi.Controllers
{
    [RoutePrefix("tasks")]
    public class TasksController : BaseRestController<Task, TasksService>
    {
        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create([FromBody] Task model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            TasksService tasksService = new TasksService();

            Task task = new Task();
            task.ID = model.ID;
            task.UserID = model.UserID;
            task.Name = model.Name;
            task.IsComplete = model.IsComplete;

            tasksService.Save(task);

            return Ok(task);
        }

        [HttpPut]
        [Route("edit/{id}")]
        public IHttpActionResult Edit([FromBody] Task model, int id)
        {
            if (model.ID != id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            TasksService tasksService = new TasksService();
            Task task = tasksService.GetByID(model.ID);

            if (task == null || task.IsDeleted)
            {
                return NotFound();
            }

            task.ID = model.ID;
            task.UserID = model.UserID;
            task.Name = model.Name;
            task.IsComplete = model.IsComplete;

            tasksService.Save(task);

            return Ok();
        }

        [HttpGet]
        [Route("{id}/notes")]
        public IHttpActionResult GetNotes(int id)
        {
            TasksService tasksService = new TasksService();
            List<Note> notes = tasksService.GetByTaskID(id).ToList();

            return Ok(notes);
        }
    }
}
