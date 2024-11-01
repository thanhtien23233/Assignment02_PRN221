using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Candidate_BusinessObjects.Models;
using Candidate_Services.JobPostingService;
using Candidate_Services.CandidateService;

namespace CandidateManageWebsite.Pages.JobPostingPages
{
    public class EditModel : PageModel
    {
        private readonly IJobPostingService _jobPostingService;

        public EditModel(IJobPostingService jobPostingService)
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
            JobPosting = jobposting;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _jobPostingService.GetJobPostings() == null)
            {
                return Page();
            }
            _jobPostingService.UpdateJobPosting(JobPosting);
            return RedirectToPage("./Index");
        }

        private bool JobPostingExists(string id)
        {
            return (_jobPostingService.GetJobPosting(id).ToString() != null);
        }
    }
}
