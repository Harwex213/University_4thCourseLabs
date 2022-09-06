using System.Xml.Serialization;

namespace Lab03.DTOs
{
    [XmlRoot("Error")]
    public class GetErrorDto
    {
        public string Message { get; set; }
    }
}