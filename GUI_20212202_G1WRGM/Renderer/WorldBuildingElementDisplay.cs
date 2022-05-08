using GUI_20212202_G1WRGM.Renderer.Interfaces;
using Models;
using Models.SystemComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GUI_20212202_G1WRGM.Renderer
{
    public class WorldBuildingElementDisplay : FrameworkElement, IWorldBuildingElementDisplay, ITickable
    {
        public IList<WorldBuildingElement> WorldBuildingElements { get; set; }
        public IList<Rect> WorldBuildingElementGeometries { get; set; }
        public System.Drawing.Size size { get; set; }
        public bool DoRender { get; set; } = true;
        public void Resize(System.Drawing.Size size)
        {
            this.size = size;
        }

        public void SetupWorldBuildingElements(IList<WorldBuildingElement> worldBuildingElements)
        {
            this.WorldBuildingElements = worldBuildingElements;
            WorldBuildingElementGeometries = new List<Rect>();
            
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (WorldBuildingElements != null)
            {
                foreach (var worldElement in WorldBuildingElements)
                {
                    Rect rect = new Rect(worldElement.Position.X, worldElement.Position.Y, worldElement.Area.Width, worldElement.Area.Height);
                    WorldBuildingElementGeometries.Add(rect);
                    drawingContext.DrawRectangle(
                        new ImageBrush(new BitmapImage(worldElement.PathToImg)),
                        new Pen(Brushes.Black, 0),
                        rect);
                }
            }
        }


        public void TickProcess()
        {
            if (DoRender)
            {
                this.InvalidateVisual();
                DoRender = false;
            }

        }


    }
}
