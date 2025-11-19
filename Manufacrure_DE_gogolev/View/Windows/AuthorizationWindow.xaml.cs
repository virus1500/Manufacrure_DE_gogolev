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

namespace Manufacrure_DE_gogolev.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LoginTB.Text) || string.IsNullOrEmpty(PasswordPB.Password))
            {
                MessageBox.Show("Заполните все поля!","Предупреждение",MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                App.CurrentUser = App.context.SystemUser.FirstOrDefault(systemUser => systemUser.Login == LoginTB.Text && systemUser.Password == PasswordPB.Password);

                if(App.CurrentUser !=null)
                {
                    CaptchaWindow captchaWindow = new CaptchaWindow();
                    if (captchaWindow.ShowDialog() == true)
                    {
                        //Аутентификация
                    }
                    else
                    {
                        //Блокировка
                    }
                }
                else
                {
                    //Блокировка
                }
            }

        }

        private void LoginBtn_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
