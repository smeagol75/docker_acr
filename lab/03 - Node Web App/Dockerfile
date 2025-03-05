FROM node:23-slim

WORKDIR /application

COPY . .

RUN npm install

EXPOSE 80

ENTRYPOINT [ "node", "server.js" ]