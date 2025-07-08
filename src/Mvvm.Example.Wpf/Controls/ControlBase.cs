using Mvvm.Example.Abstractions.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Mvvm.Example.Wpf.Controls;

/// <summary>
/// Abstract base class that must be inherited by all control UI components.
/// </summary>
public abstract class ControlBase : UserControl
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ControlBase" /> class.
    /// </summary>
    protected ControlBase()
    {
        Loaded += OnLoaded;
        Unloaded += OnUnloaded;
    }

    /// <inheritdoc cref="FrameworkElement.OnInitialized(EventArgs)" />
    protected override void OnInitialized(EventArgs e)
    {
        base.OnInitialized(e);
        if (DataContext is IViewModel viewModel)
        {
            viewModel.OnInitialized();
            Dispatcher.Invoke(viewModel.OnInitializedAsync);
        }
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        if (DataContext is IViewModel viewModel)
        {
            viewModel.OnLoaded();
            Dispatcher.Invoke(viewModel.OnLoadedAsync);
        }
    }

    private void OnUnloaded(object sender, RoutedEventArgs e)
    {
        if (DataContext is IViewModel viewModel)
        {
            viewModel.OnUnloaded();
            Dispatcher.Invoke(viewModel.OnUnloadedAsync);
        }
    }
}
