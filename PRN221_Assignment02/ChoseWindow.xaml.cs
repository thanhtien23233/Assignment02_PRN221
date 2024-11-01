using System.Windows;

namespace PRN221PE_FA22_TrialTest
{
    /// <summary>
    /// Interaction logic for ChoseWindow.xaml
    /// </summary>
    public partial class ChoseWindow : Window
    {
        int? roleId = 0;
        public ChoseWindow(int? roleID)
        {
            InitializeComponent();

            this.roleId = roleID;
        }

        private void btn_JobPosting_Click(object sender, RoutedEventArgs e)
        {
            JobPostingWindow jobPostingWindow = new JobPostingWindow(roleId);
            jobPostingWindow.Show();
        }

        private void btn_CandidateProfile_Click(object sender, RoutedEventArgs e)
        {
            CandidateProfileWindow candidateProfileWindow = new CandidateProfileWindow(roleId);
            candidateProfileWindow.Show();
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btn_Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow loginWindow = new MainWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
