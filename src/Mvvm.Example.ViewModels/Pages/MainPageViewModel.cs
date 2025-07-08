using CommunityToolkit.Mvvm.Input;
using Mvvm.Example.ViewModels.Abstractions;

namespace Mvvm.Example.ViewModels.Pages
{
    /// <summary>
    /// ViewModel for the MainPage.
    /// </summary>
    public sealed partial class MainPageViewModel : PageViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPageViewModel" /> class.
        /// </summary>
        /// <param name="navigator"> An implementation of <see cref="INavigator" />. </param>
        public MainPageViewModel(INavigator navigator) : base(navigator)
        {
        }

        [RelayCommand]
        private void OnNavigateToCounterPage()
        {
            Navigator.Push<CounterPageViewModel>();
        }
    }
}
