using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Lab03.DTOs
{
    [XmlRoot("Student")]
    public class GetStudentDto
    {
        [XmlAttribute]
        public int Id { get; set; }
        
        [XmlAttribute]
        public string Name { get; set; }
        
        [XmlAttribute]
        public string Phone { get; set; }
        
        [XmlArrayItem("Link")]
        public List<HateoasLinkDto> Links { get; set; }

        public static List<HateoasLinkDto> CreateDefaultLinks(string link)
        {
            return new List<HateoasLinkDto>
            {
                new HateoasLinkDto { Rel = "update", Method = "PUT", Href = link },
                new HateoasLinkDto { Rel = "delete", Method = "DELETE", Href = link },
            };
        }
        
        public static List<HateoasLinkDto> CreateDefaultLinks(string link, int entityId)
        {
            var href = $"{link}/{entityId}";
            return new List<HateoasLinkDto>
            {
                new HateoasLinkDto { Rel = "self", Method = "GET", Href = href },
                new HateoasLinkDto { Rel = "update", Method = "PUT", Href = href },
                new HateoasLinkDto { Rel = "delete", Method = "DELETE", Href = href },
            };
        }
    }
}