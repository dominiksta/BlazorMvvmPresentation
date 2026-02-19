using CommunityToolkit.Mvvm.ComponentModel;
using Dmnk.Blazor.Mvvm;

namespace BlazorMvvm.Components.Pages.DynamicItems.DynamicItem1;

[ViewModelFor(typeof(DynamicItem1View))]
public partial class DynamicItem1ViewModel : DynamicItemViewModelBase
{
    public override string Name => "Dynamic Item 1";
    
    [ObservableProperty]
    private int _counter;
}