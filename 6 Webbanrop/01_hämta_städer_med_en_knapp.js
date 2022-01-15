Vue.createApp({
  data() {
    return { cities: null };
  },
  methods: {
    fetchCities() {
      fetch("https://avancera.app/cities/")
        .then((response) => response.json())
        .then((result) => {
          this.cities = result;
        });
    },
  },
}).mount("#app");
