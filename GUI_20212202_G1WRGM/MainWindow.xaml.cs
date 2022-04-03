﻿using System;
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
using System.Windows.Shapes;

namespace GUI_20212202_G1WRGM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //GameLogic logic;
        public MainWindow()
        {
            InitializeComponent();
        }

        //Creates a Listbox for the scoreboard
        private void Scoreboard_Click(object sender, RoutedEventArgs e)
        {
            ListBox listBox = new ListBox()
            {
                Margin = new Thickness((int)(grid.ActualWidth * 0.03))
            };
            Grid.SetColumn(listBox, 2);

            grid.Children.Add(listBox);
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            //Removes all objects in the grid, like buttons, labels, stackpanels etc.
            grid.Children.Clear();

            //display.SetupLogic(new GameLogic((int)grid.ActualWidth, (int)grid.ActualHeight));
            display.InvalidateVisual();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //display.SetupLogic(new GameLogic((int)grid.ActualWidth, (int)grid.ActualHeight));
            display.InvalidateVisual();
        }
    }
}
