using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using TaskManagerWebApi.Models;
using TaskManagerWebApi.Services;

namespace TaskManagerWebApi.Controllers
{
    [RoutePrefix("api/users")]
    [EnableCors("*", "*", "*")]
    public class UsersController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            UsersService usersService = new UsersService();
            List<User> users = usersService.GetAll().ToList();

            return Ok(users);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetById(int id)
        {
            UsersService usersService = new UsersService();
            User user = usersService.GetByID(id);

            if (user == null || user.IsDeleted)
            {
                return NotFound();
            }

            return Ok(user);
        }

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

        [HttpDelete]
        [Route("delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            UsersService usersService = new UsersService();
            usersService.Delete(id);

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
