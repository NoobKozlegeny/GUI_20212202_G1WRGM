using GUI_20212202_G1WRGM.AlmostLogic;
using GUI_20212202_G1WRGM.Renderer;
using GUI_20212202_G1WRGM.ViewModels;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
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
using System.Windows.Shapes;

namespace GUI_20212202_G1WRGM.Views
{
    /// <summary>
    /// Interaction logic for GameLevelControlView.xaml
    /// </summary>
    public partial class GameLevelControlView : UserControl
    {
        static Random r = new Random();
        SerializeInput serializeInput;
        CharacterDisplay characterDisplay = Ioc.Default.GetService<CharacterDisplay>();
        public GameLevelControlView()
        {
            Ioc.Default.GetService<Data.DudeDbContext>();

            InitializeComponent();
            //var air = (this.gameVMGrid.DataContext as ViewModels.GameWindowViewModel);

            //(this.DataContext as MapDisplay).TickProcess();

            gameVMGrid.Children.Add(Ioc.Default.GetService<MapDisplay>());
            gameVMGrid.Children.Add(characterDisplay);
            gameVMGrid.Children.Add(Ioc.Default.GetService<ItemDisplay>());
            gameVMGrid.Children.Add(Ioc.Default.GetService<WorldBuildingElementDisplay>());

            gameWindowViewModel.StartGame();
            serializeInput = new SerializeInput();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //Adds main menu's background for the illusion of still being on the main menu
            grid.Background = new ImageBrush(new BitmapImage(new Uri(System.IO.Path.Combine("Assets", "Background", "GameLevelBackground.png"), UriKind.RelativeOrAbsolute)));

            //Plays sussy sound
            GameLevelViewModel.mediaPlayer.Stop();
            GameLevelViewModel.mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "amongUsEmergency.mp3"), UriKind.RelativeOrAbsolute));
            GameLevelViewModel.mediaPlayer.Play();

            //Loads the level when the sus stops
            GameLevelViewModel.mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;
        }

        private void MediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            //Removes all objects in the grid, like buttons, labels, stackpanels etc except the Display.
            foreach (var item in grid.Children)
            {
                if (item is StackPanel)
                {
                    (item as StackPanel).Children.Clear();
                }
            }

            //grid.Background = new ImageBrush(new BitmapImage(new Uri(System.IO.Path.Combine("Assets", "Background", "GameLevelBackground.png"), UriKind.RelativeOrAbsolute)));

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
            serializeInput.MouseLeftClick(sender, e.MouseDevice.GetPosition(this));
        }
    }
}
