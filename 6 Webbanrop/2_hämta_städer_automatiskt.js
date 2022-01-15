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
