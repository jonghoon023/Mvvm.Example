using Mvvm.Example.Abstractions.ViewModels;
using Mvvm.Example.Abstractions.Views;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;

namespace Mvvm.Example.Wpf.Controls;

/// <summary>
/// Abstract base class that must be inherited by all <see cref="Window" /> instances.
/// </summary>
public abstract class WindowBase : Window, IWindow
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WindowBase" /> class.
    /// </summary>
    /// <param name="locator"> An implementation of <see cref="IViewModelLocator" />. </param>
    protected WindowBase(IViewModelLocator locator)
    {
        ArgumentNullException.ThrowIfNull(locator);
        DataContext = locator.GetViewModelFromViewType<IWindowViewModel>(GetType(), this);

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

    /// <inheritdoc cref="Window.OnClosed(EventArgs)" />
    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);
        (DataContext as IWindowViewModel)?.OnClosed();
    }

    /// <inheritdoc cref="Window.OnClosing(CancelEventArgs)" />
    protected override void OnClosing(CancelEventArgs e)
    {
        ArgumentNullException.ThrowIfNull(e);
        e.Cancel = (DataContext as IWindowViewModel)?.OnClosing() ?? false;
        base.OnClosing(e);
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
