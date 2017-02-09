using System.Web.Http;
using TaskManagerWebApi.Models;
using TaskManagerWebApi.Services;

namespace TaskManagerWebApi.Controllers
{
    public class UsersController : BaseRestController<User, UsersService>
    {
        public UsersController() : base(new UsersService()) { }
    }
}
