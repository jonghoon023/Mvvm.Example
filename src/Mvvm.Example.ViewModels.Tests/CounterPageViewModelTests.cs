using Moq;
using Mvvm.Example.ViewModels.Abstractions;
using Mvvm.Example.ViewModels.Pages;

namespace Mvvm.Example.ViewModels.Tests;

/// <summary>
/// Contains unit tests for the <see cref="CounterPageViewModel" /> class.
/// </summary>
[TestClass]
public sealed class CounterPageViewModelTests
{
    /// <summary>
    /// Given the initial counter value is zero, when the <see cref="CounterPageViewModel.IncrementCommand" /> is executed, then the counter value should be incremented to one.
    /// </summary>
    [TestMethod]
#pragma warning disable CA1707 // Identifiers should not contain underscores
    public void GivenInitialCounter_WhenIncrementCommandExecuted_ThenCounterShouldBeOne()
#pragma warning restore CA1707 // Identifiers should not contain underscores
    {
        // Given
        INavigator navigator = CreateMockNavigator();
        CounterPageViewModel viewModel = new(navigator);

        // When
        viewModel.IncrementCommand.Execute(null);

        // Then
        Assert.AreEqual(1, viewModel.Counter);
    }

    private static INavigator CreateMockNavigator()
    {
        return Mock.Of<INavigator>();
    }
}
