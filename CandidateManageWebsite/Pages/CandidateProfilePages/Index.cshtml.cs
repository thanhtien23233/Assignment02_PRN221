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
    public class IndexModel : PageModel
    {
        private readonly ICandidateService candidateService;

        public IndexModel(ICandidateService candidate)
        {
            candidateService = candidate;
        }

        public IList<CandidateProfile> CandidateProfile { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (candidateService.GetCandidateProfiles() != null)
            {
                 CandidateProfile = candidateService.GetCandidateProfiles();
            }
        }
    }
}
