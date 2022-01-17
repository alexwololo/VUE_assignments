const axios = require("axios").default;

axios.get("https://avancera.app/cities/").then(function (response) {
  console.log(response.data.length);
});
