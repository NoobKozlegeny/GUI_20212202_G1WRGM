using GUI_20212202_G1WRGM.ViewModels;
using Logic;
using Logic.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;


namespace GUI_20212202_G1WRGM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                    .AddSingleton<Data.DudeDbContext, Data.DudeDbContext>()
                    .AddSingleton<Repository.Interfaces.IMapRepository, Repository.MapRepository>()
                    .AddSingleton<Repository.Interfaces.ICharacterRepository, Repository.CharacterRepository>()
                    .AddSingleton<Repository.Interfaces.IItemRepository, Repository.ItemRepository>()
                    .AddSingleton<Repository.Interfaces.IWorldBuildingElementRepository, Repository.WorldBuildingElementRepository>()
                    .AddSingleton<IMapLogic, MapLogic>()
                    .AddSingleton<IMapLogic, MapLogic>()
                    .AddSingleton<ICharacterLogic, CharacterLogic>()
                    .AddSingleton<IItemLogic, ItemLogic>()
                    .AddSingleton<IWorldBuildingElementLogic, WorldBuildingElementLogic>()
                    .BuildServiceProvider()
                );
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow app = new MainWindow();
            MainWindowViewModel context = new MainWindowViewModel();
            app.DataContext = context;
            app.Show();
        }
    }
}
