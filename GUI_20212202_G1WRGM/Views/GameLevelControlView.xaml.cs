using GUI_20212202_G1WRGM.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GUI_20212202_G1WRGM.Views
{
    /// <summary>
    /// Interaction logic for GameLevelControlView.xaml
    /// </summary>
    public partial class GameLevelControlView : UserControl
    {
        public GameLevelControlView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ////Adds main menu's background for the illusion of still being on the main menu
            grid.Background = new ImageBrush(new BitmapImage(new Uri(System.IO.Path.Combine("Assets", "Background", "MainMenuBackground.png"), UriKind.RelativeOrAbsolute)));

            //Plays sussy sound
            GameLevelViewModel.mediaPlayer.Stop();
            GameLevelViewModel.mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "amongUsEmergency.mp3"), UriKind.RelativeOrAbsolute));
            GameLevelViewModel.mediaPlayer.Play();

            ////Loads the level when the sus stops
            GameLevelViewModel.mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void MediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            ////Set level specific background img
            grid.Background = new ImageBrush(new BitmapImage(new Uri(System.IO.Path.Combine("Assets", "Levels", "Youtube", "bunnygirlcpp.jpg"), UriKind.RelativeOrAbsolute)));

            ////Starts sound
            GameLevelViewModel.mediaPlayer.Stop();
            GameLevelViewModel.mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "Youtube", "TheOnlyThing.mp3"), UriKind.RelativeOrAbsolute));
            GameLevelViewModel.mediaPlayer.Play();

            gameWindowViewModel.Init(mapDisplay, characterDisplay, itemDisplay, worldBuildingElementDisplay);
        }

        
    }
}
