using GUI_20212202_G1WRGM.Others;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace GUI_20212202_G1WRGM.ViewModels
{
    public class MainMenuViewModel : BaseViewModel, IPageViewModel
    {
        //Mediaplayer is kinda slow on responding when the music has just started.
        //public static MediaPlayer mediaPlayer = new MediaPlayer();
        public Random r = new Random();

        public ICommand StartDefaultOSTCommand { get; set; }
        public ICommand StartDoomOSTCommand { get; set; }
        public ICommand StartCrusaderOSTCommand { get; set; }
        public ICommand StartWeebOSTCommand { get; set; }
        public ICommand CloseGameCommand { get; set; }
        public ICommand StartGameCommand { get; set; }

        private ICommand goToScoreboard;

        public ICommand GoToScoreboard
        {
            get
            {
                return goToScoreboard ?? (goToScoreboard = new RelayCommand(() =>
                {
                    Mediator.Notify("GoToScoreboard", "");
                }));
            }
        }

        private ICommand goToGameLevel;

        public ICommand GoToGameLevel
        {
            get
            {
                return goToGameLevel ?? (goToGameLevel = new RelayCommand(() =>
                {
                    Mediator.Notify("GoToGameLevel", "");
                }));
            }
        }

        public MainMenuViewModel()
        {
            //Idk why but the song doesn't start automatically when () => !mediaPlayer.HasAudio is in with the DispatcherTimer
            StartDefaultOSTCommand = new RelayCommand(
                () =>
                {
                    //DispatcherTimer dt = new DispatcherTimer(TimeSpan.Zero, DispatcherPriority.ApplicationIdle, DispatcherTimer_Tick, Application.Current.Dispatcher)
                    //{
                    //    Interval = TimeSpan.FromMinutes(5)
                    //};
                    //dt.Start();
                    Thread.Sleep(2);
                    if (r.Next(0, 2) == 0) { mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "mainMenu_DoomEternal.mp3"), UriKind.RelativeOrAbsolute)); }
                    else { mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "mainMenu_Doom2016.mp3"), UriKind.RelativeOrAbsolute)); }
                    mediaPlayer.Play();
                },
                () => !mediaPlayer.HasAudio
                );

            StartDoomOSTCommand = new RelayCommand(
                () =>
                {
                    mediaPlayer.Stop();
                    if (r.Next(0, 2) == 0) { mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "mainMenu_DoomEternal.mp3"), UriKind.RelativeOrAbsolute)); }
                    else { mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "mainMenu_Doom2016.mp3"), UriKind.RelativeOrAbsolute)); }
                    mediaPlayer.Play();
                    BaseViewModel.currentlySelectedOST = OST.Doom;
                });

            StartCrusaderOSTCommand = new RelayCommand(
                () =>
                {
                    mediaPlayer.Stop();
                    mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "mainMenu_MarchTemplars.mp3"), UriKind.RelativeOrAbsolute));
                    mediaPlayer.Play();
                    BaseViewModel.currentlySelectedOST = OST.Crusader;
                });

            StartWeebOSTCommand = new RelayCommand(
                () =>
                {
                    mediaPlayer.Stop();
                    if (r.Next(0, 2) == 0) { mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "mainMenu_NSO.mp3"), UriKind.RelativeOrAbsolute)); }
                    else { mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "mainMenu_BoobaSword.mp3"), UriKind.RelativeOrAbsolute)); }
                    mediaPlayer.Play();
                    BaseViewModel.currentlySelectedOST = OST.Weebshit;
                });

            CloseGameCommand = new RelayCommand(
                () =>
                {
                    mediaPlayer.Stop();
                    mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "XPShutdown.mp3"), UriKind.RelativeOrAbsolute));
                    mediaPlayer.Play();
                    mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;
                });

            StartGameCommand = new RelayCommand(
                () =>
                {
                    //Plays sussy sound
                    //mediaPlayer.Stop();
                    //mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "amongUsEmergency.mp3"), UriKind.RelativeOrAbsolute));
                    //mediaPlayer.Play();

                });
        }
        private void MediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "mainMenu_DoomEternal.mp3"), UriKind.RelativeOrAbsolute));
            mediaPlayer.Play();
        }
    }
}