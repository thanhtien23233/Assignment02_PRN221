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
    public class IndexModel : PageModel
    {
        private readonly IJobPostingService _jobPostingService;

        public IndexModel(IJobPostingService jobPostingService)
        {
            _jobPostingService = jobPostingService;
        }

        public IList<JobPosting> JobPosting { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_jobPostingService.GetJobPostings() != null)
            {
                JobPosting = _jobPostingService.GetJobPostings();
            }
        }
    }
}
