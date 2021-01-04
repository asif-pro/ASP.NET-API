using CCHCMS_API.Attributes;
using CCHCMS_API.Models;
using CCHCMS_API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CCHCMS_API.Controllers
{
    [RoutePrefix("api/patients"), BasicAuthentication]
    public class PatientController : ApiController
    {
        PatientRepository patientRepository = new PatientRepository();
        [Route("", Name = "GetPatients")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var patients = patientRepository.GetAll();
            if (patients == null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }else
                return Ok(patients);
        }
        [Route("{id}", Name = "GetPatient")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var patient = patientRepository.Get(id);
            if (patient == null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
            else
                return Ok(patient);
        }
        [Route("", Name = "PostPatient")]
        [HttpPost]
        public IHttpActionResult Post(Patient patient)
        {
            patientRepository.Insert(patient);
            string uri = Url.Link("GetPatient", new { id = patient.Id });
            return Created(uri, patient);
        }
        [Route("{id}", Name = "UpdatePatient")]
        [HttpPut]
        public IHttpActionResult Put([FromUri] int id, [FromBody] Patient patient)
        {
            patient.Id = id;
            patientRepository.Update(patient);
            return Ok(patient);
        }
        [Route("{id}", Name = "DeletePatient")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            patientRepository.Delete(id);
            return StatusCode(HttpStatusCode.NotFound);
        }
    }
}
