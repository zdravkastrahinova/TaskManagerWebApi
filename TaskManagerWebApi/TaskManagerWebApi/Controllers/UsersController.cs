using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TaskManagerWebApi.Models;
using TaskManagerWebApi.Services;

namespace TaskManagerWebApi.Controllers
{
    [RoutePrefix("users")]
    public class UsersController : BaseRestController<User, UsersService> { }
}
