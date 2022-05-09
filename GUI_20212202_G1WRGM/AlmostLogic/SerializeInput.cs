using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI_20212202_G1WRGM.AlmostLogic
{
    public class SerializeInput : ObservableRecipient
    {
        PlayerMovementLogic playerMovementLogic = Ioc.Default.GetRequiredService<PlayerMovementLogic>();
        

        public void KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Right:
                    playerMovementLogic.MoveForward();
                    break;
                case Key.D:
                    playerMovementLogic.MoveForward();
                    break;

                case Key.Left:
                    playerMovementLogic.MoveBackward();
                    break;
                case Key.A:
                    playerMovementLogic.MoveBackward();
                    break;

                case Key.Up:
                    playerMovementLogic.Jump();

                    break;
                case Key.W:
                    playerMovementLogic.Jump();
                    break;
               



                default:
                    break;
            }
        }

        public void MouseLeftClick(object sender, System.Windows.Point targetDirection)
        {
            playerMovementLogic.Shoot(targetDirection);
        }

        public void MousePosition(object sender, System.Windows.Point mousePosition)
        {
            playerMovementLogic.SetDirection(mousePosition);
        }
    }
}
