using GUI_20212202_G1WRGM.Renderer;
using Logic;
using Logic.Interfaces;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_20212202_G1WRGM.ViewModels
{
    public class GameWindowViewModel : ObservableRecipient
    {
        public ObservableCollection<Map> Maps { get; set; }
        public ObservableCollection<Character> Characters { get; set; }
        public ObservableCollection<Item> Items { get; set; }
        public ObservableCollection<WorldBuildingElement> WorldBuildingElements { get; set; }
        // ide kellene majd bekötni a rendereket és a logicot? 
        // lehet hogy itt kéne a főbb dolgokat megírni és összekötni, ezáltal a display cuccok csak annyit csinálnak, hogy kapnak egy mapet, rajzolnak
        // kapnak egy karakter listát, rajzolnak stb. és akkor itt lehetne őket invalidattel hívogatni, a dispatchert is bekötni + a logiccal valahogy összevarázsolni ??

        // itt a rajzolgatós bizbaszokat egyelőre strongly coupled függőségekkel oldom meg de később lehet interfésszel dependecy inversion aztán valahogy beinjektálni
        MapDisplay mapDisplay;
        CharacterDisplay characterDisplay;
        ItemDisplay itemDisplay;
        WorldBuildingElementDisplay worldBuildingElementDisplay;

        public void Init(MapDisplay mapDisplay, CharacterDisplay characterDisplay, ItemDisplay itemDisplay, WorldBuildingElementDisplay worldBuildingElementDisplay)
        {
            this.mapDisplay = mapDisplay;
            this.characterDisplay = characterDisplay;
            this.itemDisplay = itemDisplay;
            this.worldBuildingElementDisplay = worldBuildingElementDisplay;
        }

        // aztán akkor kéne a logic is valahogy
        IMapLogic mapLogic;
        ICharacterLogic characterLogic;
        IItemLogic itemLogic;
        IWorldBuildingElementLogic worldBuildingElementLogic;

        public GameWindowViewModel(IMapLogic mapLogic, ICharacterLogic characterLogic, IItemLogic itemLogic, IWorldBuildingElementLogic worldBuildingElementLogic)
        {
            this.mapLogic = mapLogic;
            this.characterLogic = characterLogic;
            this.itemLogic = itemLogic;
            this.worldBuildingElementLogic = worldBuildingElementLogic;

            Maps = new ObservableCollection<Map>();
            Characters = new ObservableCollection<Character>();
            Items = new ObservableCollection<Item>();
            WorldBuildingElements = new ObservableCollection<WorldBuildingElement>();

            // later refactor this to logic
            mapLogic.ReadAll().ToList().ForEach(map => Maps.Add(map));
            characterLogic.ReadAll().ToList().ForEach(character => Characters.Add(character));
            itemLogic.ReadAll().ToList().ForEach(item => Items.Add(item));
            worldBuildingElementLogic.ReadAll().ToList().ForEach(worldBuildingElement => WorldBuildingElements.Add(worldBuildingElement));

        }
    }
}
