using Candidate_BusinessObjects.Models;
using Candidate_Services.HRAccountService;
using System.Windows;

namespace PRN221PE_FA22_TrialTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HRAccountService IAccountService;
        public MainWindow()
        {
            InitializeComponent();
            IAccountService = new HRAccountService();
            //txt_Email.Text = "admin@hr.com.vn";
            //pb_Password.Password = "123@";
        }

        private void Btn_Login_Click(object sender, RoutedEventArgs e)
        {
            Hraccount hraccount = IAccountService.GetHraccountByEmail(txt_Email.Text);
            if ((hraccount != null)
                && txt_Email.Text.Equals(hraccount.Email)
                && pb_Password.Password.Equals(hraccount.Password))
            {
                MessageBox.Show("Welcome " + hraccount.FullName);
                ChoseWindow choseWindow = new ChoseWindow(hraccount.MemberRole);
                choseWindow.Show();
                this.Close();
            }
            else MessageBox.Show("Invalid Login!!!");
        }
        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}