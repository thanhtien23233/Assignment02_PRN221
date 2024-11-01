using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Candidate_BusinessObjects.Models;
using Candidate_Services.JobPostingService;

namespace CandidateManageWebsite.Pages.JobPostingPages
{
    public class DeleteModel : PageModel
    {
        private readonly IJobPostingService _jobPostingService;

        public DeleteModel(IJobPostingService jobPostingService)
        {
            _jobPostingService = jobPostingService;
        }

        [BindProperty]
        public JobPosting JobPosting { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobposting = _jobPostingService.GetJobPosting(id);

            if (jobposting == null)
            {
                return NotFound();
            }
            else
            {
                _jobPostingService.DeleteJobPosting(jobposting);
            }
            return new JsonResult(new { success = true, message = "Delete Successful" });
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            //if (string.IsNullOrEmpty(id))
            //{
            //    return NotFound(new { success = false, message = "Invalid ID" });
            //}

            //var jobposting = _jobPostingService.GetJobPosting(id);
            //if (jobposting == null)
            //{
            //    return NotFound(new { success = false, message = "Job posting not found" });
            //}


            return new JsonResult(new { success = true, message = "Post Successful" });
        }
    }
}
