const app = Vue.createApp({});

app.component("greet", {
  data() {
    return {};
  },
  methods: {},
  // var tidigare ["playerName"]
  props: {
    playerName: {
      type: String,
      required: true,
    },
  },
  template: "<div>Välkommen, {{ playerName }}!</div>",
});

app.mount("#app");
