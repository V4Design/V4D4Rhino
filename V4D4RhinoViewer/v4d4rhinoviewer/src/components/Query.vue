<template>
  <v-container>
      <v-form>
          <v-text-field
            v-model="textQuery"
            label="Input Query Text"
            clearable
          ></v-text-field>
          <v-combobox
            v-model="tags"
            label="Tags"
            :items="items"
            multiple
            small-chips
            deletable-chips
            :search-input.sync="search"
            @pasted="pasted"
            @change="printItems"
          >
            <template slot="no-data">
                <v-list-tile>
                    <v-list-tile-content>
                    <v-list-tile-title>
                        No results matching "<strong>{{ search }}</strong>". Press <kbd>enter</kbd> to create a new one
                    </v-list-tile-title>
                    </v-list-tile-content>
                </v-list-tile>
                </template>
          </v-combobox>
          <v-btn
            :loading="loading"
            :disabled="loading"
            color="secondary"
            @click.native="loader = 'loading'"
            >
            Submit
          </v-btn>
      </v-form>
  </v-container>
</template>

<script>
export default {
  name: 'Query',
  data: () => ({
    textQuery: '',
    tags: [],
    items: [],
    search: null,
    loader: null,
    loading: false
  }),
  methods: {
    pasted () {
      this.$nextTick(() => {
        this.tags.push(...this.search.split(','))
        this.$nextTick(() => {
          this.search = ''
        })
      })
    },
    printItems () {
      console.log('tags', this.tags)
      console.log('items', this.items)
    }
  },
  watch: {
    loader () {
      const l = this.loader
      this[l] = !this[l]
      setTimeout(() => (this[l] = false), 3000)
      this.loader = null
    }
  }
}
</script>

<style>

</style>
