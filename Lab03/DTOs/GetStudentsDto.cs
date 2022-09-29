using System.Collections.Generic;
using System.Xml.Serialization;

namespace Lab03.DTOs
{
    [XmlRoot("Students")]
    public class GetStudentsDto
    {
        [XmlArrayItem("Student")]
        public List<GetStudentDto> Content { get; set; }
        
        [XmlArrayItem("Link")]
        public List<HateoasLinkDto> Links { get; set; }
        
        public static List<HateoasLinkDto> CreateDefaultLinks(string link)
        {
            return new List<HateoasLinkDto>
            {
                new HateoasLinkDto { Rel = "create", Method = "POST", Href = link },
            };
        }
    }
}