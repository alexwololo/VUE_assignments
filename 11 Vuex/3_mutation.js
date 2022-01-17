const app = Vue.createApp({});

const state = {
  someValue: "string",
  n: 1,
  b: true,
};

const mutations = {
  changeNumber(state) {
    state.n += 1;
  },
};

const store = Vuex.createStore({ mutations, state });

app.use(store);

app.component("some-component", {
  computed: {
    someValue() {
      return this.$store.state.someValue;
    },
  },
  template: "<div>{{ $store.state.n}}</div>",
});

app.component("some-component", {
  template: `<input @click="$store.commit('changeNumber')" type="button">
  {{$store.state.n}}`,
});

app.mount("#app");
