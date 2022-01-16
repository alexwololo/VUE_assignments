// const app = Vue.createApp({});

app.component("controls", {
  methods: {
    onClick() {
      this.$emit("start-game", 100);
    },
  },
  template: '<input @click="onClick" type="button">',
});

// app.mount("#app");
