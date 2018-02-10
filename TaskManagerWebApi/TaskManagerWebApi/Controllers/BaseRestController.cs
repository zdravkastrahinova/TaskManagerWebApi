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
    public abstract class BaseRestController<TModel, TService> : ApiController 
        where TModel: BaseModel, new()
        where TService: BaseService<TModel>
    {
        protected TService Service;

        public BaseRestController(TService service)
        {
            this.Service = service;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            List<TModel> items = Service.GetAll().ToList();

            return Ok(items);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetById(int id)
        {
            TModel item = Service.GetByID(id);
            if (item == null || item.IsDeleted)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public virtual IHttpActionResult Create([FromBody] TModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            TModel item = new TModel();       
            Mapper.Map(model, item, typeof(TModel), typeof(TModel));
            Service.Save(item);

            return Ok(item);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual IHttpActionResult Edit([FromBody] TModel model, int id)
        {
            if (model.ID != id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            TModel item = Service.GetByID(model.ID);
            if (item == null || item.IsDeleted)
            {
                return NotFound();
            }

            Mapper.Map(model, item, typeof(TModel), typeof(TModel));
            Service.Save(item);

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
            
            Service.Delete(id);

            return Ok();
        }
    }
}
