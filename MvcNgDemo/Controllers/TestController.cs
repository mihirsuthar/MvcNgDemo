using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcNgDemo.Controllers
{
    public class TestController : ApiController
    {
        public string Index()
        {
            return "Text";
        }
    }
}
