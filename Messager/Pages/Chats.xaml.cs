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
using Messager.DBConnection;
using Messager.Pages;
using Messager.Windows;

namespace Messager.Pages
{
    /// <summary>
    /// Логика взаимодействия для Chats.xaml
    /// </summary>
    public partial class Chats : Page
    {
        public static List<ChatRoom> chatRooms { get; set; }
        public Chats()
        {
            InitializeComponent();
            chatRooms = new List<ChatRoom>(DBConnection.Connection.messag.ChatRoom.ToList());
            lvChat.ItemsSource = chatRooms;
            this.DataContext = this;



        }

        private void lvChat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lvChat.SelectedItem != null)
            {
                var item = lvChat.SelectedItem as ChatRoom;
                NavigationService.Navigate(new InChats(item));
            }

        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = Search.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(search))
            {
                lvChat.ItemsSource = chatRooms;
            }
            else
            {
                lvChat.ItemsSource = chatRooms.Where(a => a.Name != null && a.Name.ToLower().Contains(search)).ToList();
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
