﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_20212202_G1WRGM.SystemComponents
{
    class InnerClock : BaseTimer
    {
        public ICollection<ITickable> Components { get; set; } = new List<ITickable>();


        public void Register(ITickable component)
        {
            Components.Add(component);
        }
        protected override void Tick()
        {
            foreach (ITickable component in Components)
            {
                component.TickProcess();
            };
        }
    }
}