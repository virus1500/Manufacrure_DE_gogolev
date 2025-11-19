using Manufacrure_DE_gogolev.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Manufacrure_DE_gogolev
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static user9Entities context= new user9Entities();
        public static SystemUser CurrentUser { get; set; }
    }
}
