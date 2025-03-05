# 08

A **.NET Web API** project that receives environment variables to connect to Azure App Configuration. It also includes Netskope certificates.

## How it works?

### Azure App Configuration

```csharp
var builder = WebApplication.CreateBuilder(args);

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
```

```csharp
var application = builder.Build();

application.UseAzureAppConfiguration();
```

### Minimal API
```csharp
application.MapGet("/", (HttpContext context) => {
    var name = context.Request.Query["name"];
    var message = $"Hello {name} {application.Configuration["Docker:Emoji"]}";
    Console.WriteLine(message);
    return message;
});
```

### Controller
```csharp
[ApiController]
[Route("{*path}")]
public class HelloController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public HelloController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet]
    public IActionResult SayHello([FromQuery] string name)
    {
        return Ok($"Hello {name} {_configuration["Docker:Emoji"]}");
    }
}
```

### Bonus track (feature flags)

[https://learn.microsoft.com/en-us/azure/azure-app-configuration/quickstart-feature-flag-aspnet-core](https://learn.microsoft.com/en-us/azure/azure-app-configuration/quickstart-feature-flag-aspnet-core)

There are two ways to retrieve the feature flags state. By injecting `IFeatureManager` or by using `[FeatureGate]` attribute

```csharp
[ApiController]
[Route("{*path}")]
public class HelloController : ControllerBase
{
    private readonly IFeatureManager _featureManager_;

    public HelloController(IFeatureManager featureManager)
    {
        _featureManager_ = featureManager;
    }

    [HttpGet]
    public IActionResult SayHello()
    {
        if(_featureManager.IsEnabledAsync("SayHello"))
        {
            return Ok($"Hello!");
        }
        else 
        {
            return Ok($"Good bye!");
        }
    }

    [HttpGet]
    [FeatureGate("SayMyName")]
    public IActionResult SayMyName([FromQuery] string name)
    {
        return Ok($"Hello {name}");
    }
}
```

### Run application with `dotnet` command

```shell
dotnet run -e APP_CONFIGURATION_CONNECTION_STRING="Endpoint=https://docker.azconfig.io;Id=oPOj;Secret=7qmmlMKKrrGQNlj4O59jKNSjwIlQGgSB5pM3NinsavvuQVT3sDcGJQQJ99BBACR0EKYVCKRiAAABAZAC3EoI" -e LABEL=dev
```

```shell
dotnet run -e APP_CONFIGURATION_CONNECTION_STRING="Endpoint=https://docker.azconfig.io;Id=oPOj;Secret=7qmmlMKKrrGQNlj4O59jKNSjwIlQGgSB5pM3NinsavvuQVT3sDcGJQQJ99BBACR0EKYVCKRiAAABAZAC3EoI" -e LABEL=pre
```

```shell
dotnet run -e APP_CONFIGURATION_CONNECTION_STRING="Endpoint=https://docker.azconfig.io;Id=oPOj;Secret=7qmmlMKKrrGQNlj4O59jKNSjwIlQGgSB5pM3NinsavvuQVT3sDcGJQQJ99BBACR0EKYVCKRiAAABAZAC3EoI" -e LABEL=pro
```

## Now with Docker

### Initial Dockerfile

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:9.0

WORKDIR /application

COPY . .

RUN dotnet restore
RUN dotnet publish -c Release -o output

WORKDIR /application/output

EXPOSE 80

ENTRYPOINT ["dotnet", "ThisIsFine.dll"]
```

### Build Docker image

```shell
docker build -t netwebapiappconfig .
```

### Run 

```shell
docker run -p 8080:80 -e APP_CONFIGURATION_CONNECTION_STRING="Endpoint=https://docker.azconfig.io;Id=oPOj;Secret=7qmmlMKKrrGQNlj4O59jKNSjwIlQGgSB5pM3NinsavvuQVT3sDcGJQQJ99BBACR0EKYVCKRiAAABAZAC3EoI" -e LABEL=dev netwebapiappconfig
```

🚩 What the hell?

```shell
The SSL connection could not be established, see inner exception.
The remote certificate is invalid because of errors in the certificate chain: UntrustedRoot
```

Let's include **Netskope** certificates

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:9.0

WORKDIR /application

COPY . .

RUN dotnet restore
RUN dotnet publish -c Release -o output

WORKDIR /application/output

EXPOSE 80

# 🚩 NETSKOPE CERTIFICATES ...

COPY ./certificates/nscacert.crt /usr/local/share/ca-certificates/nscacert.crt
RUN chmod 644 /usr/local/share/ca-certificates/nscacert.crt

COPY ./certificates/intcacert.cer /usr/local/share/ca-certificates/intcacert.cer
RUN chmod 644 /usr/local/share/ca-certificates/intcacert.cer

COPY ./certificates/rootcacert.cer /usr/local/share/ca-certificates/rootcacert.cer
RUN chmod 644 /usr/local/share/ca-certificates/rootcacert.cer

COPY ./certificates/nscacert.pem /usr/local/share/ca-certificates/nscacert.pem
RUN chmod 644 /usr/local/share/ca-certificates/nscacert.pem

RUN update-ca-certificates

# 🚩 ... NETSKOPE CERTIFICATES

ENTRYPOINT ["dotnet", "ThisIsFine.dll"]
```

### Build Docker image (again)

```shell
docker build -t netwebapiappconfig .
```