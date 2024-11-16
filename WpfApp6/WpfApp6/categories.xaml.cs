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

namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for categories.xaml
    /// </summary>
    public partial class categories : Page
    {
        bookEntities db = new bookEntities();
        public categories()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var lis = listbox.SelectedItem as ListBoxItem;

            Admin ad = new Admin(lis.Content.ToString());
            this.NavigationService.Navigate(ad);



        }
    }
}
