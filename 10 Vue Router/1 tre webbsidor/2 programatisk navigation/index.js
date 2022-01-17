const app = Vue.createApp({});

const Page2 = { template: "<h1>Page 2</h1>" };
const Page1 = { template: "<h1>Page 1</h1>" };
const Home = { template: "<h1>Home</h1>" };

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
