<script>
// import CounterButton from "./CounterButton.vue";
//   export default {
//     props: {
//         msg: String
//     },
//     components: { CounterButton }
// }

import CounterButton from '../components/CounterButton.vue'
export default {
  components: {
    CounterButton
  }
}
</script>

<style>
  p {
    font-weight: bold;
  }
</style>

<template>
  <img alt="" src="/assets/fox.jpeg" />
  <p>{{ msg }}</p>
  <p>{{1+2}}</p>
  <p>{{$store.state}}</p>
<!--
    <input
    type="button"
    :value="$store.state.counter"
    @click="$store.commit('increment')"
  /> -->
  <CounterButton/>
</template>
