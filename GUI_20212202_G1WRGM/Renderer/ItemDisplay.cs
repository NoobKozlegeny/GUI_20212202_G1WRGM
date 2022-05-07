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
    public class ItemDisplay : FrameworkElement, IItemDisplay, ITickable
    {
        // Ez itt érdekes lesz mert lesznek itemek, amiknek van kezdőhelye és változhat, de kevésszer illetve itemek amik pl. folyamat a karakterrel együtt mozognak
        // lehet valami leszármazás kéne ItemD:CharacterD vagy fordítva? és felülírni a renderelést, ami a kerekterrel kell együtt mozogjon azt az ős intézi a többit külön render
        //
        public IList<Item> Items { get; set; }
        public System.Drawing.Size size { get; set; }
        public ICharacterDisplay CharacterDisplay { get; set; }

        public void Resize(System.Drawing.Size size)
        {
            this.size = size;
            if (Items != null)
            {
                this.InvalidateVisual();
            }
        }

        //Maybe inheritance idea is better but I'm gonna try out the dependency injection type of approach
        //A little bit of dependency, mehh lemme try it out tho
        public void SetupItems(IList<Item> items, ICharacterDisplay characterDisplay)
        {
            Items = items;
            CharacterDisplay = characterDisplay;
        }


        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (Items != null)
            {
                //Display Items
                int xChar = 500;
                foreach (Item item in Items)
                {
                    //Checks if an item has already been picked up, if yes then it will be rendered on the PlayerGG (Player GeometryGroup)s
                    if (item.IsPickedUp)
                    {
                        //Gets the rendered Player's X and Y coords
                        double playerPosX = CharacterDisplay.PlayerGG.Children.First().Bounds.X;
                        double playerPosY = CharacterDisplay.PlayerGG.Children.First().Bounds.Y;

                        //Adding the selected item to the player (The rendering will take place in the CharacterDisplay)
                        //CharacterDisplay.PlayerGG.Children.Add(new GeometryDrawing(new ImageBrush(new BitmapImage(item.PathToImg)), //Player's selected item
                        //    new Pen(Brushes.Black, 0),
                        //    new RectangleGeometry(new Rect(playerPosX, playerPosY + size.Height / 24, size.Width / 18, size.Height / 27))));
                    }
                    else
                    {
                        //Renders those items which haven't been picked up
                        drawingContext.DrawRectangle(
                        new ImageBrush(new BitmapImage(item.PathToImg)),
                        new Pen(Brushes.Black, 0),
                        new Rect(item.Position.X + xChar, item.Position.Y, item.Size.Width, item.Size.Height));

                        xChar += 150;
                    }
                }
            }
        }


        public void TickProcess()
        {
            this.InvalidateVisual();
        }
    }
}
