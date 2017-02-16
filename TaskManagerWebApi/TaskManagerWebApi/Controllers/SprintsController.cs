using TaskManagerWebApi.Models;
using TaskManagerWebApi.Services;

namespace TaskManagerWebApi.Controllers
{
    public class SprintsController : BaseRestController<Sprint, SprintsService>
    {
        public SprintsController() : base(new SprintsService()) { }
    }
}
