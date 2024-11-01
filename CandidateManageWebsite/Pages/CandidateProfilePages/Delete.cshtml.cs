using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Candidate_BusinessObjects.Models;
using Candidate_Services.CandidateService;

namespace CandidateManageWebsite.Pages.CandidateProfilePages
{
    public class DeleteModel : PageModel
    {
        private readonly ICandidateService _candidateService;

        public DeleteModel(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidateprofile = _candidateService.GetCandidateProfile(id);

            if (candidateprofile == null)
            {
                return NotFound();
            }
            else
            {
                CandidateProfile = candidateprofile;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidateprofile = _candidateService.GetCandidateProfile(id);
            if (candidateprofile != null)
            {
                CandidateProfile = candidateprofile;
                _candidateService.DeleteCandidateProfile(candidateprofile);
            }

            return RedirectToPage("./Index");
        }
    }
}
