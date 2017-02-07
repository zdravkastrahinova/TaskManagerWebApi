using System.Web.Http;
using System.Web.Http.Cors;

namespace TaskManagerWebApi.Controllers
{
    [RoutePrefix("")]
    [EnableCorsAttribute("*", "*", "*")]
    public class HomeController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult Home()
        {
            return Ok();
        }
    }
}