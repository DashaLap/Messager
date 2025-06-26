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

namespace Messager.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public List<User> users { get; set; }
        public int ChatId { get; set; } // ID чата, куда добавляем
        public AddUserWindow(ChatRoom chat)
        {
            InitializeComponent();
            ChatId = chat.ID;
            users = DBConnection.Connection.messag.User.ToList();
            DataContext = this;
            lvUser.ItemsSource = users;
            
        }

        private void Exit1_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new InChats());
        }

        private void Search1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void lvUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvUser.SelectedItem is User selectedUser)
            {
                bool alreadyInChat = DBConnection.Connection.messag.ChatUser
                    .Any(cu => cu.ID_User == selectedUser.ID && cu.ID_ChatRoom == ChatId);

                if (!alreadyInChat)
                {
                    ChatUser chatUser = new ChatUser
                    {
                        ID_User = selectedUser.ID,
                        ID_ChatRoom = ChatId
                    };

                    DBConnection.Connection.messag.ChatUser.Add(chatUser);
                    DBConnection.Connection.messag.SaveChanges();

                    MessageBox.Show("Пользователь добавлен!");
                    this.Close(); 
                }
                else
                {
                    MessageBox.Show("Этот пользователь уже в чате!");
                }
            }
        }  
    }
}
