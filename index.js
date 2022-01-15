// const app = Vue.createApp({});

app.component("controls", {
  data() {},
  methods: {
    onClick() {
      this.$emit("start-game");
    },
  },
  template: '<input :value="controlzzzs" @click="onClick" type="button">',
});

// app.mount("#app");
