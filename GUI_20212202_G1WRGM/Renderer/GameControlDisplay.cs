using GUI_20212202_G1WRGM.Controller;
using GUI_20212202_G1WRGM.Logic;
using GUI_20212202_G1WRGM.Renderer.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace GUI_20212202_G1WRGM.Renderer
{
    class GameControlDisplay : IGameControlDisplay
    {
        private IGameModel model;
        public GameControlDisplay(GameController game)
        {
            this.model = game;
        }

        public IGameModel Model { get => this.model; set => this.model = value; }


        public Drawing Build()
        {
            DrawingGroup group = new DrawingGroup();
            group.Children.Add(this.GetBackground());
            
            foreach (Drawing item in this.GetBullets())
            {
                group.Children.Add(item);
            }
            
            foreach (Drawing item in this.GetItem())
            {
                group.Children.Add(item);
            }

            foreach (Drawing item in this.GetEnemies())
            {
                group.Children.Add(item);
            }

            group.Children.Add(this.GetPlayer());
            return group;
        }

        private Drawing GetBackground()
        {
            Geometry g = new RectangleGeometry(new Rect(0, 0, 400, 800));
            return new GeometryDrawing(Brushes.Black, null, g);
        }

        private Drawing GetPlayer()
        {
            Geometry g = new RectangleGeometry(new Rect(this.model.Player.Position.X, this.model.Player.Position.Y, 20, 20));
            return new GeometryDrawing(Brushes.Green, null, g);
        }

        private List<Drawing> GetEnemies()
        {
            List<Drawing> output = new List<Drawing>();

            foreach (NPC item in this.model.Enemies)
            {
                Geometry g = new EllipseGeometry(new Point(item.Position.X, item.Position.Y), 20, 20);
                output.Add(new GeometryDrawing(Brushes.Red, null, g));
            }

            return output;
        }

        private List<Drawing> GetBullets()
        {
            List<Drawing> output = new List<Drawing>();

            foreach (Bullet item in this.model.Bullets)
            {
                Geometry g = new EllipseGeometry(new Point(item.Position.X, item.Position.Y), 5, 5);
                output.Add(new GeometryDrawing(Brushes.Blue, null, g));
            }

            return output;
        }

        private List<Drawing> GetItem()
        {
            List<Drawing> output = new List<Drawing>();

            foreach (Item item in this.model.Items)
            {
                Geometry g = new EllipseGeometry(new Point(item.Position.X, item.Position.Y), 15, 15);
                output.Add(new GeometryDrawing(Brushes.Brown, null, g));
            }

            return output;
        }
    }
}
