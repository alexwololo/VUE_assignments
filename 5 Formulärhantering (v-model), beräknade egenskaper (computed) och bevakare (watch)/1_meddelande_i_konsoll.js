Vue.createApp({
  data() {
    return { userName: this.userName };
  },
  methods: {
    onClick() {
      console.log(this.userName);
    },
  },
}).mount("#app");
