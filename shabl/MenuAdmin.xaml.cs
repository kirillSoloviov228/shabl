using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для MenuAdmin.xaml
    /// </summary>
    public partial class MenuAdmin : Page
    {
        public MenuAdmin()
        {
            InitializeComponent();
            string time;

            if (DateTime.Now.Hour <= 11 && DateTime.Now.Hour >= 9)
            {
                time = "утро";
                Timee.Text = $"Доброе {time}";
            }
            else if (DateTime.Now.Hour > 11 && DateTime.Now.Hour <= 18)
            {
                time = "день";
                Timee.Text = $"Добрый {time}";
            }
            else if (DateTime.Now.Hour > 18 && DateTime.Now.Hour <= 24)
            {
                time = "вечер";
                Timee.Text = $"Добрый {time}";
            }
            else
            {
                time = "ночи";
                Timee.Text = $"Доброй {time}";
            }
            string g = Manager._last_name;
            string g1 = Manager._first_name;
            int? g2 = Manager._id_role;
            if (Manager._gender == "м")
            {
                Hello.Text = $"Mr {g} {g1}";
            }
            else
            {
                Hello.Text = $"Mrs {g} {g1}";
            }
            if (Manager._photo != null)
            {
                BitmapImage img = new BitmapImage();
                MemoryStream ms = new MemoryStream(Manager._photo);
                img.BeginInit();
                img.StreamSource = ms;
                img.EndInit();
                Imagege.Source = img;
            }
            if (Manager._id_role == 1)
            {
                titlea.Text = "Окно организатора";
                ParticipantButton.Visibility = Visibility.Visible;
                EventsButton.Visibility = Visibility.Visible;
                JuryButton.Visibility = Visibility.Visible;
            }
            if (Manager._id_role == 2)
            {
                titlea.Text = "Окно организатора";
                ParticipantButton.Visibility = Visibility.Visible;
                EventsButton.Visibility = Visibility.Visible;
                JuryButton.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Zhury());
        }
    }
}
