using System;

namespace Sapper.Controls
{
    public partial class UserTimer : Counter
    {
        private int _time;

        public UserTimer() : base()
        {
            InitializeComponent();

            this.Timer.Interval = 1000;
        }

        protected override void ValueMoreThousand()
        {
            base.ValueMoreThousand();
            this.Timer.Stop();
        }

        public void Start()
        {
            Timer.Start();
        }
        public void Stop()
        {
            Timer.Stop();
        }

        public void Reset()
        {
            Timer.Stop();
            _time = -1;
            base.SetValueCounter(_time);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            base.SetValueCounter(_time);
            _time++;
        }

    }
}
