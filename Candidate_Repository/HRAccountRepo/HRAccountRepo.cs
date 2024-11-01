using Candidate_BusinessObjects.Models;
using Candidate_DAO;

namespace Candidate_Repositories.HRAccountRepo
{
    public class HRAccountRepo : IHRAccountRepo
    {
        public Hraccount GetHraccountByEmail(string email) => HRAccountDAO.Instance.getHraccountByEmail(email);

        public List<Hraccount> GetHraccounts() => HRAccountDAO.Instance.GetHraccounts();
    }
}
