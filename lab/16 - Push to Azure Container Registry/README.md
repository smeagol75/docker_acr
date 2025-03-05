# 16

## Build image

```shell
docker build -t thisisfine .
```

## Run image (for testing purpose only)

```shell
docker run -p 8080:80 thisisfine
```

## Login to Azure Container Registry

```shell
az login --tenant d6397071-8e3e-45d2-a2d6-36698acf0fea
az acr login --name dockerlabhcv
```

```shell
Login Succeeded
```

## Tag your image

```shell
docker tag thisisfine thedockerlab.azurecr.io/thisisfine
```

Then type ``docker images` to compare the image id

```shell
REPOSITORY                                  TAG       IMAGE ID       CREATED              SIZE
thisisfine                                  latest    1255bbf7f2fd   About a minute ago   91.9MB
thedockerlab.azurecr.io/thisisfine          latest    1255bbf7f2fd   About a minute ago   91.9MB
```

Wow, they're the same!

## Push to Docker Hub

```shell
docker push thedockerlab.azurecr.io/thisisfine
```

## 🔥 Use your new one image 
Then, you can navigate to your Azure Container Registry repositories to explore the images. You can also pull the image from ACR by running the following command:

```shell
docker pull thedockerlab.azurecr.io/thisisfine
docker run -p 8080:80 thedockerlab.azurecr.io/thisisfine
```