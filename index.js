Vue.createApp({
  data() {
    return { value: 1 };
  },
  methods: {
    increase(one) {
      this.value = this.value + one;

    },
  },
}).mount("#app");
