Vue.createApp({
  created() {
     this.fetchCities()


  },
  methods: {
      fetchCities: function (){
          fetch('https://avancera.app/cities/')
              .then((response) => response.json())
              .then((result) => {
                  this.cities = result
              })
      },


      addCity: function (){
          fetch('https://avancera.app/cities/', {
              body: JSON.stringify({
                  name: this.name,
                  population: this.population
              }),
              headers: {'Content-Type': 'application/json'},
              method: 'POST'
          })
              .then(this.fetchCities)

      }
  },
  data() {
      return { cities: null }
  }
}).mount('#app')
