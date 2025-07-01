using Messager.DBConnection;
using Messager.Windows;
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

namespace Messager.Pages
{
    /// <summary>
    /// Логика взаимодействия для InChats.xaml
    /// </summary>
    public partial class InChats : Page
    {
        public List<Mess> ChatMessages { get; set; }
        public List<ChatUser> chatUsers { get; set; }
        public List<User> users { get; set; }
        public ChatRoom chats { get; set; }
        public static List<ChatRoom> chatRooms { get; set; }
        public InChats(ChatRoom chatRoom)
        {
            InitializeComponent();
            chatUsers = DBConnection.Connection.messag.ChatUser.Where(x => x.ID_ChatRoom == chatRoom.ID).ToList();
            chats = chatRoom;
            ChatMessages = DBConnection.Connection.messag.Mess.Where(x => x.ID_ChatRoom == chats.ID).ToList();
            users = DBConnection.Connection.messag.User.ToList();
            DataContext = this;
            LvE.ItemsSource = chatUsers;
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            if (NewMes.Text.Trim().Length != 0)
            {
                Mess message = new Mess();
                message.ID_User = Autoriz.user.ID;
                message.ID_ChatRoom = chats.ID;
                message.DueDate = DateTime.Now;
                message.Mess1 = NewMes.Text.Trim();
                DBConnection.Connection.messag.Mess.Add(message);
                DBConnection.Connection.messag.SaveChanges();
                ChatMessages = DBConnection.Connection.messag.Mess.Where(x => x.ID_ChatRoom == chats.ID).ToList();
                Lvinchats.ItemsSource = ChatMessages;
                LvE.ItemsSource = chatUsers;
                NewMes.Text = "";
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Chats());

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

            AddUserWindow userWindow = new AddUserWindow(chats);
            userWindow.Show();


            chatUsers = DBConnection.Connection.messag.ChatUser
                .Where(x => x.ID_ChatRoom == chats.ID).ToList();
            LvE.ItemsSource = chatUsers;
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            chatUsers = new List<ChatUser>(DBConnection.Connection.messag.ChatUser.Where(v => v.ID_ChatRoom == chats.ID).ToList());
            //LvE.Items.Clear();
            LvE.ItemsSource = chatUsers;
            LvE.Items.Refresh();
        }

        private void OutChat_Click(object sender, RoutedEventArgs e)
        {
            var userInChat = DBConnection.Connection.messag.ChatUser
            .FirstOrDefault(cu => cu.ID_ChatRoom == chats.ID && cu.ID_User == Autoriz.user.ID);

            if (userInChat != null)
            {
                DBConnection.Connection.messag.ChatUser.Remove(userInChat);
                DBConnection.Connection.messag.SaveChanges();
            }
        }
    }
} 

