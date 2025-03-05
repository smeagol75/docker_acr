# 10

Web API built with **Flask** for **Python**

## Dockerfile

```dockerfile
FROM python:3.9-slim

WORKDIR /application

COPY . /application

RUN pip install --trusted-host pypi.org --trusted-host files.pythonhosted.org flask

EXPOSE 80

CMD ["python", "main.py"]

```

## Build image

```shell
docker build -t pythonapi .
```

## Run image

```shell
docker run -d -p 8080:80 pythonapi
```