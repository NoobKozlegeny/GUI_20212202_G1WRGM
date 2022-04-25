using GUI_20212202_G1WRGM.Renderer;
using GUI_20212202_G1WRGM.Renderer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace GUI_20212202_G1WRGM.Controller
{
    public class WindowControl : FrameworkElement
    {
        private GameController controller;
        private IGameControlDisplay display;

        public WindowControl()
        {
            this.Loaded += WindowControl_Loaded;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (this.display != null)
            {
                drawingContext.DrawDrawing(this.display.Build());
            }
        }

        private void WindowControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.controller = new GameController();
            this.display = new GameControlDisplay(controller);
        }
    }
}
