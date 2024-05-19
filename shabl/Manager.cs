using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace shabl
{
    internal class Manager
    {
        public static Frame MainFrame { get; set; }
        public static int _id;
        public static string _first_name;
        public static string _last_name;
        public static string _patronymic;
        public static string _mail;
        public static string _telephone;
        public static string _gender;
        public static byte[] _photo;
        public static int _id_role;

        public static void SetUser(int id, string first_name, string last_name, string patronymic, string mail, string telephone, string gender, byte[] photo, int id_role)
        {
            _id = id;
            _first_name = first_name;
            _last_name = last_name;
            _patronymic = patronymic;
            _mail = mail;
            _telephone = telephone;
            _gender = gender;
            _photo = photo;
            _id_role = id_role;
        }
    }
}
