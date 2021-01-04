using Social_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCHCMS_API.Models
{
    public partial class UserInformation
    {
        public List<Link> Links { get { return GeneralLinks(); } }
        private List<Link> GeneralLinks()
        {
            List<Link> Links = new List<Link>();
            HttpContext context = HttpContext.Current;
            string baseUrl = context.Request.Url.Scheme + "://" + context.Request.Url.Authority + context.Request.ApplicationPath.TrimEnd('/') + '/';
            string userInformationsUrl = "api/userinformations/";

            Links.Add(new Link() { Url = baseUrl + userInformationsUrl, Method = "Get", Relation = "GetUserInformations" });
            Links.Add(new Link() { Url = baseUrl + userInformationsUrl + this.Id, Method = "Get", Relation = "GetUserInformation" });
            Links.Add(new Link() { Url = baseUrl + userInformationsUrl, Method = "Post", Relation = "AddUserInformation" });
            Links.Add(new Link() { Url = baseUrl + userInformationsUrl + this.Id, Method = "Put", Relation = "UpdateUserInformation" });
            Links.Add(new Link() { Url = baseUrl + userInformationsUrl + this.Id, Method = "Delete", Relation = "DeleteUserInformation" });

            return Links;
        }
    }
}