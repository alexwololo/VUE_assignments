Vue.createApp({
  data() {
    return { oneOrZero: Math.round(Math.random()) }
  }
}).mount('#app')
