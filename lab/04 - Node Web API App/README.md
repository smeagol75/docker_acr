# 04 

An API written in **Node**

## Dockerfile

```dockerfile
FROM node:23-slim

EXPOSE 80

WORKDIR /application

COPY . .

RUN npm install

ENTRYPOINT [ "node", "server.js" ]
```

## Build image

```shell
docker build -t nodewebapi .
```


# Run image

```shell
docker run -p 8080:80 nodewebapi
```