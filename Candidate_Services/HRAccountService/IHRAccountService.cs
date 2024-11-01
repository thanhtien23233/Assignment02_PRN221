using Candidate_BusinessObjects.Models;

namespace Candidate_Services.HRAccountService
{
    public interface IHRAccountService
    {
        public Hraccount GetHraccountByEmail(string email);

        public List<Hraccount> GetHraccounts();
    }
}
