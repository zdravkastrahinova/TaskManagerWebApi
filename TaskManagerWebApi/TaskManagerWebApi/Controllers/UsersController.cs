using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using TaskManagerWebApi.Models;
using TaskManagerWebApi.Repositories;

namespace TaskManagerWebApi.Controllers
{
    [RoutePrefix("api/users")]
    [EnableCors("*", "*", "*")]
    public class UsersController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            UsersRepository usersRepo = new UsersRepository();
            List<User> users = usersRepo.GetAll();

            return Ok(users);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetById(int id)
        {
            UsersRepository usersRepo = new UsersRepository();
            User user = usersRepo.GetByID(id);

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

            UsersRepository usersRepo = new UsersRepository();

            User user = new User();
            user.ID = model.ID;
            user.Email = model.Email;
            user.Password = model.Password;

            usersRepo.Save(user);

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

            UsersRepository usersRepo = new UsersRepository();
            User user = usersRepo.GetByID(model.ID);

            if (user == null || user.IsDeleted)
            {
                return NotFound();
            }

            user.ID = model.ID;
            user.Email = model.Email;
            user.Password = model.Password;

            usersRepo.Save(user);

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

            UsersRepository usersRepo = new UsersRepository();
            usersRepo.Delete(id);

            return Ok();
        }
    }
}
