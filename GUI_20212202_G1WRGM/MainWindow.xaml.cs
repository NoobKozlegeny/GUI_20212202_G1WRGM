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
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Logic.Interfaces;
using GUI_20212202_G1WRGM.Renderer;
using Models.SystemComponents;
using GUI_20212202_G1WRGM.AlmostLogic;

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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //display.Resize(new System.Drawing.Size((int)grid.ActualWidth, (int)grid.ActualHeight));
            //characterDisplay.Resize(new System.Drawing.Size((int)grid.ActualWidth, (int)grid.ActualHeight));
            //display.InvalidateVisual();
            //characterDisplay.InvalidateVisual();
        }
    }
}
