using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace GUI_20212202_G1WRGM
{
    public class MainWindowViewModel : ObservableRecipient
    {
        //Slow on responding
        public static MediaPlayer mediaPlayer = new MediaPlayer();

        public ICommand StartDefaultOSTCommand { get; set; }
        public ICommand StartDoomEternalOSTCommand { get; set; }
        public ICommand StartDoom2016OSTCommand { get; set; }
        public ICommand StartNeedyStreamerOverloadOSTCommand { get; set; }
        public ICommand CloseGameCommand { get; set; }

        public MainWindowViewModel()
        {
            StartDefaultOSTCommand = new RelayCommand(
                () =>
                {
                    DispatcherTimer dt = new DispatcherTimer(TimeSpan.Zero, DispatcherPriority.ApplicationIdle, dispatcherTimer_Tick, Application.Current.Dispatcher);
                    dt.Interval = TimeSpan.FromMinutes(5);
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

        private static void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "mainMenu_DoomEternal.mp3"), UriKind.RelativeOrAbsolute));
            mediaPlayer.Play();
        }
    }
}
