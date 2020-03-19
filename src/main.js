import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import 'babel-polyfill'
import * as firebase from "firebase";
import 'firebase/firestore';
import vuetify from './plugins/vuetify';
import 'material-design-icons-iconfont/dist/material-design-icons.css';

Vue.config.productionTip = false

const configOptions = {
  apiKey: "AIzaSyCLFhwmHr72jgPb4F9N1MGkk3J3f0hTkUA",
  authDomain: "oxccc-information-system.firebaseapp.com",
  databaseURL: "https://oxccc-information-system.firebaseio.com",
  projectId: "oxccc-information-system",
  storageBucket: "oxccc-information-system.appspot.com",
  messagingSenderId: "872056776948",
  appId: "1:872056776948:web:91284af102fb95bb6b96a1"
};

firebase.initializeApp(configOptions);

export const db = firebase.firestore();

firebase.auth().onAuthStateChanged(user => {
  store.dispatch("fetchUser", user);
});

//handle page reloads
let app;
firebase.auth().onAuthStateChanged(user => {
  console.info("Vue app: ", user);
  if  (!app) {
    new Vue({
      router,
      store,
      vuetify,
      render: h => h(App)
    }).$mount('#app')
  }
})
