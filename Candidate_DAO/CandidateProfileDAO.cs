using Candidate_BusinessObjects.Models;

namespace Candidate_DAO
{
    public class CandidateProfileDAO
    {
        private CandidateManagementContext dbContext;

        public static CandidateProfileDAO instance = null;

        public static CandidateProfileDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CandidateProfileDAO();
                }
                return instance;
            }
        }
        public CandidateProfileDAO()
        {
            dbContext = new CandidateManagementContext();
        }

        public List<CandidateProfile> GetCandidateProfiles()
        {
            List<CandidateProfile> candidates = dbContext.CandidateProfiles.ToList();
            foreach (CandidateProfile candidateProfile in candidates)
            {
                candidateProfile.Posting = JobPostDAO.Instance.GetJobPosting(candidateProfile.PostingId);
            }
            return candidates;
        }

        public CandidateProfile GetCandidateProfile(String candidateID)
        {
            CandidateProfile candidate =
                dbContext.CandidateProfiles.SingleOrDefault(m => m.CandidateId.Equals(candidateID));
            if (candidate != null)
                candidate.Posting = JobPostDAO.Instance.GetJobPosting(candidate.PostingId);
            return candidate;
        }


        public List<string> GetPostingIds()
        {
            List<JobPosting> jobPostings = dbContext.JobPostings.ToList();

            List<string> formattedIds = new List<string>();

            foreach (var jobPosting in jobPostings)
            {
                formattedIds.Add($"{jobPosting.PostingId} ({jobPosting.JobPostingTitle})");
            }

            return formattedIds;
        }
        public Boolean AddCandidateProfile(CandidateProfile candidate)
        {
            bool isSuccess = false;
            CandidateProfile existingProfile = this.GetCandidateProfile(candidate.CandidateId);

            if (existingProfile == null)
            {
                dbContext.ChangeTracker.Clear();
                candidate.Posting = null;
                dbContext.CandidateProfiles.Add(candidate);
                dbContext.SaveChanges();
                isSuccess = true;
            }

            return isSuccess;
        }

        public Boolean UpdateCandidateProfile(CandidateProfile candidate)
        {
            bool isSuccess = false;
            CandidateProfile profile = this.GetCandidateProfile(candidate.CandidateId);
            if (profile != null)
            {
                dbContext.ChangeTracker.Clear();
                candidate.Posting = null;
                dbContext.CandidateProfiles.Update(candidate);
                dbContext.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public Boolean DeleteCandidateProfile(CandidateProfile candidate)
        {
            bool isSuccess = false;
            CandidateProfile profile = this.GetCandidateProfile(candidate.CandidateId);
            if (profile != null)
            {
                dbContext.ChangeTracker.Clear();
                candidate.Posting = null;
                dbContext.CandidateProfiles.Remove(candidate);
                dbContext.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }
    }
}
