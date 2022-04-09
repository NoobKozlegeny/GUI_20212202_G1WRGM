using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace GUI_20212202_G1WRGM
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public MediaPlayer mediaPlayer = new MediaPlayer();
        
        public ICommand StartDoomEternalOSTCommand { get; set; }
        public ICommand StartDoom2016OSTCommand { get; set; }
        public ICommand StartNeedyStreamerOverloadOSTCommand { get; set; }


        public MainWindowViewModel()
        {
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

        }
    }
}
