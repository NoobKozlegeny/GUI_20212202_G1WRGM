using GUI_20212202_G1WRGM.Others;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace GUI_20212202_G1WRGM.ViewModels
{
    public class ScoreboardViewModel : BaseViewModel, IPageViewModel
    {
        Random r = new Random();
        //Mediaplayer is kinda slow on responding when the music has just started.
        //public static MediaPlayer mediaPlayer = new MediaPlayer();

        public ICommand StartDefaultOSTCommand { get; set; }
        public ICommand StartDoomOSTCommand { get; set; }
        public ICommand StartCrusaderOSTCommand { get; set; }
        public ICommand StartWeebOSTCommand { get; set; }
        public ICommand CloseGameCommand { get; set; }

        private ICommand goToMainMenu;

        public ICommand GoToMainMenu
        {
            get
            {
                return goToMainMenu ?? (goToMainMenu = new RelayCommand(() =>
                {
                    Mediator.Notify("GoToMainMenu", "");
                }));
            }
        }

        public ScoreboardViewModel()
        {
            StartDefaultOSTCommand = new RelayCommand(
                () =>
                {
                    DispatcherTimer dt = new DispatcherTimer(TimeSpan.Zero, DispatcherPriority.ApplicationIdle, DispatcherTimer_Tick, Application.Current.Dispatcher)
                    {
                        Interval = TimeSpan.FromMinutes(5)
                    };
                    dt.Start();
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
                });

            StartCrusaderOSTCommand = new RelayCommand(
                () =>
                {
                    mediaPlayer.Stop();
                    mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "mainMenu_MarchTemplars.mp3"), UriKind.RelativeOrAbsolute));
                    mediaPlayer.Play();
                });

            StartWeebOSTCommand = new RelayCommand(
                () =>
                {
                    mediaPlayer.Stop();
                    if (r.Next(0, 2) == 0) { mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "mainMenu_NSO.mp3"), UriKind.RelativeOrAbsolute)); }
                    else { mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "mainMenu_BoobaSword.mp3"), UriKind.RelativeOrAbsolute)); }
                    mediaPlayer.Play();
                });

            CloseGameCommand = new RelayCommand(
                () =>
                {
                    mediaPlayer.Stop();
                    mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "XPShutdown.mp3"), UriKind.RelativeOrAbsolute));
                    mediaPlayer.Play();
                    mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;
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