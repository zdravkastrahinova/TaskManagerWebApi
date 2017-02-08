using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TaskManagerWebApi.Models;
using TaskManagerWebApi.Services;

namespace TaskManagerWebApi.Controllers
{
    public class TasksController : BaseRestController<Task, TasksService>
    {
        public TasksController() : base(new TasksService()) { }

        [HttpGet]
        [Route("~/api/users/{userId}/tasks")]
        public IHttpActionResult GetTasks(int userId)
        {
            List<Task> tasks = this.Service.GetByUserID(userId).ToList();

            return Ok(tasks);
        }
    }
}
