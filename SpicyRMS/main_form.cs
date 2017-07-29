using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpicyRMS
{
    public partial class main_form : Form
    {
        private SoundPlayer music_player = new SoundPlayer();
        
        public main_form()
        {
            InitializeComponent();
            Thread.Sleep(8000);
            splash_screen.splash_screen.dispose_form();
        }

        private void main_form_Load(object sender, EventArgs e)
        {
            try
            {
                this.music_player.SoundLocation = @"D:\dev\game_jam\SpicyRMS\SpicyRMS\assets\audio\music\ending.wav";
                this.music_player.PlayLooping();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message, "Error playing audio");
            }
        }
    }
}
