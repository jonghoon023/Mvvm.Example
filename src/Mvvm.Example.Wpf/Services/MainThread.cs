using Mvvm.Example.Abstractions.Views;
using System.Windows.Threading;

namespace Mvvm.Example.Wpf.Services;

/// <summary>
/// Implementation of the <see cref="IMainThread" /> interface.
/// </summary>
internal sealed class MainThread : IMainThread
{
    /// <inheritdoc cref="IMainThread.Invoke(Action)" />
    public void Invoke(Action callback)
    {
        Dispatcher.CurrentDispatcher.Invoke(callback);
    }

    /// <inheritdoc cref="IMainThread.Invoke{T}(Func{T})" />
    public T Invoke<T>(Func<T> callback)
    {
        return Dispatcher.CurrentDispatcher.Invoke(callback);
    }

    /// <inheritdoc cref="IMainThread.InvokeAsync(Action)" />
    public async Task InvokeAsync(Action callback)
    {
        await Dispatcher.CurrentDispatcher.InvokeAsync(callback);
    }

    /// <inheritdoc cref="IMainThread.InvokeAsync(Func{Task})" />
    public async Task InvokeAsync(Func<Task> callback)
    {
        await Dispatcher.CurrentDispatcher.InvokeAsync(callback);
    }
}
