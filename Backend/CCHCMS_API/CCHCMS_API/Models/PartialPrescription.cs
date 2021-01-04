using Social_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCHCMS_API.Models
{
    public partial class Prescription
    {
        public List<Link> Links { get { return GeneralLinks(); } }
        private List<Link> GeneralLinks()
        {
            List<Link> Links = new List<Link>();
            HttpContext context = HttpContext.Current;
            string baseUrl = context.Request.Url.Scheme + "://" + context.Request.Url.Authority + context.Request.ApplicationPath.TrimEnd('/') + '/';
            string prescriptionUrl = "api/prescriptions/";

            Links.Add(new Link() { Url = baseUrl + prescriptionUrl, Method = "Get", Relation = "GetPrescriptions" });
            Links.Add(new Link() { Url = baseUrl + prescriptionUrl + this.Id, Method = "Get", Relation = "GetPrescription" });
            Links.Add(new Link() { Url = baseUrl + prescriptionUrl, Method = "Post", Relation = "AddPrescription" });
            Links.Add(new Link() { Url = baseUrl + prescriptionUrl + this.Id, Method = "Put", Relation = "UpdatePrescription" });
            Links.Add(new Link() { Url = baseUrl + prescriptionUrl + this.Id, Method = "Delete", Relation = "DeletePrescription" });

            return Links;
        }
    }
}