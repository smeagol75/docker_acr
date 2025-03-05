# 02

Serve static HTML in an **Nginx** or **Apache** image

## Dockerfile

### Nginx

Copy files one by one... 

```dockerfile
FROM nginx:alpine

COPY index.html /usr/share/nginx/html/index.html
COPY fine.png /usr/share/nginx/html/fine.png

EXPOSE 80
```

... or copy files all at once.

```dockerfile
FROM nginx:alpine

COPY . /usr/share/nginx/html/

EXPOSE 80
```

### Apache

```dockerfile
FROM httpd:alpine

COPY . /usr/local/apache2/htdocs/

EXPOSE 80
```

### Build image

```shell
docker build -t fine .
```

### Run image

```shell
docker run -d -p 8080:80 fine
```
