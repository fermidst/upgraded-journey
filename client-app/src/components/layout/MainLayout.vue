<template>
  <div>
    <v-app-bar app color="primary" dark>
      <div>
        <slot name="icon">
          <v-icon>mdi-arrow-left</v-icon>
        </slot>
      </div>
      <v-spacer></v-spacer>
      <v-tabs>
        <v-tab to="/">Главная</v-tab>
        <v-tab to="/stats">Статистика</v-tab>
      </v-tabs>
    </v-app-bar>

    <v-main>
      <slot name="default" />
    </v-main>
  </div>
</template>

<script>
export default {
  name: "MainLayout"
};
</script>

<style scoped></style>
