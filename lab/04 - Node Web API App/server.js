var express = require('express');

var application = express();

var port = process.env.PORT || 80;

application.listen(port, function () {
  console.log(`Running on port ${port}`);
});

application.use(function (request, response) {
  response.type('text/plain');
  let message = `🔥 This is fine`;
  console.log(message);
  response.send(message);
});
