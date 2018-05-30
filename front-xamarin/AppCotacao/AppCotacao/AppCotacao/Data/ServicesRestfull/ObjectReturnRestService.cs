using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;

namespace AppCotacao.Data.ServicesRestfull
{
    public class ObjectReturnRestService<T> 
    {
        public bool HasError { get; set; }
        public bool IsSuccess { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public object SimpleContent { get; set; }
        public JObject JSonContent { get; set; }
        public T Content { get; set; }
        public List<T> ContentList { get; set; }
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
    }
}
