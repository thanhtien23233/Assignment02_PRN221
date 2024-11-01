using Candidate_BusinessObjects.Models;

namespace Candidate_Repositories.HRAccountRepo
{
    public interface IHRAccountRepo
    {
        public Hraccount GetHraccountByEmail(string email);
        public List<Hraccount> GetHraccounts();
    }
}
