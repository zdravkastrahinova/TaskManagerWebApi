using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using TaskManagerWebApi.Models;
using TaskManagerWebApi.Services;

namespace TaskManagerWebApi.Controllers
{
    public class TasksController : BaseRestController<Task, TasksService>
    {
        [HttpGet]
        [Route("users/{userId}/tasks")]
        //[Route(":userId")]
        public IHttpActionResult GetTasks(int? userId = null)
        {
            Type type = this.service.GetType();
            MethodInfo method = type.GetMethod("GetByUserID");
            ParameterInfo[] parameters = method.GetParameters();
            object classInstance = Activator.CreateInstance(type, null);

            object tasks = method.Invoke(classInstance, parameters);

            return Ok(tasks);
        }
    }
}
