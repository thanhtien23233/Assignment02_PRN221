using Candidate_Services.CandidateService;
using Candidate_Services.JobPostingService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CandidateManageWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataTableController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        private readonly IJobPostingService _jobPostingService;

        public DataTableController(ICandidateService candidateService,
            IJobPostingService jobPostingService)
        {
            _candidateService = candidateService;
            _jobPostingService = jobPostingService;
        }

        [HttpGet("get-jobPostings")]
        public IActionResult GetJobPostings()
        {
            var jobPostings = _jobPostingService.GetJobPostings().ToList();
            return new JsonResult(new { data = jobPostings });
        }

        [HttpGet("get-candidateProfiles")]
        public IActionResult GetCandidateProfiles()
        {
            var candidateProfiles = _candidateService.GetCandidateProfiles().ToList();
            return new JsonResult(new { data = candidateProfiles });
        }

        [HttpDelete("candidateProflie")]
        public IActionResult DeleteProducts(string id)
        {
            var candidateProflieToBeDeleted = _candidateService.GetCandidateProfile(id);
            if (candidateProflieToBeDeleted == null)
            {
                return new JsonResult(new { success = false, message = "error while deleting" });
            }

            _candidateService.DeleteCandidateProfile(candidateProflieToBeDeleted);
            return new JsonResult(new { success = true, message = "Delete Successful" });
        }

        [HttpDelete("jobPosting")]
        public IActionResult DeleteJobPosting(string id)
        {
            var jobPostingToBeDeleted = _jobPostingService.GetJobPosting(id);
            if (jobPostingToBeDeleted == null)
            {
                return new JsonResult(new { success = false, message = "error while deleting" });
            }

            _jobPostingService.DeleteJobPosting(jobPostingToBeDeleted);
            return new JsonResult(new { success = true, message = "Delete Successful" });
        }

    }
}
