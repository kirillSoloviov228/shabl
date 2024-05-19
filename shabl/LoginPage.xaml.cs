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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public static int log;
        public static string pass;
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                log = int.Parse(login.Text);
                pass = passw.Password;
                if (login.Text != "" && passw.Password != "")
                {
                    List<User> person = champ_user_04Entities.GetContext().User.Where(p => p.id == log && p.password == passw.Password).ToList();

                    if (person.Count > 0)
                    {
                        Manager.SetUser(person[0].id, person[0].first_name, person[0].last_name, person[0].patronymic, person[0].mail, person[0].telephone, person[0].gender, person[0].photo, person[0].id_role);
                        Manager.MainFrame.Navigate(new MenuAdmin());
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неверный логин или пароль");
            }


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (passw.Visibility == Visibility.Visible)
            {
                passw.Visibility = Visibility.Hidden;
                password.Visibility = Visibility.Visible;
                password.Text = passw.Password;
            }
            else
            {
                passw.Visibility = Visibility.Visible;
                password.Visibility = Visibility.Hidden;
                passw.Password = password.Text;
            }
        }
    }
}