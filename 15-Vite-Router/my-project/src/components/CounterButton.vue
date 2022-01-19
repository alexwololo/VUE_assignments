<script>
  export default {
    props: {
      msg: String
    }
  }
</script>

<style>
  p {
    color: blue;
  }
</style>

<template>
  <p>'Hello' + {{msg}}</p>
</template>
