using System.Linq;
using System.Windows;
using System.Windows.Controls;

using System.Data.Entity.Migrations;
using System.Data.Entity;

namespace Faculty
{

    public partial class AdminPage : Page
    {
        FacultyEntities db = new FacultyEntities();
        public AdminPage()
        {
            InitializeComponent();
            var studList = db.Students.Include(x=> x.Department)
                .Select(s => new { s.Id, s.Name, s.Address, s.Department.DepName })
                .ToList();
            dg.ItemsSource = studList;
        }

        // Search
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dep = db.Departments.FirstOrDefault(x => x.DepName == combo.Text);
            if(dep == null || combo.Text == "All")
            {
                var studList = db.Students.Include(d => d.Department)
                                    .Where(x => x.Name.Contains(searchByName.Text))
                                    .Select(s => new { s.Id, s.Name, s.Address, s.Department.DepName }).ToList();
                dg.ItemsSource = studList;

            }
            else
            {
                var studList = db.Students.Include(d => d.Department)
                                    .Where(x => x.Name == searchByName.Text || x.DepId == dep.Id)
                                    .Select(s => new { s.Id, s.Name, s.Address, s.Department.DepName }).ToList();
                dg.ItemsSource = studList;
            }

        }
        
        // Update
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var id = int.Parse(idTxt.Text);
            var stud = db.Students.FirstOrDefault(x => x.Id ==  id); 
            // If condition
            var dep= db.Departments.FirstOrDefault(x => x.DepName == depTxt.Text);
            // If condition
            stud.DepId = dep.Id;
            db.Students.AddOrUpdate(stud);
            db.SaveChanges();

            var studList = db.Students.Include(s => s.Department)
                .Select(s => new { s.Id, s.Name, s.Address, s.Department.DepName })
                .ToList();
            dg.ItemsSource = studList;
        }

        private void combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
