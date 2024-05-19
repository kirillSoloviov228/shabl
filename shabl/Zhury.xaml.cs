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

namespace shabl
{
    /// <summary>
    /// Логика взаимодействия для Zhury.xaml
    /// </summary>
    public partial class Zhury : Page
    {
        public Zhury()
        {
            InitializeComponent();
            aaaa.ItemsSource = champ_user_04Entities.GetContext().User.Where(p => p.id_role == 3).ToList();
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddZhouryModer());
        }
    }
}
