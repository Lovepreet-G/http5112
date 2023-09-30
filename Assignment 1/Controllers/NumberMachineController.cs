using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01635873_Assignment_1.Controllers
{
    public class NumberMachineController : ApiController
    {
        //GET /api/NumberMachine/{id}
        public string[] get(int id)
        {
            string[] result = new string[4];
            var addition = id + 5;
            var sub = id - 5;
            var mult = id * 5;
            var div = id / 5;
            result[0] = addition.ToString();
            result[1] = sub.ToString();
            result[2] = mult.ToString();
            result[3] = div.ToString();
            return result;            

        }
    }
}
