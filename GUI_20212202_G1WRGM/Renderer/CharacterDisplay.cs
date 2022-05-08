using GUI_20212202_G1WRGM.Others;
using GUI_20212202_G1WRGM.Renderer.Interfaces;
using Models;
using Models.SystemComponents;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Numerics;
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
        public DrawingGroup PlayerDG { get; set; }
        public IList<Bullet> Bullets { get; set; }
        public Player Player { get; set; }

        public void SetupCharacters(IList<Character> characters)
        {
            this.Characters = characters;
            //this.CharacterGeometries = new List<DrawingGroup>();
            Player = Characters.FirstOrDefault(x => x is Player) as Player;

            //Adding bullets
            Bullets = new List<Bullet>();
            Weapon weapon = Player.Inventory.SelectedItem as Weapon;
            for (int i = 0; i < weapon.AmmoAmount; i++)
            {
                Bullet bullet = new Bullet(
                    new System.Drawing.Point(Player.Position.X, Player.Position.Y + 64),
                    1,
                    new Vector2(
                        Math.Abs(Player.Inventory.SelectedItem.DirectionToLook.X - Player.Position.X),
                        Math.Abs(Player.Inventory.SelectedItem.DirectionToLook.Y - Player.Position.Y + 64)
                        ),
                    5,
                    true
                );
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            Random r = new Random();
            if (Characters != null)
            {
                //Renders the Player and his weapon in the default state
                PlayerDG = new DrawingGroup();
                PlayerDG.Children.Add(new GeometryDrawing(new ImageBrush(new BitmapImage(Player.PathToImg)), //Player image
                                new System.Windows.Media.Pen(System.Windows.Media.Brushes.Black, 0),
                                new RectangleGeometry(new Rect(Player.Position.X, Player.Position.Y, Player.Size.Width, Player.Size.Height))));

                //Transform player's weapon
                if (Player.Inventory.SelectedItem != null 
                    && Player.Inventory.SelectedItem.DirectionToLook.X != 0 
                    && Player.Inventory.SelectedItem.DirectionToLook.Y != 0)
                {
                    //Calculates the angle lol XDDDDDD
                    double angle = CalculateAngle(Player.Inventory.SelectedItem.DirectionToLook, new System.Drawing.Point(Player.Position.X, Player.Position.Y + 64));

                    //Rotates the image
                    ImageBrush rotatedImageBrush = new ImageBrush(new BitmapImage(Player.Inventory.PathToSelectedItemImg));
                    rotatedImageBrush.RelativeTransform = new RotateTransform(angle, 0.5, 0.5); //

                    //Creating the Drawing which will be added to the DrawingGroup (PlayerDG)
                    GeometryDrawing PlayerWeaponGD = 
                        new GeometryDrawing(rotatedImageBrush,
                        new System.Windows.Media.Pen(System.Windows.Media.Brushes.Black, 0),
                        new RectangleGeometry(new Rect(Player.Position.X, Player.Position.Y + 64, 128, 64)) //Player's selected item
                       );

                    PlayerWeaponGD.Geometry.Transform = new RotateTransform(angle, Player.Position.X + 64, Player.Position.Y + 64);

                    PlayerDG.Children.Add(PlayerWeaponGD);
                }

                //Transforms the player if the mouse X position is bigger than the player's X position
                if (Player.IsTransform)
                {
                    PlayerDG.Transform = new ScaleTransform(
                        -1, //Flips horizontally if -1. Stays the same when 1
                         1, //Flips vertically
                        Player.Position.X + 64, //CenterX
                        Player.Position.Y + 64 //CenterY
                        );
                }

                //Renders the shooting process
                if (Player.WillShoot && Player.Inventory.SelectedItem is Weapon weapon)
                {
                    weapon.AmmoAmount -= 1;
                    //Bullets.RemoveAt(0);

                    GeometryDrawing BulletGD =
                        new GeometryDrawing(new ImageBrush(new BitmapImage(weapon.PathToBulletImg)),
                        new System.Windows.Media.Pen(System.Windows.Media.Brushes.Black, 0),
                        new RectangleGeometry(new Rect(Player.Position.X + 128, Player.Position.Y + 64, 32, 16)) //Bullet
                       );

                    drawingContext.DrawDrawing(BulletGD);
                }

                drawingContext.DrawDrawing(PlayerDG);

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
            //if (PlayerDG != null)
            //{
            //    drawingContext.DrawDrawing(PlayerDG);
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

        public double CalculateAngle(System.Drawing.Point mousePosition, System.Drawing.Point objectPosition)
        {
            double xLength = Math.Abs(mousePosition.X - objectPosition.X);
            double yLength = Math.Abs(mousePosition.Y - objectPosition.Y);
            double angle = Math.Atan2(yLength, xLength) * 180 / Math.PI;

            return mousePosition.Y <= objectPosition.Y ? angle : angle * -1;
        }
    }
}
