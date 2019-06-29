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
    public partial class CountBombsRemains : Counter
    {
        private int _bombs;

        public int GetBombs => _bombs;

        public CountBombsRemains()
        {
            InitializeComponent();
        }

        public void SetCountBombs(int bombs)
        {
            this._bombs = bombs;
            base.SetValueCounter(_bombs);
        }

        public void Reset()
        {
            _bombs = 0;
            base.SetValueCounter(_bombs);
        }
    }
}
