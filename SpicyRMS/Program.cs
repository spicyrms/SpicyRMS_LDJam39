using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpicyRMS
{
    static class Program
    {
        static splash_form game_splash = null;

        static public void show_splash()
        {
            game_splash = new splash_form();
            Application.Run(game_splash);
        }

        static public void close_splash()
        {
            game_splash.Dispose();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new main_form());
        }
    }
}
