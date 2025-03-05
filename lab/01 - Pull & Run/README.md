# 01 jelouuu

Use of the pull and run commands to download and run images from Docker Hub.

## Node API

[emoji-api](https://github.com/sergiobarriel/emoji-api)

`Pull` images

```shell
docker pull sergiobarriel/emoji-api-animals
docker pull sergiobarriel/emoji-api-foods
docker pull sergiobarriel/emoji-api-sports
```

`Run` the first image

```shell
docker run -p 5001:80 sergiobarriel/emoji-api-animals
```

Now `run` the second image

```shell
docker run -p 5001:80 sergiobarriel/emoji-api-foods
```

🚩 What the hell?

```shell
Bind for 0.0.0.0:5001 failed: port is already allocated.
```

`Run` it again, but right
```
docker run -p 5001:80 sergiobarriel/emoji-api-animals
docker run -p 5002:80 sergiobarriel/emoji-api-foods
docker run -p 5003:80 sergiobarriel/emoji-api-sports
```

Test it

```shell
curl localhost:5001
curl localhost:5002
curl localhost:5003
```

## SQL Server

[mssql-server](https://hub.docker.com/r/microsoft/mssql-server)

`Pull` the image

```shell
docker pull mcr.microsoft.com/mssql/server:latest
```

`Run` the image (after reading documentation)

```shell
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=P4ssw0rd!" -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:latest
```

Then connect to SQL Server `localhost,1433`

## Cosmos Db emulator

`Pull` the image

[azure-cosmos-emulator](https://learn.microsoft.com/en-us/azure/cosmos-db/how-to-develop-emulator?tabs=docker-linux%2Ccsharp&pivots=api-nosql)

```shell
docker pull mcr.microsoft.com/cosmosdb/linux/azure-cosmos-emulator:latest
```

`Run` the image (after reading documentation)

```shell
docker run --publish 8081:8081 --publish 10250-10255:10250-10255 --name linux-emulator -d mcr.microsoft.com/cosmosdb/linux/azure-cosmos-emulator:latest
```

Navigate to [https://localhost:8081/_explorer/index.html](https://localhost:8081/_explorer/index.html) to access the data explorer.

## Aspire Dashboard

[aspire-dashboard](https://learn.microsoft.com/en-us/dotnet/aspire/fundamentals/dashboard/standalone?tabs=bash)

`Pull` the image

```
docker pull mcr.microsoft.com/dotnet/aspire-dashboard:9.0
```

`Run` the image (after reading documentation)

```shell
docker run --rm -it -d \
    -p 18888:18888 \
    -p 4317:18889 \
    --name aspire-dashboard \
    mcr.microsoft.com/dotnet/aspire-dashboard:9.0
```