using Candidate_BusinessObjects.Models;

namespace Candidate_Services.JobPostingService
{
    public interface IJobPostingService
    {
        public List<JobPosting> GetJobPostings();
        public JobPosting GetJobPosting(String id);
        public void AddJobPosting(JobPosting jobPosting);
        public void UpdateJobPosting(JobPosting jobPosting);
        public void DeleteJobPosting(JobPosting jobPosting);
    }
}
