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
    public abstract partial class Counter : UserControl
    {
        protected int value_1;
        protected int value_10;
        protected int value_100;

        protected Counter()
        {
            InitializeComponent();

            this.ValuePart_1.Image =
                this.ValuePart_10.Image =
                this.ValuePart_100.Image =
                Properties.Textures.Win7.win7_timer_null;
        }

        public virtual void ValueLessNull()
        {
            value_1 = -1;
            value_10 = -1;
            value_100 = -1;
        }

        private void SetValue(int value)
        {
            if (value > 1000)
            {
                MessageBox.Show("ERROR_ARGUMENT_VALUE_EXEPTION");
                return;
            }
            if (value < 0)
            {
                ValueLessNull();

                return;
            }

            value_1 = value % 10;
            value_10 = (value % 100) / 10;
            value_100 = value / 100;

        }

        protected void SetValueCounter(int currentValue)
        {
            SetValue(currentValue);

            OutConterValue();
            ClearData();
        }
        private void OutConterValue()
        {
            while (10 <= value_1)
            {
                value_1 -= 10;
                value_10++;
            }
            while (10 <= value_10)
            {
                value_10 -= 10;
                value_100++;
            }

            switch (value_1)
            {
                case -1: this.ValuePart_1.Image = Properties.Textures.Win7.win7_timer_null; break;

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
                case -1: this.ValuePart_10.Image = Properties.Textures.Win7.win7_timer_null; break;

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
                case -1: this.ValuePart_100.Image = Properties.Textures.Win7.win7_timer_null; break;

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
        private void ClearData()
        {
            value_1 = 0;
            value_10 = 0;
            value_100 = 0;
        }
    }
}
