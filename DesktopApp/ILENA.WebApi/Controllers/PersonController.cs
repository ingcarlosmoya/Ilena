using ILENA.Business;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ILENA.WebApi.Controllers
{
    public class PersonController : ApiController
    {
        private JsonSerializerSettings JsonSerializer = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        };

        public bool ValidateGuid(string guidString, out Guid guid)
        {
            return (Guid.TryParse(guidString, out guid) && guid != Guid.Empty);

        }

        public IHttpActionResult GetPerson()
        {
            try
            {

                var people = Business.Person.GetPeople();
                return Json(people, JsonSerializer);

            }
            catch (Exception ex)
            {
                return NotFound();
                throw;
            }
        }

    }
}
