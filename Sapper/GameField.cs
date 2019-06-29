﻿using System;
using System.Windows.Forms;

namespace Sapper
{
    class GameField
    {
        private CellOfGameField[,] _gameField;

        internal System.Collections.Generic.List<CellOfGameField> NoBombsCells =
            new System.Collections.Generic.List<CellOfGameField>();

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
        public void Lock()
        {
            foreach (CellOfGameField field in _gameField)
                field.Enabled = false;
        }
        public void Unlock()
        {
            foreach (CellOfGameField field in _gameField)
                field.Enabled = true;
        }
        public void Open()
        {
            foreach (var field in _gameField)
                if (false == field.IsPressed)
                    field.PerformClick();
        }
        public void Close()
        {
            foreach (var field in _gameField)
                field.ClearField();
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
                    _gameField[i, j] = new CellOfGameField();
                    _gameField[i, j].Location =
                        new System.Drawing.Point(
                            Sapper.Forms.MainForm.FORM_PADDING_SIDE + (i * (Sapper.Forms.MainForm.FIELD_SIZE_GAME - 2)),
                            Sapper.Forms.MainForm.FORM_PADDING_UP + (j * (Sapper.Forms.MainForm.FIELD_SIZE_GAME - 2)));

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
        private void Clear()
        {
            foreach (var field in _gameField)
            {
                field.ClearField();
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
            foreach (var field in _gameField)
                if (false == field.IsBomb)
                    this.NoBombsCells.Add(field);
        }
    }
}
