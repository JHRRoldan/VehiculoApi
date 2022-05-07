using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VehiculosUtilities.Models
{
    public class Result<T>
    {
        public Result(){}

        public string Message { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public T Payload { get; set; }
    }
}
