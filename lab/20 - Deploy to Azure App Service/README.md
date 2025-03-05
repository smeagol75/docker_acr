# 20

## Create Web App

![./images/1.png](./images/1.png)
![./images/2.png](./images/2.png)
![./images/3.png](./images/3.png)

![./images/4.png](./images/4.png)

Wait for a minutes...

![./images/5.png](./images/5.png)

## Configure Web App

Don't forget to add `WEBSISTES_PORT` to your Web App's environment variables and set it to the value specified in your `Dockerfile`

```dockerfile
FROM nginx:alpine

COPY index.html /usr/share/nginx/html/index.html
COPY video.mp4 /usr/share/nginx/html/video.mp4

EXPOSE 80 # <--- this value
```

![./images/6.png](./images/6.png)

## Enjoy

![./images/7.png](./images/7.png)
