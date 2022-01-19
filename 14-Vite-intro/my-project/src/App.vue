<script>
  import CitiesList from './components/CitiesList.vue'
  import HelloWorld from './components/HelloWorld.vue'
  import CounterButton from './components/CounterButton.vue'

  export default {
    components: {
      CitiesList,
      HelloWorld,
      CounterButton
    }
  }
</script>

<template>
  <HelloWorld msg="Hello World!" />
  <CitiesList />
</template>
