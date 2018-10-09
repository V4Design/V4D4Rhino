<template>
  <v-app>
    <v-tabs
      v-model="active"
      color="white"
      light
      slider-color="black"
      grow
    >
      <v-tab
        v-for="item in items" :key="item"
        ripple
      >
        {{ item }}
      </v-tab>
    </v-tabs>
    <v-content>
      <v-tabs-items v-model="active">
        <v-tab-item key='query'>
          <v-card flat>
            <QueryForm></QueryForm>
          </v-card>
        </v-tab-item>
        <v-tab-item key='library'>
          <v-card flat>
            <QueryResults/>
          </v-card>
        </v-tab-item>
      </v-tabs-items>
    </v-content>
  </v-app>
</template>

<script>
import QueryForm from './components/QueryForm.vue'
import QueryResults from './components/QueryResults.vue'
export default {
  name: 'App',
  components: {
    QueryForm,
    QueryResults
  },
  data () {
    return {
      active: null,
      items: [
        'Query', 'Library'
      ]
    }
  }
}
</script>
