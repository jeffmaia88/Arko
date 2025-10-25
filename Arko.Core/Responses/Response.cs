using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Arko.Core;

namespace Arko.Core.Responses
{
    public class Response<TData>
    {
        private readonly int _code;

        [JsonConstructor]
        public Response()
        {
            _code = Definitions.DefaultStatusCode;
        }

        public Response(TData? data, int code = Definitions.DefaultStatusCode, string? message = null)
        {
            Data = data;
            Message = message;
            _code = code;
        }

        public TData? Data { get; set; }
        public string? Message { get; set; } = string.Empty;
        public int StatusCode => _code;


        [JsonIgnore]
        public bool IsSuccess => _code is >= 200 and <= 299;
    }
}
