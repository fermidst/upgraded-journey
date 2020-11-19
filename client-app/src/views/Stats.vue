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
    </v-container>
    <v-row justify="center">
      <v-col lg="6">
        <v-data-table
          :headers="headers"
          :items="buyers"
          sort-by="id"
          class="elevation-4 ma-4 pa-4"
          disable-pagination
          hide-default-footer
        ></v-data-table>
      </v-col>
    </v-row>
    <PasswordDialog />
  </MainLayout>
</template>

<script>
import MainLayout from "@/components/layout/MainLayout";
import PasswordDialog from "@/components/PasswordDialog";
import Axios from "axios";
export default {
  name: "Stats",
  components: {
    MainLayout,
    PasswordDialog
  },
  data: () => ({
    headers: [
      { text: "Id", align: "start", value: "id" },
      { text: "ФИО", value: "fullName" },
      { text: "Id билета", value: "ticketId" }
    ],
    buyers: []
  }),
  created() {
    Axios.get(`http://localhost:5000/api/buyers`).then(response => {
      this.buyers = response.data.result;
    });
  }
};
</script>

<style scoped></style>
