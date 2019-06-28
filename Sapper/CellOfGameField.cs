using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sapper
{
    internal sealed class CellOfGameField : System.Windows.Forms.Button
    {
        private CellOfGameField[] _surroundingCells;
        public bool IsThisBomb { get; set; }
        public int SurroundingCellsWithBomb { get; set; }

        public CellOfGameField[] SetSurroundingCells
        {
            set { _surroundingCells = value; }
        }

        public CellOfGameField () : this(false) { }
        public CellOfGameField (bool isThisBomb) : base()
        {
            this.IsThisBomb = isThisBomb;
            if (false == this.IsThisBomb)
                this.SurroundingCellsWithBomb = 0;
            else
                this.SurroundingCellsWithBomb = -1;

            this.Click += new EventHandler(OnClick);
        }

        void OnClick (object sender, EventArgs e)
        {
            if (this.Text != "") { }
            else if (true == this.IsThisBomb)
                this.Text = "B";
            else if (0 == SurroundingCellsWithBomb)
            {
                this.Text = "0";

                int counter = 0;
                for (int i = 0; i < 8; i++)
                {
                    if (null != _surroundingCells[i])
                        _surroundingCells[i].PerformClick();
                }
            }
            else
            {
                this.Text = Convert.ToString(SurroundingCellsWithBomb);
            }
        }
    }
}
