using Candidate_BusinessObjects.Models;

namespace Candidate_Services.CandidateService
{
    public interface ICandidateService
    {
        public CandidateProfile GetCandidateProfile(String candidateID);
        public List<CandidateProfile> GetCandidateProfiles();
        public List<String> GetPostingIds();
        public Boolean AddCandidateProfile(CandidateProfile candidate);
        public Boolean UpdateCandidateProfile(CandidateProfile candidate);
        public Boolean DeleteCandidateProfile(CandidateProfile candidate);
    }
}
