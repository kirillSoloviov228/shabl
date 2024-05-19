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
using Microsoft.Win32;
using System.IO;
using System.Collections.Generic;
using System;

namespace shabl
{
    /// <summary>
    /// Логика взаимодействия для AddZhouryModer.xaml
    /// </summary>
    public partial class AddZhouryModer : Page
    {
        int userId;
        string link = "";
        
        public AddZhouryModer()
        {
            InitializeComponent();
            var listEvent = champ_user_04Entities.GetContext().Event.ToList();
            List<string> strEvents = new List<string>();
            for (int i = 0; i < listEvent.Count; i++)
            {
                strEvents.Add(listEvent[i].name);
            }
            mComboBox.ItemsSource = strEvents;
            var numUser = champ_user_04Entities.GetContext().User.ToList();
            userId = numUser[numUser.Count - 1].id + 1;
            textId.Text = $"{userId}";
        }

        private void clickPhotoUser(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                link = openFileDialog.FileName;
                LoadImage(link);
            }
        }
        private void LoadImage(string imagePath)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath, UriKind.RelativeOrAbsolute);
            bitmap.EndInit();
            photoUser.Source = bitmap;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string pol;
                int role;
                string eventId;
                string pass;
                byte[] photo;
                if (polComboBox.SelectedIndex == 0)
                    pol = "м";
                else
                    pol = "ж";
                if (roleComboBox.SelectedIndex == 0)
                    role = 3;
                else
                    role = 2;

                if (checkEvent.IsChecked.Value)
                    eventId = mComboBox.SelectedValue.ToString();
                else
                    eventId = null;


                if (passCheckBox.IsChecked.Value)
                {
                    if (textPassV.Text == textPassV2.Text)
                    {
                        pass = textPassV.Text;
                    }
                    else
                        throw new Exception("ошибка");
                }
                else
                {
                    if (textPass.Password == textPass2.Password)
                    {
                        pass = textPass.Password;
                    }
                    else
                        throw new Exception("ошибка");
                }
                photo = File.ReadAllBytes(link);
                string[] strFIO = textFIO.Text.Split(' ');

                champ_user_04Entities.GetContext().User.Add(new User { first_name = strFIO[0], last_name = strFIO[1], patronymic = strFIO[2], mail = textEmail.Text, password = pass, date_birth = DateTime.Now, id_country = 10, telephone = MaskaPhone.Text, gender = pol, direction = textD.Text, @event = eventId, photo = photo, id_role = role });
                champ_user_04Entities.GetContext().SaveChanges();
                Manager.MainFrame.Navigate(new MenuAdmin());

            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            textPass.Visibility = Visibility.Visible;
            textPassV.Visibility = Visibility.Hidden;
            textPass.Password = textPassV.Text;
            textPass2.Visibility = Visibility.Visible;
            textPassV2.Visibility = Visibility.Hidden;
            textPass2.Password = textPassV2.Text;
        }

        private void checkBox_Indeterminate(object sender, RoutedEventArgs e)
        {

        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            textPass.Visibility = Visibility.Hidden;
            textPassV.Visibility = Visibility.Visible;
            textPassV.Text = textPass.Password;
            textPass2.Visibility = Visibility.Hidden;
            textPassV2.Visibility = Visibility.Visible;
            textPassV2.Text = textPass2.Password;
        }

    }
}