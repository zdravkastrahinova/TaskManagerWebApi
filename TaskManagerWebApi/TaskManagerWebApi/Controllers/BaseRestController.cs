using AutoMapper;
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
        protected BaseService<TModel> service;

        public BaseRestController()
        {
            this.service = new BaseService<TModel>();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            List<TModel> items = service.GetAll().ToList();

            return Ok(items);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetById(int id)
        {
            TModel item = service.GetByID(id);

            if (item == null || item.IsDeleted)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody] TModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            TModel item = new TModel();
            
            Mapper.Map(model, item, typeof(TModel), typeof(TModel));

            service.Save(item);

            return Ok(item);
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Edit([FromBody] TModel model, int id)
        {
            if (model.ID != id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            TModel item = service.GetByID(model.ID);

            if (item == null || item.IsDeleted)
            {
                return NotFound();
            }

            Mapper.Map(model, item, typeof(TModel), typeof(TModel));

            service.Save(item);

            return Ok(item);
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            
            service.Delete(id);

            return Ok();
        }
    }
}
