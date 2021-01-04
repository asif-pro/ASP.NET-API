using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace CCHCMS_API.Models
{
    public class PatientMetadata
    {
        [JsonIgnore, XmlIgnore]
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}