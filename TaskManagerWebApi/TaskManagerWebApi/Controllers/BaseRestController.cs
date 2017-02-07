using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using TaskManagerWebApi.Models;
using TaskManagerWebApi.Services;

namespace TaskManagerWebApi.Controllers
{
    [RoutePrefix("api/")]
    [EnableCors("*", "*", "*")]
    public class BaseRestController<TModel, TService> : ApiController 
        where TModel: BaseModel, new()
        where TService: BaseService<TModel>
    {
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            BaseService<TModel> service = new BaseService<TModel>();
            List<TModel> items = service.GetAll().ToList();

            return Ok(items);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetById(int id)
        {
            BaseService<TModel> service = new BaseService<TModel>();
            TModel item = service.GetByID(id);

            if (item == null || item.IsDeleted)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            BaseService<TModel> service = new BaseService<TModel>();
            service.Delete(id);

            return Ok();
        }
    }
}
