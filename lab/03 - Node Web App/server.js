const express = require("express");
const path = require("path");

const application = express();

var port = process.env.PORT || 80;

application.use(express.static(path.join(__dirname, "public")));

application.use(function (request, response) {
    console.log(request.baseUrl);
    response.sendFile(path.join(__dirname, "public", "index.html"));
  });

application.listen(port, function () {
    console.log(`Running on port ${port}`);
});
  