using GUI_20212202_G1WRGM.Others;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace GUI_20212202_G1WRGM.ViewModels
{
    public class GameLevelViewModel : BaseViewModel, IPageViewModel
    {
        Random r = new Random();

        public ICommand StartDoomOSTCommand { get; set; }
        public ICommand StartCrusaderOSTCommand { get; set; }
        public ICommand StartWeebOSTCommand { get; set; }
        public ICommand CloseGameCommand { get; set; }
        public ICommand LoadLevelCommand { get; set; }


        public GameLevelViewModel()
        {
            StartDoomOSTCommand = new RelayCommand(
                () =>
                {
                    mediaPlayer.Stop();
                    if (r.Next(0, 2) == 0) { mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "Youtube", "CultistBase.mp3"), UriKind.RelativeOrAbsolute)); }
                    else { mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "Youtube", "TheOnlyThing.mp3"), UriKind.RelativeOrAbsolute)); }
                    mediaPlayer.Play();
                    currentlySelectedOST = OST.Doom;
                });

            StartCrusaderOSTCommand = new RelayCommand(
                () =>
                {
                    mediaPlayer.Stop();
                    mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "Youtube", "ArmyOfTheNight.mp3"), UriKind.RelativeOrAbsolute));
                    mediaPlayer.Play();
                    currentlySelectedOST = OST.Crusader;
                });

            StartWeebOSTCommand = new RelayCommand(
                () =>
                {
                    mediaPlayer.Stop();
                    if (r.Next(0, 2) == 0) { mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "Youtube", "JojoTheme.mp3"), UriKind.RelativeOrAbsolute)); }
                    else if (r.Next(0, 2) == 0) { mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "Youtube", "ChikaDance.mp3"), UriKind.RelativeOrAbsolute)); }
                    else { mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "Youtube", "BlendS.mp3"), UriKind.RelativeOrAbsolute)); }
                    mediaPlayer.Play();
                    currentlySelectedOST = OST.Weebshit;
                });

            CloseGameCommand = new RelayCommand(
                () =>
                {
                    mediaPlayer.Stop();
                    mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "XPShutdown.mp3"), UriKind.RelativeOrAbsolute));
                    mediaPlayer.Play();
                    mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;
                });

            LoadLevelCommand = new RelayCommand(
                () =>
                {
                    mediaPlayer.MediaEnded += SussySound_MediaEnded;
                }
                );
        }

        private void SussySound_MediaEnded(object sender, EventArgs e)
        {
            switch (currentlySelectedOST)
            {
                case OST.Doom:
                    if (r.Next(0, 2) == 0) { mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "Youtube", "CultistBase.mp3"), UriKind.RelativeOrAbsolute)); }
                    else { mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "Youtube", "TheOnlyThing.mp3"), UriKind.RelativeOrAbsolute)); }
                    break;
                case OST.Crusader:
                    mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "Youtube", "ArmyOfTheNight.mp3"), UriKind.RelativeOrAbsolute));
                    break;
                case OST.Weebshit:
                    if (r.Next(0, 2) == 0) { mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "Youtube", "JojoTheme.mp3"), UriKind.RelativeOrAbsolute)); }
                    else if (r.Next(0, 2) == 0) { mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "Youtube", "ChikaDance.mp3"), UriKind.RelativeOrAbsolute)); }
                    else { mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "Youtube", "BlendS.mp3"), UriKind.RelativeOrAbsolute)); }
                    break;
                default:
                    break;
            }
            mediaPlayer.Play();
        }

        private void MediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            //Starts sound
           
        }
    }
}
