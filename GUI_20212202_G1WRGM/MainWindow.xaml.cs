﻿using Models;
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
            ListBox listBox = new ListBox()
            {
                Margin = new Thickness((int)(grid.ActualWidth * 0.03))
            };
            Grid.SetColumn(listBox, 2);

            grid.Children.Add(listBox);
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            //Removes all objects in the grid, like buttons, labels, stackpanels etc except the Display.
            foreach (var item in grid.Children)
            {
                if (item is StackPanel)
                {
                    (item as StackPanel).Children.Clear();
                }
            }

            //Starts rendering
            Map map = new Map()
            {
                PathToImg = new Uri(System.IO.Path.Combine("Assets", "Levels", "Youtube", "bunnygirlcpp.jpg"), UriKind.RelativeOrAbsolute),
                Level = 1,
                Size = new System.Drawing.Size((int)grid.ActualWidth, (int)grid.ActualHeight),
                Characters = new List<Character>()
                {
                    new Player() { Name = "Player1", PathToImg = new Uri(System.IO.Path.Combine("Assets", "Characters", "Players", "Chad.png"), UriKind.RelativeOrAbsolute) },
                    new NPC() { Name = "NPC1", PathToImg = new Uri(System.IO.Path.Combine("Assets", "Characters", "NPCS", "TwistBrainlet.png"), UriKind.RelativeOrAbsolute) },
                    new NPC() { Name = "NPC2", PathToImg = new Uri(System.IO.Path.Combine("Assets", "Characters", "NPCS", "TwistBrainlet.png"), UriKind.RelativeOrAbsolute) },
                },
                Items = new List<Item>(),
                WorldElements = new List<WorldBuildingElement>()
            };

            //Add platforms
            for (int i = 0; i < 21; i++)
            {
                map.WorldElements.Add(new WorldBuildingElement() 
                { PathToImg = new Uri(System.IO.Path.Combine("Assets", "Levels", "Youtube", $"yt_platform-{r.Next(1,3)}.png"),
                UriKind.RelativeOrAbsolute) });
            }

            //Set level specific background img
            grid.Background = new ImageBrush(new BitmapImage(map.PathToImg));

            //Setup displays and renders them
            display.SetupMap(map);
            characterDisplay.SetupMap(map);
            display.InvalidateVisual();
            characterDisplay.InvalidateVisual();

            //Starts sound
            mediaPlayer.Stop();
            mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "imgonnacoom.mp3"), UriKind.RelativeOrAbsolute));
            mediaPlayer.Play();
        }

        //TODO: Play songs on load with Behaviors.Wpf nuget package or smth else or binding
        //TODO: Somehow stop this mediaPlayer instance when I start a new song in the ViewModel
        //https://github.com/Microsoft/XamlBehaviorsWpf/wiki/PlaySoundAction
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "mainMenu_DoomEternal.mp3"), UriKind.RelativeOrAbsolute));
            //mediaPlayer.Play();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            display.Resize(new System.Drawing.Size((int)grid.ActualWidth, (int)grid.ActualHeight));
            characterDisplay.Resize(new System.Drawing.Size((int)grid.ActualWidth, (int)grid.ActualHeight));
            display.InvalidateVisual();
            characterDisplay.InvalidateVisual();
        }
    }
}
