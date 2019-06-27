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
        private int _surroundingCells;
        public bool IsThisBomb { get; set; }

        public CellOfGameField() : this(false) { }
        public CellOfGameField(bool isThisBomb) : base()
        {
            this.IsThisBomb = isThisBomb;
            this._surroundingCells = 0;
        }

        public void SetSurroundingCells(params CellOfGameField [] surrondingCells)
        {
            CellOfGameField [] surrCells = new CellOfGameField[surrondingCells.Length];

            foreach (CellOfGameField cell in surrCells)
            {
                if (true == cell.IsThisBomb)
                    this._surroundingCells++;
                else continue;
            }
        }

        public static void ClickEvent()
        {
            
        }
    }
}
