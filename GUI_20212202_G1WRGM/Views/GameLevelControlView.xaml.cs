using GUI_20212202_G1WRGM.ViewModels;
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

namespace GUI_20212202_G1WRGM.Views
{
    /// <summary>
    /// Interaction logic for GameLevelControlView.xaml
    /// </summary>
    public partial class GameLevelControlView : UserControl
    {
        static Random r = new Random();

        public GameLevelControlView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //Adds main menu's background for the illusion of still being on the main menu
            grid.Background = new ImageBrush(new BitmapImage(new Uri(System.IO.Path.Combine("Assets", "Background", "MainMenuBackground.png"), UriKind.RelativeOrAbsolute)));

            //Plays sussy sound
            GameLevelViewModel.mediaPlayer.Stop();
            GameLevelViewModel.mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "amongUsEmergency.mp3"), UriKind.RelativeOrAbsolute));
            GameLevelViewModel.mediaPlayer.Play();

            //Loads the level when the sus stops
            GameLevelViewModel.mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //mapDisplay.Resize(new System.Drawing.Size((int)grid.ActualWidth, (int)grid.ActualHeight));
            //characterDisplay.Resize(new System.Drawing.Size((int)grid.ActualWidth, (int)grid.ActualHeight));
            //itemDisplay.Resize(new System.Drawing.Size((int)grid.ActualWidth, (int)grid.ActualHeight));
            //worldBuildingElementDisplay.Resize(new System.Drawing.Size((int)grid.ActualWidth, (int)grid.ActualHeight));
            //mapDisplay.InvalidateVisual();
            //characterDisplay.InvalidateVisual();
            //itemDisplay.InvalidateVisual();
            //worldBuildingElementDisplay.InvalidateVisual();
        }

        private void MediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            //Removes all objects in the grid, like buttons, labels, stackpanels etc except the Display.
            foreach (var item in grid.Children)
            {
                if (item is StackPanel)
                {
                    (item as StackPanel).Children.Clear();
                }
            }

            //Map list
            List<Map> maps = new List<Map>();
            maps.Add(new Map()
            {
                PathToImg = new Uri(System.IO.Path.Combine("Assets", "Levels", "Youtube", "bunnygirlcpp.jpg"), UriKind.RelativeOrAbsolute),
                Level = 1,
                Size = new System.Drawing.Size((int)grid.ActualWidth, (int)grid.ActualHeight),
                Characters = new List<Character>(),
                Items = new List<Item>(),
                WorldElements = new List<WorldBuildingElement>()
            });

            //Character list (player and enemies)
            List<Character> characters = new List<Character>()
            {
                new Player() { Name = "Player", PathToImg = new Uri(System.IO.Path.Combine("Assets", "Characters", "Players", "Chad.png"), UriKind.RelativeOrAbsolute),
                            Inventory = new Inventory() { PathToSelectedItemImg = new Uri(System.IO.Path.Combine("Assets", "Items", "Weapons", "SuperShotgun.png"), UriKind.RelativeOrAbsolute) }},
                new NPC() { Name = "NPC1", PathToImg = new Uri(System.IO.Path.Combine("Assets", "Characters", "NPCS", "TwistBrainlet.png"), UriKind.RelativeOrAbsolute), 
                            PathToWeaponImg = new Uri(System.IO.Path.Combine("Assets", "Items", "Weapons", "Watergun.png"), UriKind.RelativeOrAbsolute) },
                new NPC() { Name = "NPC2", PathToImg = new Uri(System.IO.Path.Combine("Assets", "Characters", "NPCS", "TwistBrainlet.png"), UriKind.RelativeOrAbsolute),
                            PathToWeaponImg = new Uri(System.IO.Path.Combine("Assets", "Items", "Weapons", "Watergun.png"), UriKind.RelativeOrAbsolute) },
            };

            //Item List (collectibles, weapons etc)
            List<Item> items = new List<Item>()
            {
                new Weapon() { Name = "Super Shotgun", IsPickedUp = false, PathToImg = new Uri(System.IO.Path.Combine("Assets", "Items", "Weapons", "SuperShotgun.png"), UriKind.RelativeOrAbsolute) },
                new Weapon() { Name = "Chaingun", IsPickedUp = false, PathToImg = new Uri(System.IO.Path.Combine("Assets", "Items", "Weapons", "Chaingun.png"), UriKind.RelativeOrAbsolute) },
                new Weapon() { Name = "Chaingun", IsPickedUp = true, PathToImg = new Uri(System.IO.Path.Combine("Assets", "Items", "Weapons", "Chaingun.png"), UriKind.RelativeOrAbsolute) },
            };

            //WorldBuildingElements lists (platforms, walls etc)
            List<WorldBuildingElement> worldBuildingElements = new List<WorldBuildingElement>();
            for (int i = 0; i < 21; i++)
            {
                worldBuildingElements.Add(new WorldBuildingElement()
                {
                    PathToImg = new Uri(System.IO.Path.Combine("Assets", "Levels", "Youtube", $"yt_platform-{r.Next(1, 3)}.png"),
                UriKind.RelativeOrAbsolute)
                });
            }

            //Set level specific background img
            grid.Background = new ImageBrush(new BitmapImage(maps[0].PathToImg));

            //Setup displays and renders them
            //mapDisplay.SetupMap(maps);
            //worldBuildingElementDisplay.SetupWorldBuildingElements(worldBuildingElements);
            //itemDisplay.SetupItems(items, characterDisplay);
            //characterDisplay.SetupCharacters(characters);
            //mapDisplay.InvalidateVisual();
            //worldBuildingElementDisplay.InvalidateVisual();
            //itemDisplay.InvalidateVisual();
            //characterDisplay.InvalidateVisual();

            //Starts sound
            GameLevelViewModel.mediaPlayer.Stop();
            GameLevelViewModel.mediaPlayer.Open(new Uri(System.IO.Path.Combine("Assets", "Sounds", "Songs", "Youtube", "TheOnlyThing.mp3"), UriKind.RelativeOrAbsolute));
            GameLevelViewModel.mediaPlayer.Play();

            gameWindowViewModel.Init(mapDisplay, characterDisplay, itemDisplay, worldBuildingElementDisplay);
        }

        
    }
}
