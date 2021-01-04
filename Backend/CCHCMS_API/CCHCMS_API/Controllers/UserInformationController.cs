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
    [RoutePrefix("api/userinformations"), BasicAuthentication]
    public class UserInformationController : ApiController
    {
        UserInformationRepository userInformationRepository = new UserInformationRepository();
        [Route("", Name = "GetUserInformations")]
        [HttpGet]
        public IHttpActionResult Get()

        {
            var userInformations = userInformationRepository.GetAll();
            if (userInformations == null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
            return Ok(userInformations);
        }
        [Route("{id}", Name = "GetUserInformation")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var userInformations = userInformationRepository.Get(id);
            if (userInformations == null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
            return Ok(userInformations);
        }
        [Route("", Name = "PostUserInformation")]
        [HttpPost]
        public IHttpActionResult Post(UserInformation userInformation)
        {
            userInformationRepository.Insert(userInformation);
            string uri = Url.Link("GetUserInformation", new { id = userInformation.Id });
            return Created(uri, userInformation);
        }
        [Route("{id}", Name = "UpdateUserInformation")]
        [HttpPut]
        public IHttpActionResult Put([FromUri] int id, [FromBody] UserInformation userinformation)
        {
            userinformation.Id = id;
            userInformationRepository.Update(userinformation);
            return Ok(userinformation);
        }
        [Route("{id}", Name = "DeleteUserInformation")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            userInformationRepository.Delete(id);
            return StatusCode(HttpStatusCode.NotFound);
        }
    }
}
