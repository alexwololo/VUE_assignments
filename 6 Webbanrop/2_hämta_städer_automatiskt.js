Vue.createApp({
  created() {
    fetch("https://avancera.app/cities/")
      .then((response) => response.json())
      .then((result) => {
        this.cities = result;
      });
  },
  data() {
    return { cities: null };
  },
}).mount("#app");

fetch("https://avancera.app/cities/")
  .then((response) => response.json())
  .then((result) => {
    console.log(result);
  });

fetch("https://api-thirukkural.vercel.app/api?num=x")
  .then((response) => response.json())
  .then((result) => {
    console.log(result);
  });
