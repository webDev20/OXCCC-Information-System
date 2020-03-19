<template>
    <v-container class="text-center">
        <v-container id="vProvider">
            <h4>Daily Bible Verse</h4>
            <p id="verseProvider">Powered by ourmanna.com</p>
        </v-container>
        <v-container id="ourmanna-verse">Loading...</v-container>
    </v-container>
</template>

<script>
export default {
    mounted() {
        let VerseScript = document.createElement('script')
        VerseScript.setAttribute('src', 'https://www.ourmanna.com/verses/api/js/')
        document.head.appendChild(VerseScript)
    }
}
</script>

<style lang="scss">
    #verseProvider, h4 {
        text-align: center;
        margin: 0;
        color: darkslategray;
    }

    #mannaverse {
        font-size: 18px;
    }

    #mannaverse-reference {
        margin-top: 15px;
    } 

    #mannaverse-version i {
        display: none;
    }

    #mannaverse-version:after {
        content: ' NIV';
    }
</style>
