<template>
    <v-dialog v-model="show" hide-overlay scrollable transition="dialog-transition">
        <v-card>
            <v-img :src="thumb" @click.stop="showDialog=true" style="cursor:pointer;"></v-img>
            <v-card-title primary-title>
                <h4 class="headline">{{ title}}</h4>
                <div>{{description}}</div>
            </v-card-title>
            <v-container>
                <v-card flat>
                    Location: Barcelona, Spain
                </v-card>
                <v-card flat>
                    Year: 1897
                </v-card>
                <v-divider></v-divider>
                <v-card flat>
                    Vertices: 1,654,081
                </v-card>
                <v-card flat>
                    Faces: 99,701
                </v-card>
                <v-card flat>
                    Disjoint Meshes: 266
                </v-card>
                <v-card flat>
                    Model Size: 266mb
                </v-card>
            </v-container>
            <v-divider></v-divider>
            <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn flat>Add to model</v-btn>
                <v-btn icon>
                    <v-icon>favorite</v-icon>
                </v-btn>
                <v-btn icon>
                    <v-icon>bookmark</v-icon>
                </v-btn>
                <v-btn icon>
                    <v-icon>share</v-icon>
                </v-btn>
                <v-btn icon @click.stop="show=false">
                    <v-icon>close</v-icon>
                </v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

<script>
export default {
  name: 'ElementDetails',
  props: {
    visible: Boolean,
    thumb: String,
    title: String,
    description: String,
    vertices: Number,
    faces: Number,
    assetType: String
  },
  data: () => ({
    dialog: false,
    bottomNav: 'recent'
  }),
  computed: {
    show: {
      get () {
        return this.visible
      },
      set (value) {
        if (!value) {
          this.$emit('close')
        }
      }
    }
  }
}
</script>

<style>

</style>
