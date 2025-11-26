using Manufacrure_DE_gogolev.Model;
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
        int failedEntryCount = 0;
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
                        if(App.CurrentUser.IsBlocked == false)
                        {

                        //Авторизация
                        if (App.CurrentUser.RoleID == 1)
                        {
                            AdministratorWindow administratorWindow = new AdministratorWindow();
                            administratorWindow.ShowDialog();
                        }
                        else
                        {
                            UserWindow userWindow = new UserWindow();
                            userWindow.ShowDialog();
                        }
                            Close();
                        }
                        else
                        {
                            MessageBox.Show($"Учётная запись заблокирована!.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                    //Блокировка
                       
                    }
                }
                else
                {
                    //Блокировка
                    string login = App.context.SystemUser.FirstOrDefault(systemUser => systemUser.Login == LoginTB.Text).Login;
                    if (string.IsNullOrEmpty(login))
                    {
                        MessageBox.Show("Введён неправильный логин и пароль!","Предупреждение", MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                    }
                    else
                    {
                        //Подсчёт кол-во неудачных попыток
                        failedEntryCount++;
                        MessageBox.Show($"Введён неверный пароль. Осталось попыток:{failedEntryCount} из 3", "Предупреждение",MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                        if (failedEntryCount == 3)
                        {
                            MessageBox.Show("Пользователь забрлокирован!","Информация", MessageBoxButton.OK,
                            MessageBoxImage.Information);
                            failedEntryCount = 0;
                            SystemUser userToBlock = App.context.SystemUser.FirstOrDefault(systemUser => systemUser.Login == LoginTB.Text);
                            userToBlock.IsBlocked = true;
                            App.context.SaveChanges();
                        }
                    }

                }
            }

        }

        private void LoginBtn_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
