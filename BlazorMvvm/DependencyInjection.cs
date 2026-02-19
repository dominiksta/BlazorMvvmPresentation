using BlazorMvvm.Components.Pages.DynamicItems;
using BlazorMvvm.Components.Pages.DynamicItems.DynamicItem1;
using BlazorMvvm.Components.Pages.DynamicItems.DynamicItem2;

namespace BlazorMvvm;

internal static class DependencyInjection
{
    public static void AddDynamicItemViewModels(this IServiceCollection services)
    {
        // scoped in this context means: one per circuit, meaning one per page-load
        services.AddScoped<IDynamicItemViewModel, DynamicItem1ViewModel>();
        // we can also use AddTransient, which would mean a new instance every time one is requested
        services.AddTransient<IDynamicItemViewModel, DynamicItem2ViewModel>();
    }
}