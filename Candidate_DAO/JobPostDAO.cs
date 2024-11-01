using Candidate_BusinessObjects.Models;

namespace Candidate_DAO
{
    public class JobPostDAO
    {
        private CandidateManagementContext dbContext;

        public static JobPostDAO instance = null;

        public static JobPostDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JobPostDAO();
                }
                return instance;
            }
        }
        public JobPostDAO()
        {
            dbContext = new CandidateManagementContext();
        }

        public List<JobPosting> GetJobPostings()
        {
            return dbContext.JobPostings.ToList();
        }
        public JobPosting GetJobPosting(String id)
        {
            return dbContext.JobPostings.SingleOrDefault(m => m.PostingId.Equals(id));
        }
        public void AddJobPosting(JobPosting jobPosting)
        {
            dbContext.JobPostings.Add(jobPosting);
            dbContext.SaveChanges();
        }
        public void UpdateJobPosting(JobPosting jobPosting)
        {
            dbContext.ChangeTracker.Clear();
            dbContext.JobPostings.Update(jobPosting);
            dbContext.SaveChanges();
        }
        public void DeleteJobPosting(JobPosting jobPosting)
        {
            dbContext.ChangeTracker.Clear();
            dbContext.JobPostings.Remove(jobPosting);
            dbContext.SaveChanges();
        }
    }
}
