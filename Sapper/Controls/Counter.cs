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
    public partial class Counter : UserControl
    {
        private int value_1;
        private int value_10;
        private int value_100;

        public Counter()
        {
            InitializeComponent();

            this.ValuePart_1.Image =
                this.ValuePart_10.Image =
                this.ValuePart_100.Image =
                Properties.Textures.Win7.win7_timer_null;
        }
        
        protected void OutTimerValue(int currentTime)
        {
            value_1++;

            if (10 == value_1)
            {
                value_1 = 0;
                value_10++;
            } 
            if (10 == value_10)
            {
                value_10 = 0;
                value_100++;
            }
            if (9 == value_100)
                Timer.Stop();

            switch (value_1)
            {
                case 0: this.ValuePart_1.Image = Properties.Textures.Win7.win7_timer_0; break;
                case 1: this.ValuePart_1.Image = Properties.Textures.Win7.win7_timer_1; break;
                case 2: this.ValuePart_1.Image = Properties.Textures.Win7.win7_timer_2; break;
                case 3: this.ValuePart_1.Image = Properties.Textures.Win7.win7_timer_3; break;
                case 4: this.ValuePart_1.Image = Properties.Textures.Win7.win7_timer_4; break;
                case 5: this.ValuePart_1.Image = Properties.Textures.Win7.win7_timer_5; break;
                case 6: this.ValuePart_1.Image = Properties.Textures.Win7.win7_timer_6; break;
                case 7: this.ValuePart_1.Image = Properties.Textures.Win7.win7_timer_7; break;
                case 8: this.ValuePart_1.Image = Properties.Textures.Win7.win7_timer_8; break;
                case 9: this.ValuePart_1.Image = Properties.Textures.Win7.win7_timer_9; break;
            }
            switch (value_10)
            {
                case 0: this.ValuePart_10.Image = Properties.Textures.Win7.win7_timer_0; break;
                case 1: this.ValuePart_10.Image = Properties.Textures.Win7.win7_timer_1; break;
                case 2: this.ValuePart_10.Image = Properties.Textures.Win7.win7_timer_2; break;
                case 3: this.ValuePart_10.Image = Properties.Textures.Win7.win7_timer_3; break;
                case 4: this.ValuePart_10.Image = Properties.Textures.Win7.win7_timer_4; break;
                case 5: this.ValuePart_10.Image = Properties.Textures.Win7.win7_timer_5; break;
                case 6: this.ValuePart_10.Image = Properties.Textures.Win7.win7_timer_6; break;
                case 7: this.ValuePart_10.Image = Properties.Textures.Win7.win7_timer_7; break;
                case 8: this.ValuePart_10.Image = Properties.Textures.Win7.win7_timer_8; break;
                case 9: this.ValuePart_10.Image = Properties.Textures.Win7.win7_timer_9; break;
            }
            switch (value_100)
            {
                case 0: this.ValuePart_100.Image = Properties.Textures.Win7.win7_timer_0; break;
                case 1: this.ValuePart_100.Image = Properties.Textures.Win7.win7_timer_1; break;
                case 2: this.ValuePart_100.Image = Properties.Textures.Win7.win7_timer_2; break;
                case 3: this.ValuePart_100.Image = Properties.Textures.Win7.win7_timer_3; break;
                case 4: this.ValuePart_100.Image = Properties.Textures.Win7.win7_timer_4; break;
                case 5: this.ValuePart_100.Image = Properties.Textures.Win7.win7_timer_5; break;
                case 6: this.ValuePart_100.Image = Properties.Textures.Win7.win7_timer_6; break;
                case 7: this.ValuePart_100.Image = Properties.Textures.Win7.win7_timer_7; break;
                case 8: this.ValuePart_100.Image = Properties.Textures.Win7.win7_timer_8; break;
                case 9: this.ValuePart_100.Image = Properties.Textures.Win7.win7_timer_9; break;
            }

        }
    }
}
