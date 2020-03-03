<template>
    <v-container :id="dynamicID" class="TransPanel">
        <slot />
    </v-container>
</template>

<script>
export default {
name: 'TransPanel',
props: {
    dynamicID: String
}
}
</script>

<style lang="scss">
    .TransPanel {
        box-shadow: 0 0 10px 6px rgba(0, 0, 0, 0.4);
        background: rgba(0, 0, 0, 0.35);
        border-radius: 5px;
        overflow: hidden;
    }
</style>