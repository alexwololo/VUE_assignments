const app = Vue.createApp({});

const state = {
  s: "string",
  n: 1,
  b: true,
};

const mutations = {
  changeNumber(state, amount) {
    state.n += parseInt(amount);
  },
};

const store = Vuex.createStore({ mutations, state });

app.use(store);

app.component("some-component", {
  computed: {
    n() {
      return this.$store.state.n;
    },
  },
  template: `
    <div>{{ n }}</div>
    <input type="button" @click="$store.commit('changeNumber', amount)" value="Add">
    <input type="text" v-model="amount">
    `,
});

app.mount("#app");
