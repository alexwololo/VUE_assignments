const app = Vue.createApp({});

const Page1 = { template: "<h1>Page {{ $route.params.number }}</h1>" };

const others = {
  template: "<h1>{{ $route.params.test }} {{ $route.params.testat }} </h1>",
};

const routes = [
  { component: others, path: "/:test/:testat" },
  {
    component: Page1,
    path: "/pages/:number",
  },
];

const router = VueRouter.createRouter({
  history: VueRouter.createWebHashHistory(),
  routes: routes,
});

app.use(router);
app.mount("#app");
