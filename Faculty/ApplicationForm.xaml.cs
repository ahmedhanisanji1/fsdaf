using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

namespace Faculty
{
    /// <summary>
    /// Interaction logic for ApplicationForm.xaml
    /// </summary>
    public partial class ApplicationForm : Page
    {
        FacultyEntities db = new FacultyEntities();
        int studId;
        public ApplicationForm(int id)
        {
            InitializeComponent();
            studId = id;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var stud = db.Students.FirstOrDefault(x=> x.Id == studId);
            if(stud != null)
            {
                var dep = db.Departments.FirstOrDefault(d => d.DepName == depText.Text);
                if (dep != null)
                {
                    stud.Name = nameTxt.Text;
                    stud.Address = addTxt.Text;
                    stud.Age = int.Parse(ageTxt.Text);
                    stud.DepId = dep.Id;
                    db.Students.AddOrUpdate(stud);
                    db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Dep Not Vaild");
                }
                
            
            }

        }
    }
}
