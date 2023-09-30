using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment_1.Controllers
{
    public class GreetingController : ApiController
    {
        [HttpGet]
        //POST /api/Greeting
        public string Post() 
        {
            return "Hello World!";
        }
        public string get(int id)
        {
            var result = "Greetings to " + id+" people!";
            return (result);
        }
    }
}
