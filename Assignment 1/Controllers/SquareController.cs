using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment_1.Controllers
{
   
    public class SquareController : ApiController
    {
        //GET /api/Square/{id}
        public int Get(int num)
        {
            var square = num * num;
            return square;
        }
    }
}
