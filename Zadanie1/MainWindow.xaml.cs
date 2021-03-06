using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Return && LoginEnabled == false)
            {
                MessageBox.Show("GO");
                using (UsersEntities context = new UsersEntities())
                {
                    var users = context.Users.ToList();
                    var result = users.FirstOrDefault(x => x.Login == Login);
                    if (result != null)
                    {
                        LoginEnabled = true;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LoginEnabled)));
                    }
                }
            }
        }

        public string Login { get; set; }
        public bool LoginEnabled { get; set; }
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

        private void Button_PreviewKeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void TextBox1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
                e.Handled = true;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = "";
        }
    }
}
