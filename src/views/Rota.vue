<template>
    <div class="Rota">
        <ProfileNavBar />
        <CalendarRota />
    </div>
</template>

<script>
import ProfileNavBar from '@/components/ProfileNavBar.vue'
import CalendarRota from '@/components/CalendarRota.vue'
  export default {
      components: {
          ProfileNavBar,
          CalendarRota
      }
  }
</script>