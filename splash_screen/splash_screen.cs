using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace splash_screen
{
    public partial class splash_screen : Form
    {
        // threading
        static splash_screen game_splash = null;
        static Thread splash_thread = null;

        // fade
        private double opac_increment = .05;
        private double opac_decrement = .60;
        private const int TIMER_INTERVAL = 50;

        public splash_screen()
        {
            InitializeComponent();
            this.Opacity = .0;
            update_timer.Interval = TIMER_INTERVAL;
            update_timer.Start();
        }

        // static entry point
        static private void show_form()
        {
            game_splash = new splash_screen();
            Application.Run(game_splash);
        }

        // static method for disposal
        static public void dispose_form()
        {
            if (game_splash != null)
                game_splash.opac_increment = -game_splash.opac_decrement;

            splash_thread = null;
            game_splash = null;
        }

        static public void show_splash()
        {
            if (game_splash != null)
                return;

            splash_thread = new Thread(new ThreadStart(splash_screen.show_form));
            splash_thread.IsBackground = true;
            splash_thread.SetApartmentState(ApartmentState.STA);
            splash_thread.Start();

            while (game_splash == null || game_splash.IsHandleCreated == false)
            {
                System.Threading.Thread.Sleep(TIMER_INTERVAL);
            }
        }
        
        private void update_timer_Tick(object sender, EventArgs e)
        {
            if (opac_increment > 0)
            {
                if (this.Opacity < 1)
                    this.Opacity += opac_increment;
            }
            else {
                if (this.Opacity > 0)
                    this.Opacity += opac_increment;
                else
                    this.Dispose();
            }
        }
    }
}
