using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sapper
{
    internal sealed class CellOfGameField : System.Windows.Forms.Button
    {
        public bool IsThisBomb { get; set; }
        public int SurroundingCells { get; set; }

        public CellOfGameField() : this(false) { }
        public CellOfGameField(bool isThisBomb) : base()
        {
            this.IsThisBomb = isThisBomb;
            if (false == this.IsThisBomb)
                this.SurroundingCells = 0;
            else
                this.SurroundingCells = -1;
        }

        public static void ClickEvent()
        {
            
        }
    }
}
