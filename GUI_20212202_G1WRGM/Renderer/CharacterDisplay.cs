﻿using GUI_20212202_G1WRGM.Renderer.Interfaces;
using Models;
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
    public class CharacterDisplay : FrameworkElement, ICharacterDisplay
    {
        // Ennek nem mapot kell átvenni, ez csak a karakterekkel foglalkozik, egy karakter collectiont kell átvennie és azokat rajzolgatnia
        // csak ez a része lesz itt még kicsit érdekes mert itt kellene grouppolni a karaktert alkotó részeket + a fegyvert ami mozog vele stb.

        public IList<Character> Characters { get; set; }
        public System.Drawing.Size size { get; set; }
        public DrawingGroup PlayerGG { get; set; }

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
                Player player = (Player)Characters.FirstOrDefault(x => x is Player);
                PlayerGG = new DrawingGroup();
                PlayerGG.Children.Add(new GeometryDrawing(new ImageBrush(new BitmapImage(player.PathToImg)), //Player image
                    new System.Windows.Media.Pen(System.Windows.Media.Brushes.Black, 0), 
                    new RectangleGeometry(new Rect(0, size.Height - size.Height / 8, size.Width / 18, size.Height / 12))));

                //Rendering the player and their selected item which have been added in the ItemDisplay
                drawingContext.DrawDrawing(PlayerGG);

                //Display NPCS and their weapons
                int xChar = 150;
                foreach (NPC npc in Characters.Where(x=>x is NPC))
                {
                    DrawingGroup npcDG = new DrawingGroup();
                    
                    //Adding NPC image
                    npcDG.Children.Add(new GeometryDrawing(new ImageBrush(new BitmapImage(npc.PathToImg)),
                    new System.Windows.Media.Pen(System.Windows.Media.Brushes.Black, 0),
                    new RectangleGeometry(new Rect(xChar, size.Height - size.Height / 8, size.Width / 18, size.Height / 12))));

                    //Adding NPC's weapon
                    npcDG.Children.Add(new GeometryDrawing(new ImageBrush(new BitmapImage(npc.PathToWeaponImg)),
                    new System.Windows.Media.Pen(System.Windows.Media.Brushes.Black, 0),
                    new RectangleGeometry(new Rect(xChar, size.Height - size.Height / 12, size.Width / 18, size.Height / 27))));

                    //NPC
                    //drawingContext.DrawRectangle(
                    //    new ImageBrush(new BitmapImage(npc.PathToImg)),
                    //    new System.Windows.Media.Pen(System.Windows.Media.Brushes.Black, 0),
                    //    new Rect(xChar, size.Height - size.Height / 8, size.Width / 18, size.Height / 12));

                    //NPC's Weapon
                    //drawingContext.DrawRectangle(
                    //    new ImageBrush(new BitmapImage(npc.PathToWeaponImg)),
                    //    new System.Windows.Media.Pen(System.Windows.Media.Brushes.Black, 0),
                    //    new Rect(xChar, size.Height - size.Height / 12, size.Width / 18, size.Height / 27));

                    drawingContext.DrawDrawing(npcDG);

                    xChar += 150;
                }

            }
        }

        //Merges 2 images into one duuuh (redundant)
        private static BitmapImage MergeImages(Uri baseImageUri, Uri layerImageUri)
        {
            Bitmap baseImage = new Bitmap(baseImageUri.OriginalString, true);
            for (int i = 0; i < baseImage.Height / 2; i++)
            {
                for (int j = 0; j < baseImage.Width / 2; j++)
                {
                    baseImage.SetPixel(i, j, System.Drawing.Color.Blue);
                }
            }
            baseImage.Save("kaga.png");

            return new BitmapImage();
        }
    }
}
