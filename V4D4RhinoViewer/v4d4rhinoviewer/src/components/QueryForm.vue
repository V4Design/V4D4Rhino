<template>
    <div>
        <div><Query/></div>
        <div><QueryResults/></div>
    </div>
</template>

<script>
import Query from './Query.vue'
import QueryResults from './QueryResults.vue'
export default {
  name: 'QueryForm',
  components: {
    Query,
    QueryResults
  }
}
</script>

<style>

</style>
