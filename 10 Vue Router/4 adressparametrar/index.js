const app = Vue.createApp({});

const pageX = {
  template: `
        <h1>Page {{this.$route.params.pageX}}</h1>`,
};
const pageString = {
  template: `
        <h1>{{this.$route.params.string1}}{{this.$route.params.string2}} </h1>`,
};

const routes = [
  { component: pageX, path: "/pages/:pageX" },
  { component: pageString, path: "/:string1/:string2" },
];

const router = VueRouter.createRouter({
  history: VueRouter.createWebHashHistory(),
  routes,
});

app.use(router);

app.mount("#app");
