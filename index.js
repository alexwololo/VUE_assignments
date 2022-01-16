Vue.createApp({
  created() {
    fetch("https://avancera.app/cities/", {
      body: '{ "name": "Teststad", "population":123}',
      headers: {
        "Content-Type": "application/json",
      },
      method: "POST",
    });
  },
  data() {
    return { cities: null };
  },
}).mount("#app");
