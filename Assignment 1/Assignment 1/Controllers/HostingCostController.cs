using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment_1.Controllers
{
    // GET /api/HostingCost/{id}
    public class HostingCostController : ApiController
    {
        public string[] get(int id)
        {
            string[] result = new string[3];
            int days = (id / 14)+1;
            var charge = days * 5.50;
            var hst = (charge * 0.13);
            var total = charge + hst;
            result[0] = (days+1).ToString() + " fortnights at $5.50 /FN = $ " + charge.ToString() + " CAD";
            result[1] = "HST 13% = $" + hst.ToString() + " CAD";
            result[2] = "Total= "+total.ToString()+" CAD";
            return result;
        }
    }
}
