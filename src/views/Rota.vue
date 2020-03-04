<template>
    <div class="Rota">
        <appNavPBar />
        <CalendarRota />
    </div>
</template>

<script>
import appNavPBar from '@/components/appNavPBar.vue'
import CalendarRota from '@/components/CalendarRota.vue'
  export default {
      components: {
          appNavPBar,
          CalendarRota
      }
  }
</script>