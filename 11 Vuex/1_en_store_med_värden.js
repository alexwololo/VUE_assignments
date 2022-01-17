const app = Vue.createApp({});

const state = {
  boolean: true,
  number: 10,
  string: "Alice",
};

const store = Vuex.createStore({ state });

app.use(store);

app.mount("#app");
