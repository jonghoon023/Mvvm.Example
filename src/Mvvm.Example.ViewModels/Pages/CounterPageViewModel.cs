using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mvvm.Example.Models;
using Mvvm.Example.ViewModels.Abstractions;

namespace Mvvm.Example.ViewModels.Pages
{
    /// <summary>
    /// ViewModel for the CounterPage.
    /// </summary>
    public sealed partial class CounterPageViewModel : PageViewModelBase
    {
        private readonly CounterPageModel _model;

        [ObservableProperty]
        private int _counter;

        /// <summary>
        /// Initializes a new instance of the <see cref="CounterPageViewModel" /> class.
        /// </summary>
        /// <param name="navigator"> The navigation service. </param>
        public CounterPageViewModel(INavigator navigator) : base(navigator)
        {
            _model = new CounterPageModel();
            Counter = _model.Counter;
        }

        [RelayCommand]
        private void OnIncrement()
        {
            Counter = _model.Counter = _model.Counter + 1;
        }
    }
}
