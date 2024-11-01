using Candidate_BusinessObjects.Models;
using Candidate_DAO;

namespace Candidate_Repositories.CandidateRepo
{
    public class CandidateRepo : ICandidateRepo
    {
        public CandidateProfile getCandidateProfile(string candidateID) => CandidateProfileDAO.Instance.GetCandidateProfile(candidateID);
        public List<CandidateProfile> GetCandidateProfiles() => CandidateProfileDAO.Instance.GetCandidateProfiles();
        public List<String> GetPostingIds() => CandidateProfileDAO.Instance.GetPostingIds();
        public Boolean AddCandidateProfile(CandidateProfile candidate) => CandidateProfileDAO.Instance.AddCandidateProfile(candidate);
        public Boolean UpdateCandidateProfile(CandidateProfile candidate) => CandidateProfileDAO.Instance.UpdateCandidateProfile(candidate);
        public Boolean DeleteCandidateProfile(CandidateProfile candidate) => CandidateProfileDAO.Instance.DeleteCandidateProfile(candidate);
    }
}
