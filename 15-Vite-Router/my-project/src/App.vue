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

  <main>
    <RouterView />
  </main>

  <nav>
    <ul>
      <li>
        <RouterLink to="/">Hem</RouterLink>
      </li>
      <li>
        <RouterLink to="/about">Om</RouterLink>
      </li>
      <li>
        <RouterLink to="/contact">Kontakt</RouterLink>
      </li>
    </ul>
  </nav>
  <HelloWorld msg="Hello World!" />
  <CitiesList />


</template>
