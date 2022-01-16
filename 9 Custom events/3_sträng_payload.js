// const app = Vue.createApp({});

app.component("controls", {
  data() {
    return {
      s: "",
    };
  },
  methods: {
    onClick() {
      this.$emit("start-game", this.s);
    },
  },

  emits: ["startGame"],
  template: `<input @click="onClick" type="button"> <input type:text v-model=" "`,
});

// app.mount("#app");
