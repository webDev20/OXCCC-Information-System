<template>
  <v-app style="background: rgba(0, 0, 0, 0);">
    <v-content>
      <v-container fluid class="pa-0">
        <router-view/>
      </v-container>
    </v-content>
  </v-app>
</template>

<script>

export default {
  name: 'App'
}
</script>