Vue.createApp({
  data() {
    return { value: 1 };
  },
  methods: {
    increase(one) {
      this.value = this.value + one;
      var one = 1;
    },
  },
}).mount("#app");
