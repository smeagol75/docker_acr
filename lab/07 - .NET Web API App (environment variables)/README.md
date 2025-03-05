# 07

A **Web API** using the minimal API format in .NET, receiving **environment variables**

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
docker build -t netwebapienv .
```

## Run image

```shell
docker run -p 8080:80 netwebapienv -e NAME=Sergio
```

🚩 What the hell?

> Pay attention to the order of the parameters

```shell
docker run -p 8080:80 -e NAME=Sergio netwebapienv
```