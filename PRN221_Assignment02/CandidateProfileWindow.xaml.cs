using Candidate_BusinessObjects.Models;
using Candidate_DAO;
using Candidate_Services.CandidateService;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;


namespace PRN221PE_FA22_TrialTest
{
    /// <summary>
    /// Interaction logic for CandidateProfileWindow.xaml
    /// </summary>
    public partial class CandidateProfileWindow : Window
    {
        private CandidateService service;
        public CandidateProfileWindow(int? roleID)
        {
            InitializeComponent();
            service = new CandidateService();
            RefreshData();
            switch (roleID)
            {
                case 1:
                    break;
                case 2:
                    btn_Add.IsEnabled = false;
                    break;
                case 3:
                    btn_Add.IsEnabled = false;
                    btn_Update.IsEnabled = false;
                    btn_Delete.IsEnabled = false;
                    break;
            }
        }
        private void RefreshData()
        {
            List<CandidateProfile> candidates = service.GetCandidateProfiles();
            dg_CandidateProfile.ItemsSource = MapCandidateToDisplayDTO(candidates);
            cbb_PostingID.ItemsSource = service.GetPostingIds();
        }
        public List<CandidateDisplay> MapCandidateToDisplayDTO(List<CandidateProfile> candidates)
        {
            List<CandidateDisplay> displayCandidates = new List<CandidateDisplay>();

            foreach (var candidateProfile in candidates)
            {
                var posting = JobPostDAO.Instance.GetJobPosting(candidateProfile.PostingId);
                displayCandidates.Add(new CandidateDisplay
                {
                    CandidateId = candidateProfile.CandidateId,
                    Fullname = candidateProfile.Fullname,
                    Birthday = candidateProfile.Birthday,
                    ProfileShortDescription = candidateProfile.ProfileShortDescription,
                    ProfileUrl = candidateProfile.ProfileUrl,
                    PostingDisplay = posting != null ? $"{posting.PostingId} ({posting.JobPostingTitle})" : "N/A"
                });
            }
            return displayCandidates;
        }
        private void ClearData()
        {
            txt_CandidateID.Text = string.Empty;
            txt_FullName.Text = string.Empty;
            cbb_PostingID.Text = string.Empty;
            txt_ProfileURL.Text = string.Empty;
            txt_ShortDescription.Text = string.Empty;
            dpk_Birthday.Text = string.Empty;
        }
        private CandidateProfile GetDataFromForm()
        {
            CandidateProfile candidate = new CandidateProfile();
            candidate.Posting = new JobPosting();
            candidate.CandidateId = txt_CandidateID.Text;
            candidate.Fullname = txt_FullName.Text;
            candidate.Birthday = dpk_Birthday.SelectedDate;
            candidate.ProfileShortDescription = txt_ShortDescription.Text;
            candidate.ProfileUrl = txt_ProfileURL.Text;
            candidate.PostingId = cbb_PostingID.Text.Split('(')[0].Trim();
            return candidate;
        }
        private String ValidateData(CandidateProfile candidate, String type)
        {
            String result = "";
            if (candidate.CandidateId.Equals(""))
                result = "CandidateID null!!\n";
            else if (!Regex.Match(
                    candidate.CandidateId,
                    @"CANDIDATE[0-9][0-9][0-9][0-9]", RegexOptions.IgnoreCase).Success)
                result = "Wrong ID format!! (CANDIDATExxxx)\n";
            else
            {
                List<CandidateProfile> candidates = service.GetCandidateProfiles();
                for (int i = 0; i < candidates.Count; i++)
                {
                    CandidateProfile candidate1 = candidates[i];
                    if (candidate.CandidateId.Equals(candidate1.CandidateId)
                        && type.Equals("Add"))
                        result = "ID Exist!!\n";
                }
            }
            if ((result.Equals("ID exist!!\n") && type.Equals("Update")) ||
                (result.Equals("ID exist!!\n") && type.Equals("Remove")))
                result = "ID Not Exist!!";
            if (candidate.Fullname.Equals(""))
                result = result + "FullName null!!";
            if (result.Equals("")) result = "Ready to " + type;
            return result;
        }
        //-------------------------Button Behaviors-------------------------
        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            CandidateProfile candidate = GetDataFromForm();
            string message = ValidateData(candidate, "Add");
            if (!message.Equals("Ready to Add"))
            {
                MessageBox.Show(message);
            }

            else if (message.Equals("Ready to Add") || service.AddCandidateProfile(candidate))
            {
                service.AddCandidateProfile(candidate);
                MessageBox.Show("Added !!");
                ClearData();
                RefreshData();
            }
        }
        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            CandidateProfile candidate = GetDataFromForm();
            string message = ValidateData(candidate, "Update");
            if (!message.Equals("Ready to Update"))
            {
                MessageBox.Show(message);
            }

            else if (message.Equals("Ready to Update") || service.UpdateCandidateProfile(candidate))
            {
                service.UpdateCandidateProfile(candidate);
                MessageBox.Show("Updated !!");
                ClearData();
                RefreshData();
            }
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            CandidateProfile candidate = GetDataFromForm();
            string message = ValidateData(candidate, "Remove");
            if (!message.Equals("Ready to Remove"))
            {
                MessageBox.Show(message);
            }

            else if (message.Equals("Ready to Remove") || service.DeleteCandidateProfile(candidate))
            {
                service.DeleteCandidateProfile(candidate);
                MessageBox.Show("Deleted !!");
                ClearData();
                RefreshData();
            }
        }

        private void dg_CandidateProfile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CandidateDisplay selectedDisplay = dg_CandidateProfile.SelectedItem as CandidateDisplay;

            if (selectedDisplay != null)
            {
                CandidateProfile profile = service.GetCandidateProfiles().FirstOrDefault(p => p.CandidateId == selectedDisplay.CandidateId);

                if (profile != null)
                {
                    txt_CandidateID.Text = profile.CandidateId;
                    txt_FullName.Text = profile.Fullname;
                    txt_ProfileURL.Text = profile.ProfileUrl;
                    txt_ShortDescription.Text = profile.ProfileShortDescription;
                    dpk_Birthday.SelectedDate = profile.Birthday;
                    cbb_PostingID.Text = selectedDisplay.PostingDisplay.ToString();
                }
            }
        }
        private void btn_Refresh_Click(object sender, RoutedEventArgs e)
        {
            ClearData();
            RefreshData();
        }
    }
}
