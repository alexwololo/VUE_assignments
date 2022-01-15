const app = Vue.createApp({});

app.component("greet", {
  props: ["playerName"],
  template: "<div>Välkommen, {{ playerName }}!</div>",
});

app.mount("#app");
