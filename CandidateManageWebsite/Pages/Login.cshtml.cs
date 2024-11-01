using Candidate_BusinessObjects.Models;
using Candidate_Services.CandidateService;
using Candidate_Services.HRAccountService;
using Candidate_Services.JobPostingService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CandidateManageWebsite.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IHRAccountService hRAccountService;
        public void OnGet()
        {
        }
        public LoginModel(IHRAccountService hRAccount)
        {
            hRAccountService = hRAccount;
        }
        public void OnPost()
        {
            
            String email = Request.Form["txtEmail"];
            String password = Request.Form["txtPassword"]; 
            

            Hraccount hraccount = hRAccountService.GetHraccountByEmail(email);
            if ((hraccount != null)
                && hraccount.Email.Equals(email)
                && hraccount.Password.Equals(password))
            {
                HttpContext.Session.SetString("RoleID",hraccount.MemberRole.ToString());
                Response.Redirect("/CandidateProfilePages");
            }
            else Response.Redirect("/Error");
        }
    }
}
