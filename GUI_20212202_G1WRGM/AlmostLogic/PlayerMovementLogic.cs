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
        public IList<Rect> WorldBuildingElementGeometries { get; set; }
        public bool IsJumping { get; set; } = false;
        public bool IsGoingForward { get; set; } = false;
        public bool IsGoingBackward { get; set; } = false;
        public bool IsGravityWorking { get; set; } = false;
        public PlayerMovementLogic()
        {
            Player = Ioc.Default.GetService<CharacterDisplay>().Player;
            WorldBuildingElementGeometries = Ioc.Default.GetService<WorldBuildingElementDisplay>().WorldBuildingElementGeometries;
        }

        // mozgásoknál még nézni kell majd hogy ha esetleg valamire fel voltunk ugorva akkor essünk le ha lelépünk
        public void MoveForward()
        {
            if (!IsGravityWorking)
            {
                Gravity();
                IsGravityWorking = true;
            }
            Task forward = new Task(
                async () => 
                {
                    IsGoingForward = true;
                    for (int i = 0; i < 10; i++)
                    {
                        lock (this)
                        {
                            if (CollisionSystem.CollideForward(new Rect(Player.Position.X + 7, Player.Position.Y, Player.Size.Width, Player.Size.Height)))
                            {
                                IsGoingForward = false;
                                return;
                            }
                            Player.Position = new System.Drawing.Point(Player.Position.X + 7, Player.Position.Y);
                        }
                        await Task.Delay(i);
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
                            // test this later
                            if (CollisionSystem.CollideBackward(new Rect(Player.Position.X-8, Player.Position.Y, Player.Size.Width, Player.Size.Height)))
                            {
                                IsGoingBackward = false;
                                return;
                            }
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
                            int tempi = 7;
                            for (int j = 0; j < i; j++)
                            {
                                if (CollisionSystem.CollideUpway(new Rect(Player.Position.X, Player.Position.Y - tempi, Player.Size.Width, Player.Size.Height)))
                                {
                                    Player.Position = new System.Drawing.Point(Player.Position.X, Player.Position.Y - tempi);
                                    IsJumping = false;
                                    return;
                                }
                                tempi += 7;
                            }
                            Player.Position = new System.Drawing.Point(Player.Position.X, Player.Position.Y - 7 * i);
                        }
                        await Task.Delay(2*i);
                    }
                    await Task.Delay(100);
                    for (int i = 1; i <= 10; i++)
                    {
                        lock (this)
                        {
                            if (CollisionSystem.CollideDownway(new Rect(Player.Position.X, Player.Position.Y + 7, Player.Size.Width, Player.Size.Height)))
                            {
                                IsJumping = false;
                                return;
                            }
                            Player.Position = new System.Drawing.Point(Player.Position.X, Player.Position.Y + 7);
                        }
                        await Task.Delay(2*i);
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
        // Ha itt kitöröltem valamit a modelből sorry, conflicton sorozatát oldottam utolsó pushal a sok kódszemét miatt modellekben.....
        public void Shoot()
        {
            if (Player.Inventory.SelectedItem is Weapon weapon)
            {
                //if (weapon.AmmoAmount > 0)
                //{
                //    Player.WillShoot = true;
                //}
                //else
                //{
                //    Player.WillShoot = false;
                //}
            }
        }


        // if player currently not jumping then pull him down until downway collision in every tick?
        // call it once and while true will do the trick
        public void Gravity()
        {
            Task gravity = new Task(
                async () =>
                {
                    while (true)
                    {
                        if (!IsJumping && !CollisionSystem.CollideDownway(new Rect(Player.Position.X, Player.Position.Y, Player.Size.Width, Player.Size.Height)))
                        {
                            lock (this)
                            {
                                Player.Position = new System.Drawing.Point(Player.Position.X, Player.Position.Y + 10);
                            }
                            await Task.Delay(10);
                        }

                    }

                });

            gravity.Start();
        }
    }
}
