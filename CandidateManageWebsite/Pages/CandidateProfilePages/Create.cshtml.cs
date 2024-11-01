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

namespace CandidateManageWebsite.Pages.CandidateProfilePages
{
    public class CreateModel : PageModel
    {
        private readonly ICandidateService candidateService;
        private readonly IJobPostingService jobPostingService;
        public CreateModel(ICandidateService candidate, IJobPostingService jobPosting)
        {
            candidateService = candidate;
            jobPostingService = jobPosting;
        }

        public IActionResult OnGet()
        {
        ViewData["PostingId"] = new SelectList(jobPostingService.GetJobPostings(), "PostingId", "PostingId");
            return Page();
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || candidateService.GetCandidateProfiles == null)
            {
                return Page();
            }

            candidateService.AddCandidateProfile(CandidateProfile);
            //await candidateService.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
