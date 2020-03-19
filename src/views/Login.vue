<template>
  <div class="Login">
      <h1 class="text-center display-2 font-weight-bold ma-12 mb-12">
        OXCCC Information System
      </h1>
      <v-container fluid fill-height>
        <v-layout align-center justify-center>
          <v-row class="ma-0 md-6" align-center justify-center>
            <DailyVerse id="dV" class="pa-0 mr-0"/>
          </v-row>
          <v-row class="ma-12 md-12" align-center justify-center>
            <TransPanel dynamicID="loginForm" class="ma-0">
              <v-form v-model="valid">
                <v-text-field v-model="Email" :rules="[rules.required, rules.email]" label="Email" prepend-icon="email" required dark></v-text-field>
                <v-text-field v-model="Password" :rules="[rules.required, rules.min]" label="Password" prepend-icon="lock" :type="showPW ? 'text' : 'Password'" :append-icon="showPW ? 'visibility' : 'visibility_off'" @click:append="showPW = !showPW" required dark></v-text-field>
                <v-btn :disabled="!valid" @click.prevent="userLogin" block color="secondary" dark>Login</v-btn>
                <v-container class="pa-0 pt-3 text-center" fluid>
                  <v-btn class="btn" to="/Register" outlined dark>Register</v-btn>
                  <v-btn class="btn" to="/ResetPW" outlined dark>Reset Password</v-btn>
                </v-container>
              </v-form>
            </TransPanel>
          </v-row>
        </v-layout>
      </v-container>
  </div>
</template>

<script>
// @ is an alias to /src
import DailyVerse from '@/components/DailyVerse.vue'
import TransPanel from '@/components/TransPanel.vue'
import firebase from "firebase";

export default {
  components: {
    DailyVerse,
    TransPanel
  },
  data: function() {
    return {
      Email: "",
      Password: "",
      showPW: false,
      error: null,
      valid: false,
      rules: {
        required: value => !!value || 'Required.',
        min: value => value.length >= 6 || 'Password is at least 6 characters',
        email: value => {
          const pattern = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
          return pattern.test(value) || 'Not a valid e-mail.'
        },
      },
    }
  },
  methods: {
    userLogin() {
      firebase.auth()
      .signInWithEmailAndPassword(this.Email, this.Password)
      .then(() => {
        setTimeout(() => this.$router.replace('Dashboard'), 250);
      })
      .catch(err => {
        this.error = err.message;
        console.error(this.error);this
      });
    }
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

  h1 {
    color: white;
    text-shadow: 3px 3px 3px black;
  }

  #dV {
    width: 450px;
  }

  #loginForm {
    width: 350px;
    background: rgba(0, 0, 0, 0.65);
  }

  .btn {
    width: 50%;
    color: white;
  }
</style>
