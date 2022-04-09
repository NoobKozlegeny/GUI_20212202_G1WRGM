using GUI_20212202_G1WRGM.ViewModels;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for MainMenuControlView.xaml
    /// </summary>
    public partial class MainMenuControlView : UserControl
    {
        static Random r = new Random();
        public MediaPlayer mediaPlayer = new MediaPlayer();

        public MainMenuControlView()
        {
            InitializeComponent();
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            //Removes all objects in the grid, like buttons, labels, stackpanels etc except the Display.
            foreach (var item in grid.Children)
            {
                if (item is StackPanel)
                {
                    (item as StackPanel).Children.Clear();
                }
            }

            //Loads Youtube level, duuh
            if (!mediaPlayer.HasAudio)
            {
                LoadYTLevel();
            }  
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            display.Resize(new System.Drawing.Size((int)grid.ActualWidth, (int)grid.ActualHeight));
            characterDisplay.Resize(new System.Drawing.Size((int)grid.ActualWidth, (int)grid.ActualHeight));
            display.InvalidateVisual();
            characterDisplay.InvalidateVisual();
        }

        private void LoadYTLevel()
        {
            //Plays sussy sound
            MainMenuViewModel.mediaPlayer.Stop();
            MainMenuViewModel.mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "amongUsEmergency.mp3"), UriKind.RelativeOrAbsolute));
            MainMenuViewModel.mediaPlayer.Play();

            //Runs when the sus stops
            MainMenuViewModel.mediaPlayer.MediaEnded += MediaPlayer_MediaEnded; 
        }

        private void MediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            //Starts rendering
            Map map = new Map()
            {
                PathToImg = new Uri(System.IO.Path.Combine("Assets", "Levels", "Youtube", "bunnygirlcpp.jpg"), UriKind.RelativeOrAbsolute),
                Level = 1,
                Size = new System.Drawing.Size((int)grid.ActualWidth, (int)grid.ActualHeight),
                Characters = new List<Character>()
                {
                    new Player() { Name = "Player1", PathToImg = new Uri(System.IO.Path.Combine("Assets", "Characters", "Players", "Chad.png"), UriKind.RelativeOrAbsolute) },
                    new NPC() { Name = "NPC1", PathToImg = new Uri(System.IO.Path.Combine("Assets", "Characters", "NPCS", "TwistBrainlet.png"), UriKind.RelativeOrAbsolute) },
                    new NPC() { Name = "NPC2", PathToImg = new Uri(System.IO.Path.Combine("Assets", "Characters", "NPCS", "TwistBrainlet.png"), UriKind.RelativeOrAbsolute) },
                },
                Items = new List<Item>(),
                WorldElements = new List<WorldBuildingElement>()
            };

            //Add platforms
            for (int i = 0; i < 21; i++)
            {
                map.WorldElements.Add(new WorldBuildingElement()
                {
                    PathToImg = new Uri(System.IO.Path.Combine("Assets", "Levels", "Youtube", $"yt_platform-{r.Next(1, 3)}.png"),
                UriKind.RelativeOrAbsolute)
                });
            }

            //Set level specific background img
            grid.Background = new ImageBrush(new BitmapImage(map.PathToImg));

            //Setup displays and renders them
            display.SetupMap(map);
            characterDisplay.SetupMap(map);
            display.InvalidateVisual();
            characterDisplay.InvalidateVisual();

            //Starts sound
            MainMenuViewModel.mediaPlayer.Stop();
            MainMenuViewModel.mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "imgonnacoom.mp3"), UriKind.RelativeOrAbsolute));
            MainMenuViewModel.mediaPlayer.Play();
        }
    }
}
