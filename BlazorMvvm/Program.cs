using BlazorMvvm;
using BlazorMvvm.Components;
using BlazorMvvm.Components.Pages.TestDialog;
using Dmnk.Blazor.Dialogs;
using Dmnk.Blazor.Dialogs.Api;
using Dmnk.Blazor.Dialogs.Fluent;
using Dmnk.Blazor.Mvvm;
using Microsoft.FluentUI.AspNetCore.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddFluentUIComponents();

builder.Services.AddSingleton<IViewModelRegistry, ViewModelRegistry>();
builder.Services.AddDynamicItemViewModels();
builder.Services.AddDialogs();

var app = builder.Build();

app.Services.GetRequiredService<IViewModelRegistry>().AddView2ViewModelMappings();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();