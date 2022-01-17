//math random på 2 ställen, i data o methods
const app = Vue.createApp({});
app
  .component("dice", {
    created() {
      this.onClick();
    },
    methods: {
      onClick() {
        this.randomNmbr = Math.floor(
          Math.random(this.randomNmbr) * (7 - 1) + 1
        );
      },
    },

    data() {
      return { randomNmbr: this.randomNmbr };
    },
    template: `<input :value="randomNmbr" type="button"  @click="onClick">`,
  })
  .mount("#app");
