using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Candidate_BusinessObjects.Models;
using Candidate_Services.CandidateService;
using Candidate_Services.JobPostingService;

namespace CandidateManageWebsite.Pages.CandidateProfilePages
{
    public class EditModel : PageModel
    {
        private readonly ICandidateService candidateService;
        private readonly IJobPostingService jobPostingService;
        public EditModel(ICandidateService candidate, IJobPostingService jobPosting)
        {
            candidateService = candidate;
            jobPostingService = jobPosting;
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidateprofile =  candidateService.GetCandidateProfile(id);
            if (candidateprofile == null)
            {
                return NotFound();
            }
            CandidateProfile = candidateprofile;
            ViewData["PostingId"] = new SelectList(
     jobPostingService.GetJobPostings().Select(j => new
     {
         PostingId = j.PostingId,
         DisplayValue = $"{j.PostingId} - {j.JobPostingTitle}"
     }),
     "PostingId",
     "DisplayValue"
     );
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || candidateService.GetCandidateProfiles() == null)
            {
                return Page();
            }
            candidateService.UpdateCandidateProfile(CandidateProfile);
            return RedirectToPage("./Index");
        }
    }
}
