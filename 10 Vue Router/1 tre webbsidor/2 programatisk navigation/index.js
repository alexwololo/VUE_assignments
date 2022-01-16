const app = Vue.createApp({});

const Page2 = { template: "<h1>Page 2</h1>" };
const Page1 = { template: "<h1>Page 1</h1>" };
const Home = {
  methods: {
    onClick() {
      this.$router.push("/page-1");
    },
  },
  template:
    '<div><h1>home</h1> <input value="page 1" @click="onClick" type="button"></div>',
};

const routes = [
  { component: Home, path: "/" },
  { component: Page1, path: "/page-1" },
  { component: Page2, path: "/page-2" },
];
const router = VueRouter.createRouter({
  history: VueRouter.createWebHashHistory(),
  routes: routes,
});

app.use(router);
app.mount("#app");
