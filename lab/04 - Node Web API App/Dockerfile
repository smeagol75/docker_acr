FROM node:23-slim

EXPOSE 80

WORKDIR /application

COPY . .

RUN npm install

ENTRYPOINT [ "node", "server.js" ]