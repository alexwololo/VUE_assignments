const app = Vue.createApp({});

app.component("coin-toss", {
  data() {
    return { oneOrZero: Math.round(Math.random()) };
  },
  methods: {},
  template: `<span v-if="oneOrZero === 0 ">Krona</span>
      <span v-else>Klave</span>`,
});

app.mount("#app");
