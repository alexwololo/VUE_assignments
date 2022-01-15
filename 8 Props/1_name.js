const app = Vue.createApp({});

app.component("greet", {
  props: ["name"],
  template: "<div>Välkommen, {{ name }}!</div>",
});

app.mount("#app");
