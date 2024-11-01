using Candidate_BusinessObjects.Models;

namespace Candidate_DAO
{
    public class HRAccountDAO
    {
        private CandidateManagementContext dbContext;

        private static HRAccountDAO instance = null;

        public static HRAccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HRAccountDAO();
                }
                return instance;
            }
        }
        public HRAccountDAO()
        {
            dbContext = new CandidateManagementContext();
        }
        public Hraccount getHraccountByEmail(string email)
        {
            return dbContext.Hraccounts.SingleOrDefault(m => m.Email.Equals(email));
        }
        public List<Hraccount> GetHraccounts()
        {
            return dbContext.Hraccounts.ToList();
        }
    }
}
