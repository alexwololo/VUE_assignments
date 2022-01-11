Vue.createApp({
  data() {
    return { value: 1 };
  },
  methods: {
    increase() {
      this.value() = this.value + 1;
    },
  },
}).mount("#app");
