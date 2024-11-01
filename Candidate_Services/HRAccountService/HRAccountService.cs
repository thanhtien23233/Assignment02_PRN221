using Candidate_BusinessObjects.Models;
using Candidate_Repositories.HRAccountRepo;

namespace Candidate_Services.HRAccountService
{
    public class HRAccountService : IHRAccountService
    {
        private HRAccountRepo repo;
        public HRAccountService()
        {
            repo = new HRAccountRepo();
        }

        public Hraccount GetHraccountByEmail(string email) => repo.GetHraccountByEmail(email);

        public List<Hraccount> GetHraccounts() => repo.GetHraccounts();
    }
}
