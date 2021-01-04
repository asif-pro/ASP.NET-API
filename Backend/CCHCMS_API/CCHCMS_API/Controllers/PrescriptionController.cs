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
    [RoutePrefix("api/prescriptions"), BasicAuthentication]
    public class PrescriptionController : ApiController
    {
        PrescriptionRepository prescriptionRepository = new PrescriptionRepository();
        [Route("", Name = "GetPrescriptions")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var prescriptions = prescriptionRepository.GetAll();
            if (prescriptions == null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
            else
                return Ok(prescriptions);
        }
        [Route("{id}", Name = "GetPrescription")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var prescription = prescriptionRepository.Get(id);
            if (prescription == null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
            return Ok(prescription);
        }
        [Route("", Name = "PostPrescription")]
        [HttpPost]
        public IHttpActionResult Post(Prescription prescription)
        {
            prescriptionRepository.Insert(prescription);
            string uri = Url.Link("GetPrescription", new { id = prescription.Id });
            return Created(uri, prescription);
        }
        [Route("{id}", Name = "UpdatePrescription")]
        [HttpPut]
        public IHttpActionResult Put([FromUri] int id, [FromBody] Prescription prescription)
        {
            prescription.Id = id;
            prescriptionRepository.Update(prescription);
            return Ok(prescription);
        }
        [Route("{id}", Name = "DeletePrescription")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            prescriptionRepository.Delete(id);
            return StatusCode(HttpStatusCode.NotFound);
        }
    }
}
