# 05

A console application written in C#.

# Dockerfile

```shell
FROM mcr.microsoft.com/dotnet/sdk:9.0

WORKDIR /application

COPY . .

RUN dotnet restore

RUN dotnet publish -c Release -o publish

WORKDIR /application/publish

ENTRYPOINT ["dotnet", "ThisIsFine.dll"]
```

## Build image

```shell
docker build -t netconsole .
```

## Run image

```shell
docker run netconsole
```