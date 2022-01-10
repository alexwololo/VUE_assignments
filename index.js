Vue.createApp({
  data() {
    return {
      players: [
        { name: 'Alice', credits: 150 },
        { name: 'Bob', credits: 100 },
        { name: 'Cesar', credits: 50 }
      ]
    }
  }
}).mount('#app')
