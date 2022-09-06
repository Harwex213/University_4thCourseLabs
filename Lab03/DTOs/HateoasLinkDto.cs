using System;
using System.Xml.Serialization;

namespace Lab03.DTOs
{
    public class HateoasLinkDto
    {
        [XmlAttribute]
        public string Href { get; set; }
        
        [XmlAttribute]
        public string Rel { get; set; }
        
        [XmlAttribute]
        public string Method { get; set; }
    }
}