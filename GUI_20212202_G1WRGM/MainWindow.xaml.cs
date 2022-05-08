using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.IO;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using Microsoft.Win32;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Logic.Interfaces;
using GUI_20212202_G1WRGM.Renderer;
using Models.SystemComponents;
using GUI_20212202_G1WRGM.AlmostLogic;

namespace GUI_20212202_G1WRGM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SerializeInput serializeInput;
        CharacterDisplay characterDisplay = Ioc.Default.GetService<CharacterDisplay>();
        public MainWindow()
        {
            InitializeComponent();
            //var air = (this.gameVMGrid.DataContext as ViewModels.GameWindowViewModel);
            
            //(this.DataContext as MapDisplay).TickProcess();

            gameVMGrid.Children.Add(Ioc.Default.GetService<MapDisplay>());
            gameVMGrid.Children.Add(characterDisplay);
            gameVMGrid.Children.Add(Ioc.Default.GetService<ItemDisplay>());
            gameVMGrid.Children.Add(Ioc.Default.GetService<WorldBuildingElementDisplay>());
            serializeInput = new SerializeInput();

            air.StartGame();
            
            

            //Ioc.Default.GetService<Data.DudeDbContext>();

            //Ioc.Default.GetService<Data.DudeDbContext>();

            //Ioc.Default.GetService<Repository.Interfaces.IMapRepository>();

            //Ioc.Default.GetService<Repository.Interfaces.ICharacterRepository>();

            //Ioc.Default.GetService<Repository.Interfaces.IItemRepository>();

            //Ioc.Default.GetService<Repository.Interfaces.IWorldBuildingElementRepository>();

            //Ioc.Default.GetService<IMapLogic>();

            //Ioc.Default.GetService<ICharacterLogic>();

            //Ioc.Default.GetService<IItemLogic>();

            //Ioc.Default.GetService<IWorldBuildingElementLogic>();


        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            serializeInput.KeyDown(sender, e);
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            serializeInput.MousePosition(sender, e.GetPosition(gameVMGrid));
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            serializeInput.MouseLeftClick(sender, e);
        }
    }
}
