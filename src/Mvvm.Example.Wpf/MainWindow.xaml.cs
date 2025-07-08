using Mvvm.Example.Abstractions.ViewModels;
using Mvvm.Example.Wpf.Controls;

namespace Mvvm.Example.Wpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public sealed partial class MainWindow : WindowBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow" /> class.
    /// </summary>
    /// <param name="locator"> An implementation of <see cref="IViewModelLocator" />. </param>
    public MainWindow(IViewModelLocator locator) : base(locator)
    {
        InitializeComponent();
    }
}
