using Eqwel.Interfaces;
using Eqwel.ViewModels;

namespace Eqwel.Service
{
    public class ViewModelLocatorService : IViewModelLocator
    {
        private StartPageViewModel _startPageViewModel;
        public StartPageViewModel StartPageViewModel => _startPageViewModel ?? (_startPageViewModel = new StartPageViewModel());

        public ViewModelLocatorService()
        {
            _startPageViewModel = new StartPageViewModel();
        }
    }

}
