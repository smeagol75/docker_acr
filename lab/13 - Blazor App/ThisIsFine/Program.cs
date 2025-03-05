using ThisIsFine.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();


builder.WebHost.UseUrls($"http://+:{80}");


var application = builder.Build();

if (!application.Environment.IsDevelopment())
{
    application.UseExceptionHandler("/Error", createScopeForErrors: true);
    application.UseHsts();
}

application.UseHttpsRedirection();

application.UseAntiforgery();

application.MapStaticAssets();
application.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

application.Run();
