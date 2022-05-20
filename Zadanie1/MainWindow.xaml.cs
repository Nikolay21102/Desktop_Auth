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

namespace Zadanie1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public string Login { get; set; }
        public string Password { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (UsersEntities context = new UsersEntities())
            {
                var users = context.Users.ToList();
                var result = users.FirstOrDefault(x => x.Login == Login && x.Password == Password);
                if (result != null)
                {
                    MessageBox.Show("Успех");
                }
                else
                {
                    MessageBox.Show("Пароль или логин неправильный");
                }
            }
        }
    }
}
