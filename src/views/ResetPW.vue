<template>
    <div class="ResetPW">
        <h1 class="text-center display-2 font-weight-bold ma-12 mb-12">
            OXCCC Information System
        </h1>
        <h2 class="text-center font-weight-bold ma-12 mb-12">
        Reset Password
        </h2>
        <v-layout align-center justify-center>
            <TransPanel dynamicID="resetPW_Form" class="ma-0">
                <v-form> 
                    <v-text-field v-model="Email" label="E-mail" required dark></v-text-field>
                    <v-text-field v-model="newPW" label="Enter new password" required dark></v-text-field>
                    <v-text-field v-model="confirmNPW" label="Confirm new password" required dark></v-text-field>
                    <v-container class="pa-0 pt-3" fluid>
                    <v-btn class="btn" to="_blank" outlined dark>Reset password</v-btn>
                    <v-btn class="btn" to="/" outlined dark>Login</v-btn>
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
    
    #resetPW_Form {
        width: 35%;
    }

    h1, h2 {
        color: white;
        text-shadow: 3px 3px 3px black;
    }
</style>