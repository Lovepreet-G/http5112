using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2.Controllers
{
    public class problem1Controller : ApiController
    {
        /// <summary>
        /// Receive the integer value of choices of food->burger,drink,side,dessert 
        /// Output the total calories by adding the calories of each choices
        /// </summary>
        /// <param name="burger">The input integer of choice of burger</param>
        /// <param name="drink">The input integer of choice of drink</param>
        /// <param name="sideorder">The input integer of choice of side</param>
        /// <param name="dessert">The input integer of choice of dessert</param>
        /// <returns>The total calories of all the choice by adding the calories of each choices</returns>
        /// <example>
        /// Get api/problem1/menuItems/1/2/3/4 -> Your total calorie count is 691
        /// Get api/problem1/menuItems/0/0/0/0 -> Your total calorie count is 0
        /// Get api/problem1/menuItems/1/4/3/2 -> Your total calorie count is 797
        /// </example>

        [HttpGet]
        [Route("api/problem1/menuItems/{burger}/{drink}/{sideorder}/{dessert}")]
        public string menuItems(int burger, int drink, int sideorder, int dessert)
        {
            int burgercalories;
            int drinkcalories;
            int sideordercalories;
            int dessertcalories;
            int totalCalories;
            string msg;

            switch (burger)
            {
                case 1:
                    burgercalories = 461;
                    break;
                case 2:
                    burgercalories = 431;
                    break;
                case 3:
                    burgercalories = 420;
                    break;
                default:
                    burgercalories = 0;
                    break;
            }

            switch (drink)
            {
                case 1:
                    drinkcalories = 130;
                    break;
                case 2:
                    drinkcalories = 160;
                    break;
                case 3:
                    drinkcalories = 118;
                    break;
                default:
                    drinkcalories = 0;
                    break;
            }

            switch (sideorder)
            {
                case 1:
                    sideordercalories = 100;
                    break;
                case 2:
                    sideordercalories = 57;
                    break;
                case 3:
                    sideordercalories = 70;
                    break;
                default:
                    sideordercalories = 0;
                    break;
            }
            switch (dessert)
            {
                case 1:
                    dessertcalories = 167;
                    break;
                case 2:
                    dessertcalories = 266;
                    break;
                case 3:
                    dessertcalories = 75;
                    break;
                default:
                    dessertcalories = 0;
                    break;
            }

            totalCalories = burgercalories + drinkcalories + sideordercalories + dessertcalories;
            msg = "Your total calorie count is " + totalCalories;
            return msg;
        }
    }
}
