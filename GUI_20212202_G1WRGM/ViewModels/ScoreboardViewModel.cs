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
        //Mediaplayer is kinda slow on responding when the music has just started.
        //public static MediaPlayer mediaPlayer = new MediaPlayer();

        public ICommand StartDefaultOSTCommand { get; set; }
        public ICommand StartDoomEternalOSTCommand { get; set; }
        public ICommand StartDoom2016OSTCommand { get; set; }
        public ICommand StartNeedyStreamerOverloadOSTCommand { get; set; }
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
                }
                );

            StartDoomEternalOSTCommand = new RelayCommand(
                () =>
                {
                    mediaPlayer.Stop();
                    mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "mainMenu_DoomEternal.mp3"), UriKind.RelativeOrAbsolute));
                    mediaPlayer.Play();
                });

            StartDoom2016OSTCommand = new RelayCommand(
                () =>
                {
                    mediaPlayer.Stop();
                    mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "mainMenu_Doom2016.mp3"), UriKind.RelativeOrAbsolute));
                    mediaPlayer.Play();
                });

            StartNeedyStreamerOverloadOSTCommand = new RelayCommand(
                () =>
                {
                    mediaPlayer.Stop();
                    mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "mainMenu_NSO.mp3"), UriKind.RelativeOrAbsolute));
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