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

namespace WPF_Words_Counter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 taskWindow = new Window1();
            taskWindow.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string PassWord = Password.Text;
            if (PassWord == "Unn123")
            {
                MessageBox.Show("Добро пожаловать :)");
                MessageBox.Show("Перед началом работы с приложением очистите поле при помощи кнопки Очистить... и пожалуйста, не не выводите их листа текст, если строка пуста");
                Window2 taskWindow = new Window2();
                taskWindow.Show();
            }
            else
            {
                MessageBox.Show("Неверный пароль");
            }
        }
    }
}
