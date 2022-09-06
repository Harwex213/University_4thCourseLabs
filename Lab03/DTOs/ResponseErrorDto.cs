using System.Xml.Serialization;

namespace Lab03.DTOs
{
    [XmlRoot("Error")]
    public class ResponseErrorDto
    {
        public int StatusCode { get; set; }
    }
}