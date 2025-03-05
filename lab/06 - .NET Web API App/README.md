# 06

A **Web API** using the minimal API format in .NET

## Dockerfile


```shell
FROM mcr.microsoft.com/dotnet/sdk:9.0

WORKDIR /application

COPY . .

RUN dotnet restore
RUN dotnet publish -c Release -o output

WORKDIR /application/output

EXPOSE 80

ENTRYPOINT ["dotnet", "ThisIsFine.dll"]
```

## Build image

```shell
docker build -t netwebapi .
```

## Run image

```shell
docker run -p 8080:80 netwebapi
```