import Vue from 'vue'
import VueRouter from 'vue-router'
import Login from '../views/Login.vue'
import firebase from "firebase";

Vue.use(VueRouter)

const routes = [
  {
    path: '/Login',
    name: 'Login',
    component: Login
  },
  {
    path: '/Register',
    name: 'Register',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/Register.vue')
  },
  {
    path: '/ResetPW',
    name: 'ResetPW',
    component: () => import('../views/ResetPW.vue')
  },
  {
    path: '/Dashboard',
    name: 'Dashboard',
    component: () => import('../views/Dashboard.vue'),
    meta: {
      requiresAuth: true,
    },
  },
  {
    path: '/Rota',
    name: 'Rota',
    component: () => import('../views/Rota.vue'),
    meta: {
      requiresAuth: true
    }
  },
  {
    path: '/songSuggestion',
    name: 'songSuggestion',
    component: () => import('../views/songSuggestion.vue'),
    meta: {
      requiresAuth: true
    }
  },
  {
    path: '/songDB',
    name: 'songDB',
    component: () => import('../views/songDB.vue'),
    meta: {
      requiresAuth: true
    }
  },
  {
    path: '/userProfile',
    name: 'userProfile',
    component: () => import('../views/userProfile.vue'),
    meta: {
      requiresAuth: true
    }
  },
  
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

router.beforeEach((to, from, next) => {
  if (to.matched.some(route => route.meta.requiresAuth)) {
    firebase.auth().onAuthStateChanged(function(user) {
      if (user) {
        next();
      } else {
        next('/Login');
      }
    });
  }
  next();
});


export default router
