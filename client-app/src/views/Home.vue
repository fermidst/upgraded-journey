<template>
  <MainLayout>
    <template v-slot:icon>
      <v-icon>mdi-account-group</v-icon>
    </template>
    <v-container>
      <v-row class="text-center">
        <v-col>
          <h1>Турагенство</h1>
        </v-col>
      </v-row>
      <v-row>
        <v-col>
          <v-parallax
            src="https://quikmaps.com/wp-content/uploads/2020/11/future-of-travel-today-main_32aedb81d10d25bd8ddeb01da051c4bd.social_share_1200x630_center.png"
            height="400"
          />
        </v-col>
      </v-row>
      <v-row class="text-center">
        <v-col>
          <h1>Доступные путевки</h1>
        </v-col>
        <v-col>
          <h1 class="red--text">
            Горящие путевки
          </h1>
        </v-col>
      </v-row>
      <v-row>
        <v-col>
          <Tickets :tickets="tickets" />
        </v-col>
        <v-col>
          <Tickets
            :tickets="
              tickets.filter(
                t =>
                  (new Date(t.startDate).getTime() - new Date().getTime()) /
                    (24 * 60 * 60 * 1000) <
                  7
              )
            "
          />
        </v-col>
      </v-row>
    </v-container>
  </MainLayout>
</template>

<script>
import MainLayout from "@/components/layout/MainLayout";
import Tickets from "@/components/Tickets";
import Axios from "axios";
export default {
  name: "Home",
  components: {
    MainLayout,
    Tickets
  },
  data: () => ({
    tickets: []
  }),
  created() {
    Axios.get(`http://localhost:5000/api/tickets`).then(response => {
      this.tickets = response.data.result;
    });
  }
};
</script>
