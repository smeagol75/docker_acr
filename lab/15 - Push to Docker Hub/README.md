# 15

## Build image

```shell
docker build -t thisisfine .
```

## Run image (for testing purpose only)

```shell
docker run -p 8080:80 thisisfine
```

## Login to Docker Hub

You can login by using username & password ...

```shell
docker login
```

... or by using personal access token that you can get from 
[https://app.docker.com/settings/personal-access-tokens](https://app.docker.com/settings/personal-access-tokens)


```shell
echo q3kEhNJt423fasRRxHlnwsfE7t23K | docker login -u sergiobarriel --password-stdin
```

## Tag your image

```shell
docker tag thisisfine sergiobarriel/thisisfine
```

Then type ``docker images` to compare the image id

```shell
REPOSITORY                                  TAG       IMAGE ID       CREATED         SIZE
thisisfine                                  latest    9939f4fd088a   8 minutes ago   91.9MB
sergiobarriel/thisisfine                    latest    9939f4fd088a   8 minutes ago   91.9MB
```

Wow, they're the same!

## Push to Docker Hub

```shell
docker push sergiobarriel/thisisfine
```

## 🔥 Use your new one image 
Then, you can navigate to your Docker Hub repositories to explore the images. You can also pull the image from Docker by running the following command:

```shell
docker pull sergiobarriel/thisisfine
docker run -p 8080:80 sergiobarriel/thisisfine
```