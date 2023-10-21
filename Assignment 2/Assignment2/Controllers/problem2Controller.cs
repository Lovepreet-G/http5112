using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2.Controllers
{

    public class problem2Controller : ApiController
    {
        /// <summary>
        /// Receive the integer value of side of dice->m,n 
        /// Output the total number of ways to get the sum 10.
        /// </summary>
        /// <param name="m">The input integer of choice of sides of dice 1</param>
        /// <param name="n">The input integer of choice of sides of dice 2</param>
        /// 
        /// <returns>Number of total ways to get the sum 10 by checking the sum of m and n</returns>
        /// <example>
        /// Get api/problem2/DiceGame/5/5 -> There are 5 total ways to get the sum 10
        /// Get api/problem2/DiceGame/12/4 -> There are 4 total ways to get the sum 10
        /// Get api/problem2/DiceGame/3/3 -> There are 0 total ways to get the sum 10
        /// Get api/problem2/DiceGame/5/5 -> There are 1 total ways to get the sum 10
        /// Get api/problem2/DiceGame/8/5 -> There are 4 total ways to get the sum 10
        /// </example>
        [HttpGet]
        [Route("api/problem2/DiceGame/{m}/{n}")]
        public String DiceGame(int m,int n)
        {
            int ways = 0;
            string msg;

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    var temp = i + j;
                    if (temp == 10)
                    {
                        ways++;
                    }
                }
            }
            msg = "There are " + ways + " total ways to get the sum 10.";
            return msg;
        }
    }
}
