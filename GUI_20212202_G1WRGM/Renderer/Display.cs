using GUI_20212202_G1WRGM.Logic;
using Models;
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
        Map map { get; set; }
        System.Drawing.Size size;

        public void Resize(System.Drawing.Size size)
        {
            this.size = size;
            this.InvalidateVisual();
        }

        public void SetupMap(Map map)
        {
            this.map = map;            
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (map != null)
            {
                drawingContext.DrawRectangle(Brushes.Black, new Pen(Brushes.Black, 0),
                    new Rect(225, 200, 200, 200));
            }
        }
    }
}
