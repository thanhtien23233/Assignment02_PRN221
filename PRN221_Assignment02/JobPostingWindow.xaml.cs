using Candidate_BusinessObjects.Models;
using Candidate_Services.JobPostingService;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace PRN221PE_FA22_TrialTest
{
    /// <summary>
    /// Interaction logic for JobPostingWindow.xaml
    /// </summary>
    public partial class JobPostingWindow : Window
    {
        private JobPostingService service;
        public JobPostingWindow(int? roleID)
        {
            InitializeComponent();
            service = new JobPostingService();
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
            List<JobPosting> jobPostings = service.GetJobPostings();
            dg_JobPosting.ItemsSource = jobPostings;
            foreach (var column in dg_JobPosting.Columns)
            {
                if (column.Header.ToString() == "CandidateProfiles")
                {
                    column.Visibility = Visibility.Collapsed;
                }
            }
        }
        private void ClearData()
        {
            txt_PostingID.Text = string.Empty;
            txt_Title.Text = string.Empty;
            txt_Description.Text = string.Empty;
        }
        private JobPosting GetDataFromForm()
        {
            JobPosting jobPosting = new JobPosting();
            jobPosting.PostingId = txt_PostingID.Text;
            jobPosting.JobPostingTitle = txt_Title.Text;
            jobPosting.Description = txt_Description.Text;
            //if (dpk_PostedDate.SelectedDate.Value.Date.Equals(null))
            jobPosting.PostedDate = DateTime.Now;
            //else jobPosting.PostedDate = dpk_PostedDate.SelectedDate.Value.Date;
            return jobPosting;
        }

        private String ValidateData(JobPosting jobPosting, String type)
        {
            String result = "";
            if (jobPosting.PostingId.Equals(""))
                result = "PostingID null!!\n";
            else if (!Regex.Match(
                    jobPosting.PostingId,
                    @"P[0-9][0-9][0-9][0-9]", RegexOptions.IgnoreCase).Success)
                result = "Wrong ID format!! (Pxxxx)\n";
            else
            {
                List<JobPosting> jobPostings = service.GetJobPostings();
                for (int i = 0; i < jobPostings.Count; i++)
                {
                    JobPosting jobPosting1 = jobPostings[i];
                    if (jobPosting.PostingId.Equals(jobPosting1.PostingId)
                        && type.Equals("Add"))
                        result = "ID Exist!!\n";
                }
            }
            if ((result.Equals("ID exist!!\n") && type.Equals("Update")) ||
            (result.Equals("ID exist!!\n") && type.Equals("Remove")))
                result = "ID Not Exist!!";
            if (jobPosting.JobPostingTitle.Equals(""))
                result = result + "JobPostingTitle null!!";
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
            JobPosting jobPosting = GetDataFromForm();
            string message = ValidateData(jobPosting, "Add");
            if (!message.Equals("Ready to Add"))
            {
                MessageBox.Show(message);
            }
            else if (message.Equals("Ready to Add"))
            {
                MessageBox.Show("Added !!");
                service.AddJobPosting(jobPosting);
                ClearData();
                RefreshData();
            }
        }

        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            JobPosting jobPosting = GetDataFromForm();
            string message = ValidateData(jobPosting, "Update");
            if (!message.Equals("Ready to Update"))
            {
                MessageBox.Show(message);
            }
            else if (message.Equals("Ready to Update"))
            {
                MessageBox.Show("Updated !!");
                service.UpdateJobPosting(jobPosting);
                ClearData();
                RefreshData();
            }

        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            JobPosting jobPosting = GetDataFromForm();
            string message = ValidateData(jobPosting, "Remove");
            if (!message.Equals("Ready to Remove"))
            {
                MessageBox.Show(message);
            }
            else if (message.Equals("Ready to Remove"))
            {
                MessageBox.Show("Deleted !!");
                service.DeleteJobPosting(jobPosting);
                ClearData();
                RefreshData();
            }
        }


        private void dg_JobPosting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            JobPosting job = dg_JobPosting.SelectedItem as JobPosting;
            if (job != null)
            {
                txt_PostingID.Text = job.PostingId;
                txt_Description.Text = job.Description;
                txt_Title.Text = job.JobPostingTitle;
            }
        }
        private void btn_Refresh_Click(object sender, RoutedEventArgs e)
        {
            ClearData();
            RefreshData();
        }
    }
}
