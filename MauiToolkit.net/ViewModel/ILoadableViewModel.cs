namespace MauiToolkit.ViewModel;

public interface ILoadableViewModel<T>
{
    Task LoadAsync(T parameter);
}