using GUI_20212202_G1WRGM.Others;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace GUI_20212202_G1WRGM.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;

        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<IPageViewModel>();

                return _pageViewModels;
            }
        }

        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                _currentPageViewModel = value;
                OnPropertyChanged("CurrentPageViewModel");
            }
        }

        public static bool IsInDesignMode
        {
            get
            {
                return
                    (bool)DependencyPropertyDescriptor
                    .FromProperty(DesignerProperties.
                    IsInDesignModeProperty,
                    typeof(FrameworkElement))
                    .Metadata.DefaultValue;
            }
        }

        //public MainViewModel() : this(IsInDesignMode ? null : Ioc.Default.GetService<IGameLogic>()) { }
        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                // Add available pages and set page
                PageViewModels.Add(new MainMenuViewModel());
                PageViewModels.Add(new ScoreboardViewModel());

                CurrentPageViewModel = PageViewModels[0];

                //Messenger.Register<MainWindowViewModel, string, string>(this, "GoTo1Screen", (recipient, msg) =>
                //{
                //    ChangeViewModel(PageViewModels[0]);
                //});
                //Messenger.Register<MainWindowViewModel, string, string>(this, "GoTo2Screen", (recipient, msg) =>
                //{
                //    ChangeViewModel(PageViewModels[1]);
                //});
                Mediator.Subscribe("GoTo1Screen", OnGo1Screen);
                Mediator.Subscribe("GoTo2Screen", OnGo2Screen);


                
            }  
        }

        
        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);
        }

        private void OnGo1Screen(object obj)
        {
            ChangeViewModel(PageViewModels[0]);
        }

        private void OnGo2Screen(object obj)
        {
            ChangeViewModel(PageViewModels[1]);
        }
    }
}
