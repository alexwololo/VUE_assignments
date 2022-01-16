app.component("controls", {
  methods: {
    onClick() {
      this.$emit("start-game");
    },
  },
  template: '<input @click="onClick" type="button">',
});
