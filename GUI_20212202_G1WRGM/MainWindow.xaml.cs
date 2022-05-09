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
using System.IO;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using Microsoft.Win32;

namespace GUI_20212202_G1WRGM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        static Random r = new Random();
        public MediaPlayer mediaPlayer = new MediaPlayer();

        public MainWindow()
        {
            InitializeComponent();
        }

        //Creates a Listbox for the scoreboard
        private void Scoreboard_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            //Removes all objects in the grid, like buttons, labels, stackpanels etc except the Display.
            //foreach (var item in grid.Children)
            //{
            //    if (item is StackPanel)
            //    {
            //        (item as StackPanel).Children.Clear();
            //    }
            //}

            //Starts sound
            mediaPlayer.Stop();
            mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "imgonnacoom.mp3"), UriKind.RelativeOrAbsolute));
            mediaPlayer.Play();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }
    }
}
