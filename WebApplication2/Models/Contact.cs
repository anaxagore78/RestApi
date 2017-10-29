using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{

    public class Contact
    {
        //[!code-csharp[Main](build-restful-apis-with-aspnet-web-api/samples/sample2.cs)]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}