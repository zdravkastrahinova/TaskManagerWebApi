using AutoMapper;
using System.Web.Http;
using TaskManagerWebApi.Models;
using TaskManagerWebApi.Services;

namespace TaskManagerWebApi.Controllers
{
    public class UsersController : BaseRestController<User, UsersService>
    {
        public UsersController() : base(new UsersService()) { }

        [HttpPost]
        public override IHttpActionResult Create([FromBody] User model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (Service.IfUserExists(model))
            {
                return Conflict();
            }

            User user = new User();
            Mapper.Map(model, user, typeof(User), typeof(User));
            Service.Save(user);

            return Ok(user);
        }

        [HttpPut]
        public override IHttpActionResult Edit([FromBody] User model, int id)
        {
            if (model.ID != id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (Service.IfUserExists(model))
            {
                return Conflict();
            }

            User user = Service.GetByID(model.ID);
            if (user == null || user.IsDeleted)
            {
                return NotFound();
            }

            Mapper.Map(model, user, typeof(User), typeof(User));
            Service.Save(user);

            return Ok(user);
        }
    }
}
