<template>
    <v-card>
        <ElementDetails :title="title" thumb="placeholder.png" :description="description" :visible="showDialog" @close="showDialog=false"/>
        <v-img :src="thumb" @click.stop="showDialog=true" style="cursor:pointer;"></v-img>
        <v-card-title primary-title>
          <div>
            <h4 >{{ title}}</h4>
          </div>
        </v-card-title>
        <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn icon>
                <v-icon>favorite</v-icon>
            </v-btn>
            <v-btn icon>
                <v-icon>bookmark</v-icon>
            </v-btn>
            <v-btn icon>
                <v-icon>share</v-icon>
            </v-btn>
        </v-card-actions>
    </v-card>
</template>

<script>
import ElementDetails from './ElementDetails.vue'
export default {
  name: 'ResultElement',
  components: {
    ElementDetails
  },
  props: {
    title: String,
    description: String,
    thumb: String,
    flex: Number
  },
  data: () => ({
    show: false,
    showDialog: false
  }),
  methods: {
    clickedImg () {}
  }
}
</script>

<style>

</style>
