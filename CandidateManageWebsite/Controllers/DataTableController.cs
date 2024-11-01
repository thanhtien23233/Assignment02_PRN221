using Candidate_Services.JobPostingService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CandidateManageWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataTableController : ControllerBase
    {
        private readonly IJobPostingService _jobPostingService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DataTableController(IJobPostingService jobPostingService, IWebHostEnvironment webHostEnvironment)
        {
            _jobPostingService = jobPostingService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("get-jobPostings")]
        public IActionResult GetProducts()
        {
            var jobPostings = _jobPostingService.GetJobPostings().ToList();
            return new JsonResult(new { data = jobPostings });
        }

        [HttpDelete("jobPostings")]
        public IActionResult DeleteProducts(string id)
        {
            var jobPostingToBeDeleted = _jobPostingService.GetJobPosting(id);
            if (jobPostingToBeDeleted == null)
            {
                return new JsonResult(new { success = false, message = "error while deleting" });
            }

            //delete product
            _jobPostingService.DeleteJobPosting(jobPostingToBeDeleted);
            return new JsonResult(new { success = true, message = "Delete Successful" });
        }

    }
}
