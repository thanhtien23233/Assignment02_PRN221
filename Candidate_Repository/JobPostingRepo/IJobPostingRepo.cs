using Candidate_BusinessObjects.Models;

namespace Candidate_Repositories.JobPostingRepo
{
    public interface IJobPostingRepo
    {
        public List<JobPosting> GetJobPostings();
        public JobPosting GetJobPosting(String id);
        public void AddJobPosting(JobPosting jobPosting);
        public void UpdateJobPosting(JobPosting jobPosting);
        public void DeleteJobPosting(JobPosting jobPosting);
    }
}
