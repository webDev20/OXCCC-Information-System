<template>
    <div class="appNavPBar">
      <v-app-bar
      app
      color="indigo"
      dense
      dark
      >
      <v-toolbar-title>OXCCC Information System</v-toolbar-title>
      <v-spacer></v-spacer>
      <v-menu open-on-hover open-on-click offset-x>
        <template v-slot:activator="{ on }">
          <v-icon v-on="on">expand_more</v-icon>
          <v-icon>person</v-icon>
          <v-toolbar-title v-on="on">{{user.data.displayName}}</v-toolbar-title>
        </template>
        <v-list flat>
          <v-list-item-group color="indigo">
            <v-list-item to="/userProfile">
              <v-list-item-title class="pDown">Profile</v-list-item-title>
            </v-list-item>
            <v-list-item>
              <v-list-item-title @click.prevent="signOut" class="pDown">Logout</v-list-item-title>
            </v-list-item>
          </v-list-item-group>
        </v-list>
      </v-menu>
      <template v-slot:extension>
        <v-tabs
            fixed-tabs
            background-color="indigo"
            dark
            centered
            dense
            slider-color="red"
        >
            <v-tab to="/Dashboard">Dashboard</v-tab>
            <v-tab to="/Rota">Rota</v-tab>
            <v-tab to="/songSuggestion">Song suggestion</v-tab>
            <v-tab to="/songDB">Song database</v-tab>
        </v-tabs>
      </template>
    </v-app-bar>
    </div>
</template>

<script>
import firebase from "firebase";
import { mapGetters } from "vuex";

export default {
  computed: {
    ...mapGetters({
// map `this.user` to `this.$store.getters.user`
      user: "user"
    })
  },
  methods: {
    signOut() {
      firebase.auth()
      .signOut()
      .then(() => {
        this.$router.replace('Login');
        console.log("Successfully logged out");
      })
    }
  }
}
</script>

<style lang="scss">
  .pDown:hover{
    color: darkblue
  }
</style>