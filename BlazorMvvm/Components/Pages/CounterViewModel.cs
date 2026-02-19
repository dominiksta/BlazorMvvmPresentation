using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BlazorMvvm.Components.Pages;

public partial class CounterViewModel : ObservableObject
{
    public int Count
    {
        get;
        set
        {
            SetProperty(ref field, value);
            IncrementCountCommand.NotifyCanExecuteChanged();
        }
    }

    public readonly RelayCommand IncrementCountCommand;
    
    public CounterViewModel()
    {
        IncrementCountCommand = new RelayCommand(() => Count++, IncrementEnabled);
    }
    
    private bool IncrementEnabled() => Count < 10;
    
    // [ObservableProperty]
    // private int _count;
    //
    // [RelayCommand(CanExecute = nameof(IncrementEnabled))]
    // private void IncrementCount() => Count++;
}