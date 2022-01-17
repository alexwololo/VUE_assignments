app.component("controls", {
  data() {
    return {
      payload: undefined,
    };
  },
  methods: {
    onClick() {
      this.$emit("start-game", this.payload);
    },
  },
  template: `<input type="button" @click="onClick"><input type="text" v-model="payload">`,
  emits: ["startGame"],
});
