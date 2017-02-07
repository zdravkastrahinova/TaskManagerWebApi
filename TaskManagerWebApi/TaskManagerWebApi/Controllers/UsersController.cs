using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using TaskManagerWebApi.Models;
using TaskManagerWebApi.Services;

namespace TaskManagerWebApi.Controllers
{
    [RoutePrefix("users")]
    public class UsersController : BaseRestController<User, UsersService>
    {
        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create([FromBody] User model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            UsersService usersService = new UsersService();

            User user = new User();
            user.ID = model.ID;
            user.Name = model.Name;
            user.Email = model.Email;
            user.Password = model.Password;

            usersService.Save(user);

            return Ok(user);
        }

        [HttpPut]
        [Route("edit/{id}")]
        public IHttpActionResult Edit([FromBody] User model, int id)
        {
            if (model.ID != id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            UsersService usersService = new UsersService();
            User user = usersService.GetByID(model.ID);

            if (user == null || user.IsDeleted)
            {
                return NotFound();
            }

            user.ID = model.ID;
            user.Name = model.Name;
            user.Email = model.Email;
            user.Password = model.Password;

            usersService.Save(user);

            return Ok();
        }

        [HttpGet]
        [Route("{id}/tasks")]
        public IHttpActionResult GetTasks(int id)
        {
            UsersService usersService = new UsersService();
            List<Task> tasks = usersService.GetByUserID(id).ToList();

            return Ok(tasks);
        }
    }
}
