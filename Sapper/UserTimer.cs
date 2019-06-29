using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sapper
{
    public partial class UserTimer : UserControl
    {
        private int _time;

        public UserTimer()
        {
            InitializeComponent();

            this.TimerPart_1.Image =
                this.TimerPart_10.Image =
                this.TimerPart_100.Image =
                Properties.Textures.Win7.win7_timer_null;

            this.Timer.Interval = 1000;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _time++;
        }

        private void OutTimerValue(int currentTime)
        {
            try
            {
                switch (currentTime % 1)
                {
                    case 0: this.TimerPart_1.Image = Properties.Textures.Win7.win7_timer_0; break;
                    case 1: this.TimerPart_1.Image = Properties.Textures.Win7.win7_timer_1; break;
                    case 2: this.TimerPart_1.Image = Properties.Textures.Win7.win7_timer_2; break;
                    case 3: this.TimerPart_1.Image = Properties.Textures.Win7.win7_timer_3; break;
                    case 4: this.TimerPart_1.Image = Properties.Textures.Win7.win7_timer_4; break;
                    case 5: this.TimerPart_1.Image = Properties.Textures.Win7.win7_timer_5; break;
                    case 6: this.TimerPart_1.Image = Properties.Textures.Win7.win7_timer_6; break;
                    case 7: this.TimerPart_1.Image = Properties.Textures.Win7.win7_timer_7; break;
                    case 8: this.TimerPart_1.Image = Properties.Textures.Win7.win7_timer_8; break;
                    case 9: this.TimerPart_1.Image = Properties.Textures.Win7.win7_timer_9; break;

                    default:
                        throw new ArgumentOutOfRangeException("ERROR_TIMER_1");
                }
                switch (currentTime % 10)
                {
                    case 0: this.TimerPart_10.Image = Properties.Textures.Win7.win7_timer_0; break;
                    case 1: this.TimerPart_10.Image = Properties.Textures.Win7.win7_timer_1; break;
                    case 2: this.TimerPart_10.Image = Properties.Textures.Win7.win7_timer_2; break;
                    case 3: this.TimerPart_10.Image = Properties.Textures.Win7.win7_timer_3; break;
                    case 4: this.TimerPart_10.Image = Properties.Textures.Win7.win7_timer_4; break;
                    case 5: this.TimerPart_10.Image = Properties.Textures.Win7.win7_timer_5; break;
                    case 6: this.TimerPart_10.Image = Properties.Textures.Win7.win7_timer_6; break;
                    case 7: this.TimerPart_10.Image = Properties.Textures.Win7.win7_timer_7; break;
                    case 8: this.TimerPart_10.Image = Properties.Textures.Win7.win7_timer_8; break;
                    case 9: this.TimerPart_10.Image = Properties.Textures.Win7.win7_timer_9; break;

                    default:
                        throw new ArgumentOutOfRangeException("ERROR_TIMER_10");
                }
                switch (currentTime % 100)
                {
                    case 0: this.TimerPart_100.Image = Properties.Textures.Win7.win7_timer_0; break;
                    case 1: this.TimerPart_100.Image = Properties.Textures.Win7.win7_timer_1; break;
                    case 2: this.TimerPart_100.Image = Properties.Textures.Win7.win7_timer_2; break;
                    case 3: this.TimerPart_100.Image = Properties.Textures.Win7.win7_timer_3; break;
                    case 4: this.TimerPart_100.Image = Properties.Textures.Win7.win7_timer_4; break;
                    case 5: this.TimerPart_100.Image = Properties.Textures.Win7.win7_timer_5; break;
                    case 6: this.TimerPart_100.Image = Properties.Textures.Win7.win7_timer_6; break;
                    case 7: this.TimerPart_100.Image = Properties.Textures.Win7.win7_timer_7; break;
                    case 8: this.TimerPart_100.Image = Properties.Textures.Win7.win7_timer_8; break;
                    case 9: this.TimerPart_100.Image = Properties.Textures.Win7.win7_timer_9; break;

                    default:
                        throw new ArgumentOutOfRangeException("ERROR_TIMER_100");
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
