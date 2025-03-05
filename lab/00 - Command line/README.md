# 🐋 Docker 

## Common commands

### 🐧 WSL (Windows Subsystem for Linux)

| command | description |
|--|--|
| wsl | access to WSL2 machine |
| exit | exit from WSL2 machine |

### 📦 Operations over images 

| command | description |
|--|--|
| `docker pull image:version` | download image from hub |
| `docker images` | list pulled images |
| `docker rmi {imageName}` | delete image |
| `docker rmi $(docker images -aq)` | delete all images |
| `docker run image:version` | creates & executes container |
| `docker run --name customName image:version` | creates container with custom name and execute it |
| `docker run -i image:version` | creates & executes container in interactive mode |
| `docker run -d image:version` | creates & executes container in detached mode |
| `docker history {imageName}` | shows image layers |
| `docker save {imageName} -o {fileName}.tar` | exports image |

### 📦 Operations over containers 

| command | description |
|--|--|
| `docker ps` | view running containers |
| `docker ps -a` | view running & stopped containers |
| `docker container list` | view running containers |
| `docker container list -a` | view running & stopped containers |
| `docker start containerId` | executes specific container in background |
| `docker start containerName` | executes specific container in background |
| `docker start -i containerName` | executes specific container in interactive mode |
| `docker stop containerName` | stops a container |
| `docker kill containerName` | force the stop of container |
| `docker container rm containerName` | delete container |
| `docker rm containerName` | delete container |
| `docker rm $(docker ps -aq)` | delete all containers |

### 🏭 Build 

| command | description |
|--|--|
| `docker build -t {name} .` | build docker image |
| `docker tag {name} {newName}:{version}`| assign new name or label to a docker image |

### Dockerfile

[https://docs.docker.com/build/concepts/dockerfile/](https://docs.docker.com/build/concepts/dockerfile/)

| Instruction | Description |
|--|--|
| `FROM <image>` | Defines a base for your image. |
| `RUN <command>` | Executes any commands in a new layer on top of the current image and commits the result. `RUN` also has a shell form for running commands. |
| `WORKDIR <directory>` | Sets the working directory for any `RUN`, `CMD`, `ENTRYPOINT`, `COPY`, and `ADD` instructions that follow it in the Dockerfile. |
| `COPY <src> <dest>` | Copies new files or directories from `<src>` and adds them to the filesystem of the container at the path `<dest>` |
| `CMD <command>` | Lets you define the default program that is run once you start the container based on this image. Each Dockerfile only has one `CMD`, and only the last `CMD` instance is respected when multiple exist. |

#### Python (demo)

```python
from flask import Flask
app = Flask(__name__)

@app.route("/")
def hello():
    return "Hello World!"
```

```dockerfile
# syntax=docker/dockerfile:1
FROM ubuntu:22.04

# install app dependencies
RUN apt-get update && apt-get install -y python3 python3-pip
RUN pip install flask==3.0.*

# install app
COPY hello.py /

# final configuration
ENV FLASK_APP=hello
EXPOSE 8000
CMD ["flask", "run", "--host", "0.0.0.0", "--port", "8000"]
```