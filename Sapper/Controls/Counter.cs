using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sapper.Controls
{
    public abstract partial class Counter : UserControl
    {
        protected int Value1;
        protected int Value10;
        protected int Value100;

        protected Counter()
        {
            InitializeComponent();

            this.ValuePart_1.Image =
                this.ValuePart_10.Image =
                this.ValuePart_100.Image =
                Properties.Textures.Win7.win7_timer_null;
        }

        protected virtual void ValueLessNull()
        {
            Value1 = -1;
            Value10 = -1;
            Value100 = -1;
        }
        protected virtual void ValueMoreThousand()
        {
            MessageBox.Show("ERROR_ARGUMENT_VALUE_EXEPTION");
        }

        private void SetValue(int value)
        {
            if (value > 1000)
            {
                ValueMoreThousand();
                return;
            }
            if (value < 0)
            {
                ValueLessNull();

                return;
            }

            Value1 = value % 10;
            Value10 = (value % 100) / 10;
            Value100 = value / 100;

        }

        protected void SetValueCounter(int currentValue)
        {
            SetValue(currentValue);

            OutConterValue();
            ClearData();
        }
        private void OutConterValue()
        {
            while (10 <= Value1)
            {
                Value1 -= 10;
                Value10++;
            }
            while (10 <= Value10)
            {
                Value10 -= 10;
                Value100++;
            }

            switch (Value1)
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
            switch (Value10)
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
            switch (Value100)
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
            Value1 = 0;
            Value10 = 0;
            Value100 = 0;
        }
    }
}
