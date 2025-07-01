using Messager.DBConnection;
using Messager.Pages;
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
using System.Windows.Shapes;

namespace Messager.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddChatsWindow1.xaml
    /// </summary>
    public partial class AddChatsWindow1 : Window
    {
        public AddChatsWindow1()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Namechat.Text))
            {
                MessageBox.Show("Введите название чата");
                return;
            }

            // Создаем новый чат
            var newChat = new ChatRoom
            {
                Name = Namechat.Text
            };

            // Добавляем в базу данных
            DBConnection.Connection.messag.ChatRoom.Add(newChat);
            DBConnection.Connection.messag.SaveChanges();

            // Обновляем список чатов на основной странице
            Chats.chatRooms.Add(newChat);
            MessageBox.Show("Чат успешно создан!");
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
