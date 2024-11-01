using Candidate_BusinessObjects.Models;
using Candidate_DAO;

namespace Candidate_Repositories.JobPostingRepo
{
    public class JobPostingRepo : IJobPostingRepo
    {
        public void AddJobPosting(JobPosting jobposting) => JobPostDAO.Instance.AddJobPosting(jobposting);
        public List<JobPosting> GetJobPostings() => JobPostDAO.Instance.GetJobPostings();
        public JobPosting GetJobPosting(String id) => JobPostDAO.Instance.GetJobPosting(id);
        public void UpdateJobPosting(JobPosting jobPosting) => JobPostDAO.Instance.UpdateJobPosting(jobPosting);
        public void DeleteJobPosting(JobPosting jobPosting) => JobPostDAO.Instance.DeleteJobPosting(jobPosting);

    }
}
