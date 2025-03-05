var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.WebHost.UseUrls($"http://+:{80}");

var application = builder.Build();

application.UseHttpsRedirection();

application.MapGet("/", () => {
    var name = Environment.GetEnvironmentVariable("NAME");
    var message = $"🔥 This is fine {name}".Trim();
    Console.WriteLine(message);
    return message;
});

await application.RunAsync();