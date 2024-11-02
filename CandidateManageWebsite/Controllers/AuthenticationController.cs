using Candidate_Services.CandidateService;
using Candidate_Services.JobPostingService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CandidateManageWebsite.Controllers
{
    [Route("api/authetication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost("logout")]
        public IActionResult ClearSession()
        {
            HttpContext.Session.Clear();
            return new JsonResult(new { success = true, message = "Logout Successful" });
        }
    }
}
