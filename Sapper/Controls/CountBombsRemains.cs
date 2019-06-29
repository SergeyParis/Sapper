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

        protected override void ValueLessNull()
        {
            Value1 = Value10 = Value100 = 0;
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
