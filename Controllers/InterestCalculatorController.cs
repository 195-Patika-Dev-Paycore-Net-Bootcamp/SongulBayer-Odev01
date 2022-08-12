using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Hafta01.Controllers
{
    //The class where the values to be calculated are kept
    public class Calculate
    {
        public double TotalBalance { get; set; }
        public double InterestAmount { get; set; }
    }
 
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Calculate> InvestCalculator([Required][Range(0, double.MaxValue)] double principal_, [Required][Range(0, double.MaxValue)] double interestRate_, [Required][Range(0, double.MaxValue)] double exppiry_)//Restrictions set for parameters we receive from the user
        {
            Calculate calculate = new Calculate();
            calculate.TotalBalance = principal_ * (Math.Pow(1 + interestRate_, exppiry_));//total balance calculation
            calculate.InterestAmount = calculate.TotalBalance - principal_;//Calculation of interest money

            return Ok(calculate);
        }

    }

}
