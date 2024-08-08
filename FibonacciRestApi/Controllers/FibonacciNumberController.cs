using FibonacciRestApi.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FibonacciRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FibonacciNumberController : ControllerBase
    {
        private readonly IFibonacciNumberService fibonacciNumberService;

        public FibonacciNumberController(IFibonacciNumberService fibonacciNumberService)
        {
            this.fibonacciNumberService = fibonacciNumberService;
        }

        [HttpGet(Name = "GetFibonacciNumber")]
        public async Task<IActionResult> Get(int n)
        {
            if (n < 0)
            {
                return BadRequest($"{n} - is not a valid value, n cannot be less than zero");
            }
            var number = await fibonacciNumberService.GetFibonacciNumber(n);
            return Ok(number);
        }
    }
}
