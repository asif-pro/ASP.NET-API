using CCHCMS_API.Attributes;
using CCHCMS_API.Models;
using CCHCMS_API.Repositories;
using System.Net;
using System.Web.Http;

namespace CCHCMS_API.Controllers
{
    [RoutePrefix("api/doctors"), BasicAuthentication]
    public class DoctorController : ApiController
    {
        DoctorRepository doctorRepository = new DoctorRepository();
        [Route("", Name = "GetDoctors")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var doctors = doctorRepository.GetAll();
            if (doctors == null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
                return Ok(doctors);
        }
        [Route("{id}", Name = "GetDoctor")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var doctor = doctorRepository.Get(id);
            if (doctor == null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
                return Ok(doctor);
        }
        [Route("", Name = "PostDoctor")]
        [HttpPost]
        public IHttpActionResult Post(Doctor doctor)
        {
            doctorRepository.Insert(doctor);
            string uri = Url.Link("GetDoctor", new { id = doctor.Id });
            return Created(uri, doctor);
        }
        [Route("{id}", Name = "UpdateDoctor")]
        [HttpPut]
        public IHttpActionResult Put([FromUri] int id, [FromBody] Doctor doctor)
        {
            doctor.Id = id;
            doctorRepository.Update(doctor);
            return Ok(doctor);
        }
        [Route("{id}", Name = "DeleteDoctor")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            doctorRepository.Delete(id);
            return StatusCode(HttpStatusCode.NotFound);
        }
    }
}
