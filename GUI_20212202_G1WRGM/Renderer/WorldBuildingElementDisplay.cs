using GUI_20212202_G1WRGM.Renderer.Interfaces;
using Models;
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
    public class WorldBuildingElementDisplay : FrameworkElement, IWorldBuildingElementDisplay
    {
        public IList<WorldBuildingElement> WorldBuildingElements { get; set; }
        public System.Drawing.Size size { get; set; }

        public void Resize(System.Drawing.Size size)
        {
            this.size = size;
        }

        public void SetupWorldBuildingElements(IList<WorldBuildingElement> worldBuildingElements)
        {
            this.WorldBuildingElements = worldBuildingElements;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            // na és akkor itt csak a listában lévő dolgokat rajzolgatja ki, amihez jelenleg nincsenek képeim stb.
            // de ha bármi egyéb dolog kell akkor elsősorban ne függőséggel oldjuk meg hanem pl.: a modelbe csapjunk oda +1 property ha azzal megoldható
            // ++ csak ne felejtsük el EF-ben hogy kell a mappelni, hogy ha nem .Ignore() stb.

            if (WorldBuildingElements != null)
            {
                //Display WorldBuildingElements
                int xElement = 0;
                foreach (WorldBuildingElement worldElement in WorldBuildingElements)
                {
                    drawingContext.DrawRectangle(
                        new ImageBrush(new BitmapImage(worldElement.PathToImg)),
                        new Pen(Brushes.Black, 0),
                        new Rect(xElement, size.Height - size.Height / 24, size.Width / 12, size.Height / 24));

                    xElement += size.Width / 12;
                }
            }
        }



    }
}
