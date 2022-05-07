using GUI_20212202_G1WRGM.Renderer;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
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
using System.Drawing;
using GUI_20212202_G1WRGM.Others;

namespace GUI_20212202_G1WRGM.AlmostLogic
{
    public class PlayerMovementLogic
    {
        public Player Player { get; set; }
        public DrawingGroup PlayerGeometry { get; set; }
        public bool IsJumping { get; set; } = false;
        public bool IsGoingForward { get; set; } = false;
        public bool IsGoingBackward { get; set; } = false;
        public PlayerMovementLogic()
        {
            Player = Ioc.Default.GetService<CharacterDisplay>().Player;
            PlayerGeometry = Ioc.Default.GetService<CharacterDisplay>().PlayerGG;
        }
        public void MoveForward()
        {
            Task forward = new Task(
                async () => 
                {
                    IsGoingForward = true;
                    for (int i = 0; i < 15; i++)
                    {
                        lock (this)
                        {
                            Player.Position = new System.Drawing.Point(Player.Position.X + 8, Player.Position.Y);
                        }
                        await Task.Delay(1);
                    }
                    IsGoingForward = false;
                });
            if (!IsGoingForward)
            {
                forward.Start();
            }

        }
        public void MoveBackward()
        {
            Task backward = new Task(
                async () =>
                {
                    IsGoingBackward = true;
                    for (int i = 0; i < 15; i++)
                    {
                        lock (this)
                        {
                            Player.Position = new System.Drawing.Point(Player.Position.X - 8, Player.Position.Y);
                        }
                        await Task.Delay(1);
                    }
                    IsGoingBackward = false;
                });
            if (!IsGoingBackward)
            {
                backward.Start();
            }
        }

        public void Jump()
        {
            Task jump = new Task(
                async () =>
                {
                    IsJumping = true;
                    for (int i = 10; i > 0; i--)
                    {
                        lock (this)
                        {
                            Player.Position = new System.Drawing.Point(Player.Position.X, Player.Position.Y - 7 * i);
                        }
                        await Task.Delay(3 * i);
                    }
                    await Task.Delay(100);
                    for (int i = 1; i <= 10; i++)
                    {
                        lock (this)
                        {
                            Player.Position = new System.Drawing.Point(Player.Position.X, Player.Position.Y + 7 * i);
                        }
                        await Task.Delay(3 * i);
                    }
                    IsJumping = false;
                });
            if (!IsJumping)
            {
                jump.Start();
            }

        }
        // For this we might need an additional prop in models rotation, and then here only change that and when render draw it will rotate to the right direction
        // But here still, we need to calc angle, how???
        public void SetDirection(System.Windows.Point mousePosition)
        {
            if (Player.Inventory.SelectedItem != null)
            {
                Player.Inventory.SelectedItem.DirectionToLook = new System.Drawing.Point((int)mousePosition.X, (int)mousePosition.Y);
            }

            if (mousePosition.X > Player.Position.X)
            {
                Player.IsTransform = true;
            }
            else
            {
                Player.IsTransform = false;
            }
        }


    }
}
