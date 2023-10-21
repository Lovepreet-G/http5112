using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2.Controllers
{
    public class problem3Controller : ApiController
    {
        ///cemc.math.uwaterloo.ca/contests/computing/past_ccc_contests/2021/ccc/juniorEF.pdf
        /// j3 junior problem of 2021 
        /// <summary>
        /// Receive the string value of instruction->number 
        /// Output the direction and steps.
        /// </summary>
        /// <param name="number">The input of intruction</param>
        /// <returns>direction and number of steps to take in that direction</returns>
        /// <example>
        /// Get api/problem3/checkdirection/55273 -> Right 273
        /// Get api/problem3/checkdirection/56123 -> Left 123
        /// Get api/problem3/checkdirection/00258 -> Same as the previous instruction 258
        /// </example>
        [HttpGet]
        [Route("api/problem3/checkdirection/{instruction}")]
        public String checkDirection(string instruction)
        {
            string msg;
            int firstDigit;
            int secondDigit;
            int lastThreeDigits;
            int sum;
            string direction ="";
            

            firstDigit = int.Parse(instruction.Substring(0, 1));
            secondDigit = int.Parse(instruction.Substring(1, 1));
            lastThreeDigits = int.Parse(instruction.Substring(2, 3));

            sum = firstDigit + secondDigit;
            if(sum%2 == 1)
            {
                direction = "Left";
            }
            else if(sum%2==0 && sum != 0)
            {
                direction = "Right";
            }
            else if( sum == 0)
            {
                direction = "Same as the previous instruction";
            }

            msg = direction + " " + lastThreeDigits;
            
            return msg;
        }

    }
}
