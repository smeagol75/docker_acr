var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls($"http://+:{80}");

// 🚩 from here...

builder.Services.AddAzureAppConfiguration();
builder.Configuration.AddAzureAppConfiguration(options =>
{
    var connectionString = Environment.GetEnvironmentVariable("APP_CONFIGURATION_CONNECTION_STRING");
    var environment = Environment.GetEnvironmentVariable("LABEL");

    options.Connect(connectionString);
    options.Select("*", environment);
    options.ConfigureRefresh(refreshConfig =>
    {
        refreshConfig.Register("SENTINEL", environment, true);
        refreshConfig.SetRefreshInterval(TimeSpan.FromSeconds(60));
    });
});

// 🚩 ... to here

var application = builder.Build();

application.UseAzureAppConfiguration(); // 🚩 and this line too

application.UseHttpsRedirection();

application.MapGet("/", () => {
    var message = $"{application.Configuration["Docker:Emoji"]} ({Environment.GetEnvironmentVariable("LABEL")})";
    Console.WriteLine(message);
    return message;
});


await application.RunAsync();