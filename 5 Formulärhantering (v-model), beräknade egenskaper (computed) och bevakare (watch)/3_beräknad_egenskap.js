Vue.createApp({
  computed: {
    n() {
      return this.s.length;
    },
  },
  data() {
    return {
      s: "",
    };
  },
}).mount("#app");
