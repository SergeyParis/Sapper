using System;
using System.Collections.Generic;
using System.Drawing;
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
        private bool _isPressed;
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
            this._isPressed = false;
            if (false == this.IsThisBomb)
                this.SurroundingCellsWithBomb = 0;
            else
                this.SurroundingCellsWithBomb = -1;
            
            this.Size = new Size(Sapper.Forms.MainForm.SIZE_GAME_FIELD, Sapper.Forms.MainForm.SIZE_GAME_FIELD);
            this.Click += new EventHandler(OnClick);
        }

        void OnClick (object sender, EventArgs e)
        {
            if (true == this.Enabled)
            {
                this.Enabled = false;

                if (true == this.IsThisBomb)
                    this.Text = "B";
                else if (0 == this.SurroundingCellsWithBomb)
                {
                    this.Text = "0";

                    for (int i = 0; i < 8; i++)
                    {
                        if (null == _surroundingCells[i])
                            break;
                        _surroundingCells[i].PerformClick();
                    }
                }
                else
                {
                    this.Text = Convert.ToString(SurroundingCellsWithBomb);
                }
            }

            /*
                        if (this.Text != "") { }
                        else if (true == this.IsThisBomb)
                            this.Text = "B";
                        else if (0 == SurroundingCellsWithBomb)
                        {
                            this.Text = "0";

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
                        */
        }
    }
}
