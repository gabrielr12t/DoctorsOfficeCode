using System.Collections.Generic;
using System.Linq;

namespace DoctorsOffice.Api.V1.Responses
{
    public class Response
    {
        public IEnumerable<string> Errors { get; set; }
        public bool HasError { get { return Errors?.Any() ?? false; } }
    }

    public class Response<T> : Response
    {
        public T Data { get; set; }
    }
}
