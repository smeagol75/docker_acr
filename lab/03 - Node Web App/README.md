# 03

A **Node** application to serve static HTML

## Dockerfile

```dockerfile
FROM node:23-slim

WORKDIR /application

COPY . .

RUN npm install

EXPOSE 80

ENTRYPOINT [ "node", "server.js" ]
```

## Build image

```shell
docker build -t nodewebapp .
```

## Run image

```shell
docker run -d -p 8080:80 nodewebapp
```

## Inspect logs

```shell
docker logs {containerId}
```

## Inspect files

```shell
docker exec -it {containerId} /bin/sh
```