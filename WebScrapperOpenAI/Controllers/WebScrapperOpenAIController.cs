using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebScrapperOpenAI.Business;
using WebScrapperOpenAI.Business.Interfaces;
using WebScrapperOpenAI.Models;

namespace WebScrapperOpenAI.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class WebScrapperOpenAIController : ControllerBase
    {

        private readonly IWebScrapper _wsOpenAIBusiness;

        public WebScrapperOpenAIController(IWebScrapper wsOpenAIBusiness)
        {
            _wsOpenAIBusiness = wsOpenAIBusiness;            
        }

        [HttpPost("CertificationStudyPlan")]
        public async Task<IActionResult> CertificationStudyPlan([FromBody] CertificationPrompt prompt)
        {
            var result = await _wsOpenAIBusiness.CertificationStudyPlan(prompt?.Certification ?? "az-900",prompt?.ScheduledDay ?? "One Month");
            return Ok(result);
        }


    }
}
