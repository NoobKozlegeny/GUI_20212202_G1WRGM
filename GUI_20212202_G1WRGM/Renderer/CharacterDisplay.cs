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
    public class CharacterDisplay : FrameworkElement, IDisplay
    {
        public Map map { get; set; }
        public System.Drawing.Size size { get; set; }

        public void Resize(System.Drawing.Size size)
        {
            this.size = size;
            if (map != null)
            {
                map.Size = size;
                this.InvalidateVisual();
            }
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
                //Display Characters
                int xChar = 0;
                foreach (Character character in map.Characters)
                {
                    drawingContext.DrawRectangle(
                        new ImageBrush(new BitmapImage(character.PathToImg)),
                        new Pen(Brushes.Black, 0),
                        new Rect(xChar, map.Size.Height - (map.Size.Height / 12 + map.Size.Height / 24), map.Size.Width / 18, map.Size.Height / 12));

                    xChar += 150;
                }
            }
        }
    }
}
