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
    [RoutePrefix("api/users"), BasicAuthentication]
    public class UserController : ApiController
    {
        UserRepository userRepository = new UserRepository();
        [Route("", Name = "GetUsers")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var users = userRepository.GetAll();
            if (users == null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
            else
                return Ok(users);
        }
        [Route("{id}", Name = "GetUser")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var user = userRepository.Get(id);
            if (user == null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
            else
                return Ok(user);
        }
        [Route("", Name = "PostUser")]
        [HttpPost]
        public IHttpActionResult Post(User user)
        {
            userRepository.Insert(user);
            string uri = Url.Link("GetUser", new { id = user.Id });
            return Created(uri, user);
        }
        [Route("{id}", Name = "UpdateUser")]
        [HttpPut]
        public IHttpActionResult Put([FromUri] int id, [FromBody] User user)
        {
            user.Id = id;
            userRepository.Update(user);
            return Ok(user);
        }
        [Route("{id}", Name = "DeleteUser")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            userRepository.Delete(id);
            return StatusCode(HttpStatusCode.NotFound);
        }
    }
}
