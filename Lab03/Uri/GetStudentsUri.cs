using System;

namespace Lab03.Uri
{
    public class GetStudentsUri
    {
        public enum SupportedMediaTypeResponse
        {
            Json,
            Xml
        }

        public SupportedMediaTypeResponse MediaType { get; set; } = SupportedMediaTypeResponse.Json;
        
        public int? Limit { get; set; }
        
        public int? Offset { get; set; }
        
        public bool? Sort { get; set; }
        
        public string Like { get; set; }
        
        public string GlobalLike { get; set; }

        public int? MinId { get; set; }

        public int? MaxId { get; set; }
        
        public string Columns { get; set; }
    }
}