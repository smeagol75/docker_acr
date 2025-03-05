var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.WebHost.UseUrls($"http://+:{80}");

var application = builder.Build();

application.UseHttpsRedirection();

application.MapGet("/", () => {
    var message = "🔥 This is fine";
    Console.WriteLine(message);
    return message;
});

await application.RunAsync();