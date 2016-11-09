using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarRent.Controllers
{
    using System.Web.Http.OData;

    using Infrastruction;
    using Infrastruction.DomainObjects;

    public class CarController : ApiController
    {

        private ICarService _service = null;
        public CarController(ICarService service)
        {
            _service = service;
        }

        // GET api/values
        //[EnableQuery]
        [HttpGet]
        IQueryable<Car> Get()
        {
            return this._service.GetAllCars(c=>true).AsQueryable();
        }

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
