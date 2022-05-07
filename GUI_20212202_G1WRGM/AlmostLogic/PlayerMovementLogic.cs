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

namespace GUI_20212202_G1WRGM.AlmostLogic
{
    public class PlayerMovementLogic
    {
        public Player Player { get; set; }
        public bool IsJumping { get; set; }
        public PlayerMovementLogic()
        {
            Player = Ioc.Default.GetService<CharacterDisplay>().Player;
        }
        public void MoveForward()
        {
            Player.Position = new System.Drawing.Point(Player.Position.X+25, Player.Position.Y);
        }
        public void MoveBackward()
        {
            Player.Position = new System.Drawing.Point(Player.Position.X-25, Player.Position.Y);
        }

        public void Jump()
        {

            Task jump = new Task(
                async () =>
                {
                    for (int i = 10; i > 0; i--)
                    {
                        Player.Position = new System.Drawing.Point(Player.Position.X, Player.Position.Y - 5 * i);
                        await Task.Delay(20);
                    }
                    await Task.Delay(40);
                    for (int i = 10; i > 0; i--)
                    {
                        Player.Position = new System.Drawing.Point(Player.Position.X, Player.Position.Y + 5 * i);
                        await Task.Delay(20);
                    }  
                  
                });
            jump.Start();
        }
        // For this we might need an additional prop in models rotation, and then here only change that and when render draw it will rotate to the right direction
        // But here still, we need to calc angle, how???
        public void SetDirection(Point mousePosition)
        {

        }


    }
}
