using Manufacrure_DE_gogolev.AppData;
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
    /// Логика взаимодействия для CaptchaWindow.xaml
    /// </summary>
    public partial class CaptchaWindow : Window
    {
        Captcha captcha;
        string[] imagesPath;
        public CaptchaWindow()
        {
            InitializeComponent();

            captcha = new Captcha();

            imagesPath = new string[]
            {
                @"D:\Prog\DE_Captcha\DE_Captcha\Images\Captcha\1.png",
                @"D:\Prog\DE_Captcha\DE_Captcha\Images\Captcha\2.png",
                @"D:\Prog\DE_Captcha\DE_Captcha\Images\Captcha\3.png",
                @"D:\Prog\DE_Captcha\DE_Captcha\Images\Captcha\4.png",
            };


            CaptchaFragmentsLb.ItemsSource = captcha.CreateFragments(imagesPath);
        }

        private void FragmentsLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CaptchaFragment captchaFragment = CaptchaFragmentsLb.SelectedItem as CaptchaFragment;

            CaptchaLb.Items.Add(captchaFragment);

            if (CaptchaLb.Items.Count >= 4)
            {
                if (captcha.IsCorrect(CaptchaLb.Items) == true)
                {
                    MessageBox.Show("Вы прошли");
                    DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Вы не прошли");
                    DialogResult = true;
                }
            }
        }

        private void CaptchaLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CaptchaFragment captchaFragment = CaptchaLb.SelectedItem as CaptchaFragment;

            CaptchaLb.Items.Remove(captchaFragment);
        }
    }
}
