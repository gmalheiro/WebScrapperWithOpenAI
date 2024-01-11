using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebScrapperOpenAI.Business;

namespace WebScrapperOpenAI.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class WebScrapperOpenAIController : ControllerBase
    {

        private readonly WebScrapperOpenAIBusiness _wsOpenAIBusiness;

        public WebScrapperOpenAIController(WebScrapperOpenAIBusiness wsOpenAIBusiness)
        {
            _wsOpenAIBusiness = wsOpenAIBusiness;            
        }

        [HttpPost]
        public async Task<IActionResult> CertificationStudyPlan([FromBody] string certification)
        {
            var result = await _wsOpenAIBusiness.CertificationStudyPlan(certification);
            return Ok(result);
        }


    }
}
