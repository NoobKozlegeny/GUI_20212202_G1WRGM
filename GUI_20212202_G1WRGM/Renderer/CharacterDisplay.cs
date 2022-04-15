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
    public class CharacterDisplay : FrameworkElement, ICharacterDisplay
    {
        // Ennek nem mapot kell átvenni, ez csak a karakterekkel foglalkozik, egy karakter collectiont kell átvennie és azokat rajzolgatnia
        // csak ez a része lesz itt még kicsit érdekes mert itt kellene grouppolni a karaktert alkotó részeket + a fegyvert ami mozog vele stb.

        public IList<Character> Characters { get; set; }
        public System.Drawing.Size size { get; set; }

        public void Resize(System.Drawing.Size size)
        {
            this.size = size;
            if (Characters != null)
            {
                foreach (var item in Characters)
                {
                    item.Size = size;
                }
                this.InvalidateVisual();
            }
        }

        public void SetupCharacters(IList<Character> characters)
        {
            this.Characters = characters;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (Characters != null)
            {
                //Display Characters
                int xChar = 0;
                foreach (Character character in Characters)
                {
                    drawingContext.DrawRectangle(
                        new ImageBrush(new BitmapImage(character.PathToImg)),
                        new Pen(Brushes.Black, 0),
                        new Rect(xChar, 200, 150, 200));

                    xChar += 150;
                }
            }
        }
    }
}
