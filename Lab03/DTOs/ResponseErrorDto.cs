using System.Collections.Generic;
using System.Xml.Serialization;

namespace Lab03.DTOs
{
    [XmlRoot("Error")]
    public class ResponseErrorDto
    {
        public int StatusCode { get; set; }
        
        [XmlArrayItem("Link")]
        public List<HateoasLinkDto> Links { get; set; }
        
        public static List<HateoasLinkDto> CreateDefaultLinks(int code)
        {
            var href = $"{RouteConfig.ApiPrefix}/{RouteConfig.ErrorsUri}/{code}";
            return new List<HateoasLinkDto>
            {
                new HateoasLinkDto { Rel = "describe", Method = "GET", Href = href },
            };
        }
    }
}