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
      <v-menu open-on-hover offset-x>
        <template v-slot:activator="{ on }">
          <v-icon v-on="on">expand_more</v-icon>
          <v-icon>person</v-icon>
          <v-toolbar-title v-on="on">User name{{Username}}</v-toolbar-title>
        </template>
        <v-list flat>
          <v-list-item-group color="indigo">
            <v-list-item>
              <v-list-item-title class="pDown">Profile</v-list-item-title>
            </v-list-item>
            <v-list-item to="/">
              <v-list-item-title class="pDown">Logout</v-list-item-title>
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
            <v-tab>Song suggestion</v-tab>
            <v-tab>Song database</v-tab>
        </v-tabs>
      </template>
    </v-app-bar>
    </div>
</template>

<style lang="scss">
  .pDown:hover{
    color: darkblue
  }
</style>