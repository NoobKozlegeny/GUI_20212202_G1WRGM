using GUI_20212202_G1WRGM.Renderer.Interfaces;
using Models;
using Models.SystemComponents;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GUI_20212202_G1WRGM.Renderer
{
    public class CharacterDisplay : FrameworkElement, ICharacterDisplay, ITickable
    {
        public IList<Character> Characters { get; set; }
        // find the highest superclass or interface which we can point to any geometry object
        //public IList<DrawingGroup> CharacterGeometries { get; set; }
        public DrawingGroup PlayerGG { get; set; }
        public Player Player { get; set; }

        public void SetupCharacters(IList<Character> characters)
        {
            this.Characters = characters;
            //this.CharacterGeometries = new List<DrawingGroup>();
            Player = Characters.FirstOrDefault(x => x is Player) as Player;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            Random r = new Random();
            if (Characters != null)
            {
                //Renders the Player and his weapon in the default state
                PlayerGG = new DrawingGroup();
                PlayerGG.Children.Add(new GeometryDrawing(new ImageBrush(new BitmapImage(Player.PathToImg)), //Player image
                                new System.Windows.Media.Pen(System.Windows.Media.Brushes.Black, 0),
                                new RectangleGeometry(new Rect(Player.Position.X, Player.Position.Y, Player.Size.Width, Player.Size.Height))));

                PlayerGG.Children.Add(new GeometryDrawing(new ImageBrush(new BitmapImage(Player.Inventory.PathToSelectedItemImg)), //Player's selected item
                       new System.Windows.Media.Pen(System.Windows.Media.Brushes.Black, 0),
                       new RectangleGeometry(new Rect(Player.Position.X, Player.Position.Y + 64, 128, 64))));

                //GeometryDrawing PlayerWeaponDG = new GeometryDrawing(new ImageBrush(new BitmapImage(Player.Inventory.PathToSelectedItemImg)), //Player's selected item
                //       new System.Windows.Media.Pen(System.Windows.Media.Brushes.Black, 0),
                //       new RectangleGeometry(new Rect(Player.Position.X, Player.Position.Y + 64, 128, 64)));

                //Transform player's weapon
                if (Player.Inventory.SelectedItem != null 
                    && Player.Inventory.SelectedItem.DirectionToLook.X != 0 
                    && Player.Inventory.SelectedItem.DirectionToLook.Y != 0)
                {
                    double angle = Math.Atan2((double)Player.Inventory.SelectedItem.DirectionToLook.Y, (double)Player.Inventory.SelectedItem.DirectionToLook.X);
                    angle = angle * (180 / Math.PI);

                    //PlayerWeaponDG.Geometry.Transform = new RotateTransform(
                    //    angle, //Angle
                    //    Player.Position.X + 64, //CenterX
                    //    Player.Position.Y + 64 //CenterY
                    //    );
                }

                //Transforms the player if the mouse X position is bigger than the player's X position
                if (Player.IsTransform)
                {
                    PlayerGG.Transform = new ScaleTransform(
                        -1, //Flips horizontally if -1. Stays the same when 1
                         1, //Flips vertically
                        Player.Position.X + 64, //CenterX
                        Player.Position.Y + 64 //CenterY
                        );
                }

                drawingContext.DrawDrawing(PlayerGG);
                //drawingContext.DrawDrawing(PlayerWeaponDG);

                int xChar = 150;
                foreach (NPC npc in Characters.Where(x => x is NPC))
                {
                    DrawingGroup npcDG = new DrawingGroup();

                    //Adding NPC image
                    npcDG.Children.Add(new GeometryDrawing(new ImageBrush(new BitmapImage(npc.PathToImg)),
                    new System.Windows.Media.Pen(System.Windows.Media.Brushes.Black, 0),
                    new RectangleGeometry(new Rect(npc.Position.X, npc.Position.Y, npc.Size.Width, npc.Size.Height))));

                    //Adding NPC's weapon
                    npcDG.Children.Add(new GeometryDrawing(new ImageBrush(new BitmapImage(npc.PathToWeaponImg)),
                    new System.Windows.Media.Pen(System.Windows.Media.Brushes.Black, 0),
                    new RectangleGeometry(new Rect(npc.Position.X, npc.Position.Y + 64, 128, 64))));

                    //CharacterGeometries.Add(npcDG);
                    drawingContext.DrawDrawing(npcDG);
                    xChar += 150;
                }
            }
            


            base.OnRender(drawingContext);
            //if (PlayerGG != null)
            //{
            //    drawingContext.DrawDrawing(PlayerGG);
            //}
            //if (CharacterGeometries != null)
            //{
            //    foreach (var npc in CharacterGeometries)
            //    {
            //        drawingContext.DrawDrawing(npc);
            //    }
            //}
        }


        public void TickProcess()
        {
            this.InvalidateVisual();
        }

    }
}
