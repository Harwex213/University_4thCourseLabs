using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Lab03.DTOs
{
    public class PropertySelectSpecifierAttribute : Attribute
    {
    }
    
    [XmlRoot("Student")]
    public class GetStudentDto
    {
        public int Id { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        [PropertySelectSpecifier]
        public bool IdSpecified { get; set; } = true;
        
        public string Name { get; set; }
        
        [XmlIgnore]
        [JsonIgnore]
        [PropertySelectSpecifier]
        public bool NameSpecified { get; set; } = true;
        
        public string Phone { get; set; }
        
        [XmlIgnore]
        [JsonIgnore]
        [PropertySelectSpecifier]
        public bool PhoneSpecified { get; set; } = true;
        
        [XmlArrayItem("Link")]
        public List<HateoasLinkDto> Links { get; set; }
    }
}