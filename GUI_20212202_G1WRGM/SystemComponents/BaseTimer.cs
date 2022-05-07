using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Threading;

namespace Models.SystemComponents
{
    public abstract class BaseTimer
    {
        public const int TicksPerSecond = 60;

        readonly DispatcherTimer timer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 0, 0, 1000/TicksPerSecond) };

        protected BaseTimer()
        {
            this.timer.Tick += delegate { this.DoTick(); };
        }

        public long CurrentTick { get; private set; }

        public void Start() => this.timer.IsEnabled = true;

        public void Stop() => this.timer.IsEnabled = false;

        protected abstract void Tick();

        void DoTick()
        {
            this.Tick();
            this.CurrentTick++;
        }
    }
    
}
