using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace Faculty
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        FacultyEntities db = new FacultyEntities();
        public Login()
        {
            InitializeComponent();
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            SignUp signUp = new SignUp();
            NavigationService.Navigate(signUp);

        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (emailTxt.Text == "admin" && passText.Text == "admin")
            {
                AdminPage adminPage = new AdminPage();
                NavigationService.Navigate(adminPage);
            }
            else
            {
                var stud = db.Students.FirstOrDefault(x=> x.Email == emailTxt.Text && x.Password == passText.Text);
                if (stud != null)
                {
                    ApplicationForm application = new ApplicationForm(stud.Id);
                    NavigationService.Navigate(application);
                }
                else
                    MessageBox.Show("Faild");
            
            }


            /*var stud = db.Students.FirstOrDefault(x=> x.Email == emailTxt.Text);
            

            
            if (emailTxt.Text == "admin" && passText.Text == "admin")
            {
                AdminPage adminPage = new AdminPage();
                NavigationService.Navigate(adminPage);

            }
            else if(stud!=null && stud.Password == passText.Text)
            {
                ApplicationForm application = new ApplicationForm();
                NavigationService.Navigate(application);
            }
            else
            {
                MessageBox.Show("Incorrect yousername or password");
            }*/
        }
    }
}
