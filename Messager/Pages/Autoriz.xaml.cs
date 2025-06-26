using Messager.DBConnection;
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
using Messager.Pages;


namespace Messager.Pages
{
    /// <summary>
    /// Логика взаимодействия для Autoriz.xaml
    /// </summary>
    public partial class Autoriz : Page
    {
        public static User user { get; set; }
        public Autoriz()
        {
            InitializeComponent();
        }

        private void Vhod_Click(object sender, RoutedEventArgs e)
        {
            string login = Login.Text.Trim();
            string password = Password1.Text.Trim();
            user = DBConnection.Connection.messag.User.Where(x => x.Login == login && x.Password == password).FirstOrDefault();
            if (user == null)
            {
                MessageBox.Show("Что то не так");
            }
            else if (user != null)
            {
                NavigationService.Navigate(new Chats());
            }
          
        }
    }
}
