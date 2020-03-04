<template>
  <div class="Register">
    <h1 class="text-center display-2 font-weight-bold ma-12 mb-8">
      OXCCC Information System
    </h1>
    <h2 class="text-center font-weight-bold ma-8 mb-8">
      Register Account
    </h2>
    <v-layout align-center justify-center>
      <TransPanel dynamicID="regForm" class="ma-0">
        <v-form> 
          <v-text-field v-model="FirstName" label="First name" required dark></v-text-field>
          <v-text-field v-model="LastName" label="Last name" required dark></v-text-field>
          <v-text-field v-model="Email" label="Email" required dark></v-text-field>
          <v-text-field v-model="Password" label="Password" required dark></v-text-field>
          <v-text-field v-model="confirmPW" label="Confirm Password" required dark></v-text-field>
          <v-container class="pa-0 pt-3" fluid>
            <v-btn class="btn" to="/" outlined dark>Login</v-btn>
            <v-btn class="btn" to="/" outlined dark>Register</v-btn>
          </v-container>
        </v-form>
      </TransPanel>
    </v-layout>
  </div>
</template>

<script>
import TransPanel from '@/components/TransPanel.vue'
export default {
  components: {
    TransPanel
  }
}
</script>

<style lang="scss">
    html {
        width: 100%;
        height: 100%;
        background: url("../assets/SystemBackground.png");
        background-size: 100%;
        overflow: hidden;
    }

    #regForm {
        width: 35%;
    }

    h1, h2 {
        color: white;
        text-shadow: 3px 3px 3px black;
    }
</style>