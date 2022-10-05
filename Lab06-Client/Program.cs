using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebServices_Lab06Model;

namespace Lab06_Client
{
    public static class DataSource
    {
        public static WebServices_Lab06Entities Client = new WebServices_Lab06Entities(new Uri("http://localhost:9001/WSKOA.svc/"));
    }
    
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        ///
        /// \
        ///
        ///
        ///
        ///
        ///
        ///
        ///
        /// 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
