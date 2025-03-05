# 12 

Web app written in **Angular**

## How to addapt Angular scaffolding

Add ` --host 0.0.0.0 --port 80` to `start` command inside `package.json` file

> I choose port 80 just out of preference. I could continue using Angular's default port, 4200, and set that in the Dockerfile instead

```json
{
  "name": "this-is-fine",
  "version": "0.0.0",
  "scripts": {
    "ng": "ng",
    "start": "ng serve --host 0.0.0.0 --port 80",
    "build": "ng build",
    "watch": "ng build --watch --configuration development",
    "test": "ng test"
  }
  // ...  
}
```

## Dockerfile

```dockerfile
FROM node:18.19-alpine

WORKDIR /app

COPY package.json .

RUN npm install

COPY . .

EXPOSE 80 # or 4200 ...

CMD npm run start
```

## Build image

```shell
docker build -t angular .
```

## Run image

```shell
docker run -d -p 8080:80 angular
```