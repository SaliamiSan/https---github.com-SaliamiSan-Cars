using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Routing;
using Infrastruction.DomainObjects;
using Microsoft.Data.OData;

namespace CarRent.Controllers
{
    using Infrastruction;

    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using Infrastruction.DomainObjects;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Car>("Cars");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class CarsController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        private ICarService _service = null;
        public CarsController(ICarService service)
        {
            _service = service;
        }

        // GET: odata/Cars
        public IHttpActionResult GetCars(ODataQueryOptions<Car> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(this._service.GetAllCars(x => true));
        }

        // GET: odata/Cars(5)
        public IHttpActionResult GetCar([FromODataUri] int key, ODataQueryOptions<Car> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<Car>(car);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PUT: odata/Cars(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Car> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Put(car);

            // TODO: Save the patched entity.

            // return Updated(car);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/Cars
        public IHttpActionResult Post(Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.

            // return Created(car);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/Cars(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Car> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(car);

            // TODO: Save the patched entity.

            // return Updated(car);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/Cars(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
