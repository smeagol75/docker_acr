#09

Console application in **Python**

## Dockerfile

```dockerfile
FROM python:3.9-slim

WORKDIR /application

COPY main.py /application

CMD ["python", "main.py"]
```

## Build image

```shell
docker build -t pythonconsole .
```

## Run image

```shell
docker run pythonconsole
```