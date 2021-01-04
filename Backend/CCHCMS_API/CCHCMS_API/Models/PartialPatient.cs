using Social_API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CCHCMS_API.Models
{
    [MetadataType(typeof(PatientMetadata))]
    public partial class Patient
    {
        public List<Link> Links { get { return GeneralLinks(); } }
        private List<Link> GeneralLinks()
        {
            List<Link> Links = new List<Link>();
            HttpContext context = HttpContext.Current;
            string baseUrl = context.Request.Url.Scheme + "://" + context.Request.Url.Authority + context.Request.ApplicationPath.TrimEnd('/') + '/';
            string patientsUrl = "api/patients/";

            Links.Add(new Link() { Url = baseUrl + patientsUrl, Method = "Get", Relation = "GetPatients" });
            Links.Add(new Link() { Url = baseUrl + patientsUrl + this.Id, Method = "Get", Relation = "GetPatient" });
            Links.Add(new Link() { Url = baseUrl + patientsUrl, Method = "Post", Relation = "AddPatient" });
            Links.Add(new Link() { Url = baseUrl + patientsUrl + this.Id, Method = "Put", Relation = "UpdatePatient" });
            Links.Add(new Link() { Url = baseUrl + patientsUrl + this.Id, Method = "Delete", Relation = "DeletePatient" });

            return Links;
        }
    }
}