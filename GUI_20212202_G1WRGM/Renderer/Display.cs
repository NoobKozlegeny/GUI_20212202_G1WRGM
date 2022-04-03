using GUI_20212202_G1WRGM.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace GUI_20212202_G1WRGM.Renderer
{
    public class Display : FrameworkElement
    {
        IGameModel logic;
        Size size;

        public void Resize(Size size)
        {
            this.size = size;
            this.InvalidateVisual();
        }

        public void SetupLogic(IGameModel logic)
        {
            this.logic = logic;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (logic != null && size.Width > 50 && size.Height > 50)
            {
                drawingContext.DrawRectangle(Brushes.Black, new Pen(Brushes.Red, 2),
                    new Rect(100, 100, 100, 100));
            }
        }
    }
}
