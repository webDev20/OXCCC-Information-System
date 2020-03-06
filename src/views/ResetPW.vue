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
                <v-form> 
                    <v-text-field v-model="Email" label="E-mail" required dark></v-text-field>
                    <v-btn class="my-3" to="_blank" block dark>Reset password</v-btn>
                    <v-btn to="/" block dark>Return to login page</v-btn>
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
    },
    data() {
        return {
            showNPW: false,
            showCNPW: false
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
    }

    h1, h2 {
        color: white;
        text-shadow: 3px 3px 3px black;
    }
</style>