using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using TaskManagerWebApi.Models;
using TaskManagerWebApi.Repositories;

namespace TaskManagerWebApi.Controllers
{
    [RoutePrefix("api/tasks")]
    [EnableCors("*", "*", "*")]
    public class TasksController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            TasksRepository tasksRepo = new TasksRepository();
            List<Task> tasks = tasksRepo.GetAll();

            return Ok(tasks);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetById(int id)
        {            
            TasksRepository tasksRepo = new TasksRepository();
            Task task = tasksRepo.GetByID(id);

            if (task == null || task.IsDeleted)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create([FromBody] Task model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            TasksRepository tasksRepo = new TasksRepository();

            Task task = new Task();
            task.ID = model.ID;
            task.UserID = model.UserID;
            task.Name = model.Name;
            task.IsComplete = model.IsComplete;

            tasksRepo.Save(task);

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

            TasksRepository tasksRepo = new TasksRepository();
            Task task = tasksRepo.GetByID(model.ID);

            if (task == null || task.IsDeleted)
            {
                return NotFound();
            }

            task.ID = model.ID;
            task.UserID = model.UserID;
            task.Name = model.Name;
            task.IsComplete = model.IsComplete;

            tasksRepo.Save(task);

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

            TasksRepository tasksRepo = new TasksRepository();
            tasksRepo.Delete(id);

            return Ok();
        }
    }
}
