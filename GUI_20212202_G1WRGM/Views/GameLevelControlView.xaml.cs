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


            air.StartGame();

            serializeInput = new SerializeInput();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //Adds main menu's background for the illusion of still being on the main menu
            grid.Background = new ImageBrush(new BitmapImage(new Uri(System.IO.Path.Combine("Assets", "Background", "MainMenuBackground.png"), UriKind.RelativeOrAbsolute)));

            //Plays sussy sound
            GameLevelViewModel.mediaPlayer.Stop();
            GameLevelViewModel.mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "amongUsEmergency.mp3"), UriKind.RelativeOrAbsolute));
            GameLevelViewModel.mediaPlayer.Play();

            //Loads the level when the sus stops
            GameLevelViewModel.mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //mapDisplay.Resize(new System.Drawing.Size((int)grid.ActualWidth, (int)grid.ActualHeight));
            //characterDisplay.Resize(new System.Drawing.Size((int)grid.ActualWidth, (int)grid.ActualHeight));
            //itemDisplay.Resize(new System.Drawing.Size((int)grid.ActualWidth, (int)grid.ActualHeight));
            //worldBuildingElementDisplay.Resize(new System.Drawing.Size((int)grid.ActualWidth, (int)grid.ActualHeight));
            //mapDisplay.InvalidateVisual();
            //characterDisplay.InvalidateVisual();
            //itemDisplay.InvalidateVisual();
            //worldBuildingElementDisplay.InvalidateVisual();
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


            //Starts sound
            GameLevelViewModel.mediaPlayer.Stop();
            GameLevelViewModel.mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "Youtube", "TheOnlyThing.mp3"), UriKind.RelativeOrAbsolute));
            GameLevelViewModel.mediaPlayer.Play();

            //gameWindowViewModel.Init(mapDisplay, characterDisplay, itemDisplay, worldBuildingElementDisplay);
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
