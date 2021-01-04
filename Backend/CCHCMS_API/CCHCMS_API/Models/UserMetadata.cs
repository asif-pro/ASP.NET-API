using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace CCHCMS_API.Models
{
    public class UserMetadata
    {
        [JsonIgnore,XmlIgnore]
        public virtual ICollection<UserInformation> UserInformations { get; set; }
    }
}