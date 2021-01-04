using Social_API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CCHCMS_API.Models
{
    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
        public List<Link> Links { get { return GeneralLinks(); } }
        private List<Link> GeneralLinks()
        {
            List<Link> Links = new List<Link>();
            HttpContext context = HttpContext.Current;
            string baseUrl = context.Request.Url.Scheme + "://" + context.Request.Url.Authority + context.Request.ApplicationPath.TrimEnd('/') + '/';
            string usersUrl = "api/users/";

            Links.Add(new Link() { Url = baseUrl + usersUrl, Method = "Get", Relation = "GetUsers" });
            Links.Add(new Link() { Url = baseUrl + usersUrl + this.Id, Method = "Get", Relation = "GetUser" });
            Links.Add(new Link() { Url = baseUrl + usersUrl, Method = "Post", Relation = "AddUser" });
            Links.Add(new Link() { Url = baseUrl + usersUrl + this.Id, Method = "Put", Relation = "UpdateUser" });
            Links.Add(new Link() { Url = baseUrl + usersUrl + this.Id, Method = "Delete", Relation = "DeleteUser" });

            return Links;
        }
    }
}