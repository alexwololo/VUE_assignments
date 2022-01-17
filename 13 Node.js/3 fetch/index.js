const fetch = require("node-fetch");

fetch("https://avancera.app/cities/")
  .then((response) => response.json())
  .then((result) => {
    console.log(result.length);
  });

//cities.length
