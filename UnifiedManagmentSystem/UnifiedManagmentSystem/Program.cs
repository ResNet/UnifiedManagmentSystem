using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace UnifiedManagmentSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            EmailReader ER = new EmailReader();
            Thread messageSearcher = new Thread(new ThreadStart(ER.Run));
            messageSearcher.Start();
            System.Console.WriteLine("DONE!!");
            //create a Creator Object

            //create an EmailReader object

            //create a WIsender object


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LaunchForm());

  
        }
    }
}
