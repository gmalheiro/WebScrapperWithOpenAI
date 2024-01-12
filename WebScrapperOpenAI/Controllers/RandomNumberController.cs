using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebScrapperOpenAI.Business.Interfaces;

namespace WebScrapperOpenAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomNumberController : ControllerBase
    {

        private readonly IRandomNumberBusiness _randomNumberBusiness;

        public RandomNumberController(IRandomNumberBusiness randomNumberBusiness)
        {
            _randomNumberBusiness = randomNumberBusiness;
        }

        [HttpGet]
        [Route("returnRandomNumber")]
        public ActionResult returnRandomNumber()
        {
           var randomNumber = _randomNumberBusiness.GenerateRandomNumber();
           return Ok(randomNumber);
        }
    }
}
