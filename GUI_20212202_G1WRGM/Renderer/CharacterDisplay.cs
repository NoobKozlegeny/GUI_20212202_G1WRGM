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
        public GeometryGroup PlayerGG { get; set; }

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
                //Display Player
                //So I made a GeometryGroup to display the player, but while doing it I realised that maybe I can't merge the player object and the selected item
                //as a legitimate GeometryGroup so I left this at this current state, maybe my original idea is still possible
                Player player = (Player)Characters.FirstOrDefault(x => x is Player);
                PlayerGG = new GeometryGroup();
                PlayerGG.Children.Add(new RectangleGeometry(new Rect(0, size.Height - (size.Height / 12 + size.Height / 24), size.Width / 18, size.Height / 12)));

                drawingContext.DrawGeometry(
                    new ImageBrush(new BitmapImage(player.PathToImg)),
                        new Pen(Brushes.Black, 0),
                        PlayerGG);

                //Display NPCS
                int xChar = 150;
                foreach (Character character in Characters.Where(x=>x is NPC))
                {
                    drawingContext.DrawRectangle(
                        new ImageBrush(new BitmapImage(character.PathToImg)),
                        new Pen(Brushes.Black, 0),
                        new Rect(xChar, size.Height - (size.Height / 12 + size.Height / 24), size.Width / 18, size.Height / 12));

                    xChar += 150;
                }
            }
        }
    }
}
