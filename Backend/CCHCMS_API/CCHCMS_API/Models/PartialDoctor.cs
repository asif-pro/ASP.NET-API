using Newtonsoft.Json;
using Social_API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace CCHCMS_API.Models
{
    [MetadataType(typeof(DoctorMetadata))]
    public partial class Doctor
    {
        public List<Link> Links { get { return GeneralLinks(); } }
        private List<Link> GeneralLinks()
        {
            List<Link> Links = new List<Link>();
            HttpContext context = HttpContext.Current;
            string baseUrl = context.Request.Url.Scheme + "://" + context.Request.Url.Authority + context.Request.ApplicationPath.TrimEnd('/') + '/';
            string doctorsUrl = "api/doctors/";

            Links.Add(new Link() { Url = baseUrl + doctorsUrl, Method = "Get", Relation = "GetDoctors" });
            Links.Add(new Link() { Url = baseUrl + doctorsUrl + this.Id, Method = "Get", Relation = "GetDoctor" });
            Links.Add(new Link() { Url = baseUrl + doctorsUrl, Method = "Post", Relation = "AddDoctor" });
            Links.Add(new Link() { Url = baseUrl + doctorsUrl + this.Id, Method = "Put", Relation = "UpdateDoctor" });
            Links.Add(new Link() { Url = baseUrl + doctorsUrl + this.Id, Method = "Delete", Relation = "DeleteDoctor" });

            return Links;
        }
    }
}