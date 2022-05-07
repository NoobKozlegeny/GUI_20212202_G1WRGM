using GUI_20212202_G1WRGM.Renderer;
using Logic;
using Logic.Interfaces;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Models;
using Models.SystemComponents;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace GUI_20212202_G1WRGM.ViewModels
{
    public class GameWindowViewModel : ObservableRecipient
    {
        public InnerClock clock = new InnerClock();

        public ObservableCollection<Map> Maps { get; set; }
        public ObservableCollection<Character> Characters { get; set; }
        public ObservableCollection<Item> Items { get; set; }
        public ObservableCollection<WorldBuildingElement> WorldBuildingElements { get; set; }

        public MapDisplay mapDisplay;
        public CharacterDisplay characterDisplay;
        public ItemDisplay itemDisplay;
        public WorldBuildingElementDisplay worldBuildingElementDisplay;

        public void Init(MapDisplay mapDisplay, CharacterDisplay characterDisplay, ItemDisplay itemDisplay, WorldBuildingElementDisplay worldBuildingElementDisplay)
        {
            this.mapDisplay = mapDisplay;
            this.characterDisplay = characterDisplay;
            this.itemDisplay = itemDisplay;
            this.worldBuildingElementDisplay = worldBuildingElementDisplay;
            mapDisplay.SetupMap(Maps);
            characterDisplay.SetupCharacters(Characters);
            itemDisplay.SetupItems(Items, characterDisplay);
            worldBuildingElementDisplay.SetupWorldBuildingElements(WorldBuildingElements);

            
        }

        // aztán akkor kéne a logic is valahogy
        IMapLogic mapLogic;
        ICharacterLogic characterLogic;
        IItemLogic itemLogic;
        IWorldBuildingElementLogic worldBuildingElementLogic;
        public GameWindowViewModel()
            :this(IsInDesignMode ? 
                (null,null,null,null) : 
                (Ioc.Default.GetService<IMapLogic>(), 
                Ioc.Default.GetService<ICharacterLogic>(), 
                Ioc.Default.GetService<IItemLogic>(), 
                Ioc.Default.GetService<IWorldBuildingElementLogic>()))
        {

        }

        public GameWindowViewModel(    (IMapLogic mapLogic, 
                                       ICharacterLogic characterLogic,
                                       IItemLogic itemLogic,
                                       IWorldBuildingElementLogic worldBuildingElementLogic) 
                                       logic)
        {
            this.mapLogic = logic.mapLogic;
            this.characterLogic = logic.characterLogic;
            this.itemLogic = logic.itemLogic;
            this.worldBuildingElementLogic = logic.worldBuildingElementLogic;

            Maps = new ObservableCollection<Map>(mapLogic.ReadAll());
            Characters = new ObservableCollection<Character>(characterLogic.ReadAll());
            Items = new ObservableCollection<Item>(itemLogic.ReadAll());
            WorldBuildingElements = new ObservableCollection<WorldBuildingElement>(worldBuildingElementLogic.ReadAll());

            // later refactor this to logic
            //mapLogic.ReadAll().ToList().ForEach(map => Maps.Add(map));
            //characterLogic.ReadAll().ToList().ForEach(character => Characters.Add(character));
            //itemLogic.ReadAll().ToList().ForEach(item => Items.Add(item));
            //worldBuildingElementLogic.ReadAll().ToList().ForEach(worldBuildingElement => WorldBuildingElements.Add(worldBuildingElement));

            Init(Ioc.Default.GetService<MapDisplay>(), Ioc.Default.GetService<CharacterDisplay>(), Ioc.Default.GetService<ItemDisplay>(), Ioc.Default.GetService<WorldBuildingElementDisplay>());


            clock.Register(mapDisplay);
            clock.Register(worldBuildingElementDisplay);
            clock.Register(characterDisplay);
            clock.Register(itemDisplay);

        }

        public void StartGame()
        {
            clock.Start();
        }




        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
    }
}
