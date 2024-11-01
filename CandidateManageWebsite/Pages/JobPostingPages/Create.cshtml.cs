using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Candidate_BusinessObjects.Models;
using Candidate_Services.CandidateService;
using Candidate_Services.JobPostingService;

namespace CandidateManageWebsite.Pages.JobPostingPages
{
    public class CreateModel : PageModel
    {
        private readonly IJobPostingService _jobPostingService;

        public CreateModel(IJobPostingService jobPostingService)
        {
            _jobPostingService = jobPostingService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public JobPosting JobPosting { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _jobPostingService.AddJobPosting(JobPosting);
            return RedirectToPage("./Index");
        }
    }
}
