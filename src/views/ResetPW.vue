<template>
    <div class="ResetPW">
        <h1 class="text-center display-2 font-weight-bold ma-12 mb-12">
            OXCCC Information System
        </h1>
        <h2 class="text-center font-weight-bold ma-12 mb-12">
        Enter E-mail for password reset E-mail
        </h2>
        <v-layout align-center justify-center>
            <TransPanel dynamicID="resetPW_Form" class="ma-0">
                <v-form v-model="valid"> 
                    <v-text-field v-model="Email" :rules="[rules.required, rules.email]" label="E-mail" required dark></v-text-field>
                    <v-btn class="my-3" :disabled="!valid" @click.prevent="sendResetPWEmail" block dark>Reset password</v-btn>
                    <v-btn to="/Login" block dark>Return to login page</v-btn>
                </v-form>
            </TransPanel>
        </v-layout>
    </div>
</template>

<script>
import TransPanel from '@/components/TransPanel.vue'
import firebase from "firebase";

export default {
    components: {
        TransPanel
    },
    data: function() {
        return {
            Email: "",
            showNPW: false,
            showCNPW: false,
            error: null,
            valid: false,
            rules: {
            required: value => !!value || 'Required.',
            email: value => {
            const pattern = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
            return pattern.test(value) || 'Not a valid e-mail.'
            },
        },
        }
    },
    methods: {
        sendResetPWEmail() {
            firebase.auth()
            .sendPasswordResetEmail(this.Email)
            .then(() => {
                console.info("Email is sent");
            })
            .catch(err => {
                this.error = err.message
                console.error(this.error);
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
    
    #resetPW_Form {
        width: 35%;
        background: rgba(0, 0, 0, 0.65);
    }

    h1, h2 {
        color: white;
        text-shadow: 3px 3px 3px black;
    }
</style>