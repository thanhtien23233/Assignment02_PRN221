using Candidate_BusinessObjects.Models;

namespace Candidate_Repositories.CandidateRepo
{
    public interface ICandidateRepo
    {
        public List<CandidateProfile> GetCandidateProfiles();
        public Boolean AddCandidateProfile(CandidateProfile candidate);
        public Boolean UpdateCandidateProfile(CandidateProfile candidate);
        public List<String> GetPostingIds();
        public Boolean DeleteCandidateProfile(CandidateProfile candidate);
    }
}
