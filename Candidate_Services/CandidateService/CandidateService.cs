using Candidate_BusinessObjects.Models;
using Candidate_Repositories.CandidateRepo;

namespace Candidate_Services.CandidateService
{
    public class CandidateService : ICandidateService
    {
        private CandidateRepo repo;
        public CandidateService()
        {
            repo = new CandidateRepo();
        }

        public CandidateProfile GetCandidateProfile(String candidateID) => repo.getCandidateProfile(candidateID);
        public List<CandidateProfile> GetCandidateProfiles() => repo.GetCandidateProfiles();
        public List<String> GetPostingIds() => repo.GetPostingIds();
        public Boolean AddCandidateProfile(CandidateProfile candidate) => repo.AddCandidateProfile(candidate);
        public Boolean UpdateCandidateProfile(CandidateProfile candidate) => repo.UpdateCandidateProfile(candidate);
        public Boolean DeleteCandidateProfile(CandidateProfile candidate) => repo.DeleteCandidateProfile(candidate);
    }
}
