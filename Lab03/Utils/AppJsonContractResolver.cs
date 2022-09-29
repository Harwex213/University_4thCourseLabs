using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Lab03.Utils
{

    public class AppJsonContractResolver : DefaultContractResolver
    {
        private readonly string[] _props;
        public AppJsonContractResolver(params string[] props)
        {
            _props = props.Select(p => p.ToLower()).ToArray();
        }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var properties = base.CreateProperties(type, memberSerialization);
            return properties.Where(p => _props.Contains(p.PropertyName.ToLower())).ToList();
        }
    }
}