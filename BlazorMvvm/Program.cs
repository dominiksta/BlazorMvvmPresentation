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

builder.Services.AddDynamicItemViewModels();
builder.Services.AddSingleton<IViewModelRegistry, ViewModelRegistry>();

var dialogController = new FluentVmDialogController();
dialogController.Register<TestDialogView, TestDialogViewModel>();
builder.Services.AddSingleton<BlazorVmDialogController>(dialogController);
builder.Services.AddSingleton<IVmDialogController>(dialogController);

var app = builder.Build();

BlazorMvvm.SourceGeneratedViewModelRegistrations
    .Register(app.Services.GetRequiredService<IViewModelRegistry>());

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