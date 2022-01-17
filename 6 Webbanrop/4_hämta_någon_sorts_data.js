Vue.createApp({
  created() {
    fetch(
      "https://space-engineers.com/api/?object=servers&element=detail&key=nrYXkv5jZLjwhTDXPwAh2vXl3QrrCATxyD"
    )
      .then((response) => response.json())
      .then((result) => {
        this.test = result;
        console.log(result);
      });
  },
  data() {
    return { test: null };
  },
}).mount("#app");
