using System;

namespace Sapper.GameField
{
    class GameField
    {
        private readonly CellOfGameField[,] _gameField;
        
        internal int CountNoBombsCells;

        private readonly int _height;
        private readonly int _width;
        private readonly Sapper.Forms.MainForm _senderForm;

        public int SizeX => _gameField[_width - 1, _height - 1].Location.X;
        public int SizeY => _gameField[_width - 1, _height - 1].Location.Y;
        public Sapper.Forms.MainForm GetSenderForm => _senderForm;

        public GameField(Sapper.Forms.MainForm sender, int width, int height)
        {
            _width = width;
            _height = height;
            _senderForm = sender;

            _gameField = new CellOfGameField[_width, _height];
        }

        public CellOfGameField this[int indexX, int indexY]
        {
            get { return _gameField[indexX, indexY]; }
            set { _gameField[indexX, indexY] = value; }
        }
        public void Build()
        {
            CreateButtons();
            _senderForm.ChangeSize();
            PlacingBombs();
            SetRefSurroundingCells();
            SetCountSurroundingCellsWithBomb();
            SetNoBombSells();
            SetSenderGameFieldForFields();
        }
        public void Rebuild()
        {
            Clear();

            PlacingBombs();
            SetCountSurroundingCellsWithBomb();
            SetNoBombSells();

            SetSenderGameFieldForFields();
        }
        public void LockEnabled()
        {
            foreach (CellOfGameField field in _gameField)
                field.Enabled = false;
        }
        public void Lock()
        {
            foreach (var field in _gameField)
                field.EnabledClick = false;
        }

        public void Unlock()
        {
            foreach (CellOfGameField field in _gameField)
                field.EnabledClick = true;
        }
        public void Open()
        {
            foreach (var field in _gameField)
                if (false == field.IsPressed)
                    field.PerformClick();
        }
        public void OpenBomb()
        {
            foreach (var field in _gameField)
                if (true == field.IsBomb && false == field.IsPressed)
                    field.PerformClick();
        }
        public void Clear()
        {
            foreach (var field in _gameField)
                field.ClearField();

            CountNoBombsCells = 0;
        }
        
        private void SetSenderGameFieldForFields()
        {
            foreach (var field in _gameField)
            {
                if (null == field)
                    return;
                field.SetSenderGameField(this);
            }
        }
        private void CreateButtons()
        {
            if (null == _senderForm) return;

            for (int i = 0; i < _senderForm.GameFieldWidth; i++)
                for (int j = 0; j < _senderForm.GameFieldHeight; j++)
                {
                    _gameField[i, j] = new CellOfGameField
                    {
                        Location = new System.Drawing.Point(
                            Sapper.Forms.MainForm.FORM_PADDING_SIDE + (i*(Sapper.Forms.MainForm.FIELD_SIZE_GAME - 2)),
                            Sapper.Forms.MainForm.FORM_PADDING_UP + (j*(Sapper.Forms.MainForm.FIELD_SIZE_GAME - 2)))
                    };

                    _senderForm.Controls.Add(_gameField[i, j]);
                }
        }
        private void PlacingBombs()
        {
            if (null == _senderForm) return;

            Random random = new Random();

            for (int i = 0; i < _senderForm.CountOfBombs; i++)
            {
                int tempRandomWidth = random.Next(_senderForm.GameFieldWidth);
                int tempRandomHeight = random.Next(_senderForm.GameFieldHeight);

                if (false == _gameField[tempRandomWidth, tempRandomHeight].IsBomb)
                    _gameField[tempRandomWidth, tempRandomHeight].IsBomb = true;
                else
                    --i;
            }
        }
        private void SetRefSurroundingCells()
        {
            if (null == _senderForm) return;

            for (int i = 0; i < _senderForm.GameFieldWidth; i++)
                for (int j = 0; j < _senderForm.GameFieldHeight; j++)
                {
                    for (int k = -1; k < 2; k++)
                        for (int l = -1; l < 2; l++)
                        {
                            if ((0 == k) && (0 == l)) { continue; }

                            try
                            {
                                _gameField[i, j].
                                    SurroundingCells.Add(_gameField[i - k, j - l]);
                            }
                            catch { continue; }
                        }
                }
        }
        private void SetCountSurroundingCellsWithBomb()
        {
            if (null == _senderForm) return;

            for (int i = 0; i < _senderForm.GameFieldWidth; i++)
                for (int j = 0; j < _senderForm.GameFieldHeight; j++)
                {

                    for (int k = -1; k < 2; k++)
                        for (int l = -1; l < 2; l++)
                        {
                            if ((0 == k) && (0 == l)) { continue; }

                            try
                            {
                                if (_gameField[i - k, j - l].IsBomb)
                                    _gameField[i, j].CountSurroundingCellsWithBomb++;
                            }
                            catch { continue; }
                        }


                }
        }
        private void SetNoBombSells()
        {
            CountNoBombsCells = 0;

            foreach (var field in _gameField)
                if (false == field.IsBomb)
                    this.CountNoBombsCells++;
        }
    }
}
