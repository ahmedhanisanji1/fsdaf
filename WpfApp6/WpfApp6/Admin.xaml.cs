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
using System.Data.Entity.Migrations;

namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        bookEntities db = new bookEntities();

        string catNa;

        public Admin(string cat)
        {
            InitializeComponent();

            loadbook(cat);

            catNa = cat;
        }
        public void loadbook(string ca)
        {
            category cate = new category();

            cate = db.categories.Where(x => x.categoryName == ca).FirstOrDefault();

            if (cate == null) {

                MessageBox.Show("Error");
                return;
            }

            int idu = cate.id;

            DG.ItemsSource = db.books.Where(x => x.CategoryID == idu).Select(x => new { x.ID, x.names, x.BookAuthor }).ToList();
        }

 
        private void Add_butt(object sender, RoutedEventArgs e)
        {
            book b = new book();

            b.names = nametxt.Text;
            b.BookAuthor = authortxt.Text;
            b.CategoryID = int.Parse(authortxt_Copy.Text);

            db.books.Add(b);

            db.SaveChanges();
            MessageBox.Show("Data added succefully");

            loadbook(catNa);

        }

        private void Update_butt(object sender, RoutedEventArgs e)
        {

            book b = new book();
            int idu = int.Parse(idtxt.Text);

            b = db.books.FirstOrDefault(x => x.ID == idu);

            b.names = nametxt.Text;
            b.BookAuthor = authortxt.Text;
            b.CategoryID = int.Parse(authortxt_Copy.Text);

            db.books.AddOrUpdate(b);

            db.SaveChanges();
            MessageBox.Show("Data Updated succefully");


            loadbook(catNa);
        }

        private void Delete_butt(object sender, RoutedEventArgs e)
        {

            book b = new book();
            int idu = int.Parse(idtxt.Text);

            b = db.books.Remove(db.books.FirstOrDefault(x => x.ID == idu));

            db.SaveChanges();
            MessageBox.Show("Data Updated succefully");
            loadbook(catNa);

        }

        private void Search_butt(object sender, RoutedEventArgs e)
        {
            book b = new book();

            b = db.books.Where(x => x.names == nametxt.Text).FirstOrDefault();

            if (nametxt.Text == "") { 
            
            loadbook(catNa);
                return;
            }
            if (b != null)
            {
                DG.ItemsSource = db.books.Where(x => x.names == nametxt.Text).Select(x => new { x.ID, x.names, x.BookAuthor }).ToList();
                return;
            }
            else
            {
                MessageBox.Show("Name not found");
            }



        }
    }
}
