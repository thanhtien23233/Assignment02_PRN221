using Candidate_BusinessObjects.Models;
using Candidate_Repositories.JobPostingRepo;

namespace Candidate_Services.JobPostingService
{
    public class JobPostingService : IJobPostingService
    {
        private JobPostingRepo repo;
        public JobPostingService()
        {
            repo = new JobPostingRepo();
        }

        public JobPosting GetJobPosting(String id) => repo.GetJobPosting(id);
        public List<JobPosting> GetJobPostings() => repo.GetJobPostings();
        public void AddJobPosting(JobPosting jobPosting) => repo.AddJobPosting(jobPosting);
        public void UpdateJobPosting(JobPosting jobPosting) => repo.UpdateJobPosting(jobPosting);
        public void DeleteJobPosting(JobPosting jobPosting) => repo.DeleteJobPosting(jobPosting);
    }
}