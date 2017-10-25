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
    public class EvaluationController : ApiController
    {
        public IHttpActionResult GetEvaluation(string id)
        {
            try
            {
                Guid patientId;
                if (ValidateGuid(id, out patientId))
                {
                    var evaluation = Business.Evaluation.GetEvaluationsByPatientGuid(patientId);
                    return Json(evaluation, JsonSerializer);
                }
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return NotFound();
                throw;
            }
        }

        private JsonSerializerSettings JsonSerializer = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        };

        public bool ValidateGuid(string guidString, out Guid guid)
        {
            return (Guid.TryParse(guidString, out guid) && guid != Guid.Empty);

        }

        public IHttpActionResult GetPeople()
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
