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
using System.Windows.Shapes;
using System.Linq;

namespace GUI_20212202_G1WRGM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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

            //Updates visual
            display.InvalidateVisual();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Starts rendering
            Map map = new Map()
            {
                Level = 1,
                Size = new System.Drawing.Size((int)grid.ActualWidth, (int)grid.ActualHeight),
                Characters = new List<Character>(),
                Items = new List<Item>(),
                WorldElements = new List<WorldBuildingElement>(),
            };
            display.SetupMap(map);
        }
    }
}
