<template>
  <v-container>
    <v-row>
      <v-col>
        <v-expansion-panels>
          <v-expansion-panel v-for="(item, i) in tickets" :key="i">
            <v-expansion-panel-header>
              <p class="text-center">
                <span class="font-weight-bold">{{ item.name }}</span
                >, {{ item.country }}, {{ item.price }} руб.
              </p>
              <v-spacer />
              <v-dialog v-model="buyDialog" max-width="800">
                <template #activator="{on, attrs}">
                  <v-btn
                    color="primary"
                    dark
                    v-bind="attrs"
                    v-on="on"
                    max-width="150"
                  >
                    Приобрести
                  </v-btn>
                </template>
                <v-card>
                  <v-card-title>
                    <span class="headline">Приобретение путевки</span>
                  </v-card-title>
                  <v-card-text>
                    <v-container>
                      <v-row justify="space-around">
                        <v-col>
                          <v-text-field
                            v-model="editedItem.first"
                            label="Фамилия"
                          ></v-text-field>
                        </v-col>
                        <v-col>
                          <v-text-field
                            v-model="editedItem.second"
                            label="Имя"
                          ></v-text-field>
                        </v-col>
                        <v-col>
                          <v-text-field
                            v-model="editedItem.third"
                            label="Отчество"
                          ></v-text-field>
                        </v-col>
                        <v-col align-self="center">
                          <masked-input
                            mask="\+\7 (111) 111-11-11"
                            placeholder="Номер телефона"
                            @input="editedItem.fourth = arguments[1]"
                          />
                        </v-col>
                      </v-row>
                    </v-container>
                  </v-card-text>
                  <v-card-actions>
                    <v-spacer />
                    <v-btn color="blue darken-1" text @click="closeBuyDialog">
                      Отмена
                    </v-btn>
                    <v-btn color="blue darken-1" text @click="buyItem(item)"
                      >Сохранить</v-btn
                    >
                  </v-card-actions>
                </v-card>
              </v-dialog>
            </v-expansion-panel-header>
            <v-expansion-panel-content>
              <v-container>
                <v-row>
                  <v-col> Название: {{ item.name }} </v-col>
                </v-row>
                <v-row>
                  <v-col> Страна: {{ item.country }}</v-col>
                </v-row>
                <v-row>
                  <v-col> Цена: {{ item.price }} руб.</v-col>
                </v-row>
                <v-row>
                  <v-col> Дата вылета: {{ moment(item.startDate) }}</v-col>
                </v-row>
                <v-row>
                  <v-col> Дата возвращения: {{ moment(item.endDate) }} </v-col>
                </v-row>
                <v-row>
                  <v-col>
                    Дополнительная информация: {{ item.otherInfo }}
                  </v-col>
                </v-row>
              </v-container>
            </v-expansion-panel-content>
          </v-expansion-panel>
        </v-expansion-panels>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import moment from "moment";
import MaskedInput from "vue-masked-input";
import Axios from "axios";
export default {
  name: "Tickets",
  props: {
    tickets: Array
  },
  components: {
    MaskedInput
  },
  methods: {
    moment(date) {
      return moment(date).format("LL");
    },
    closeBuyDialog() {
      this.buyDialog = false;
      this.editedItem = {};
    },
    buyItem(item) {
      Axios.post(`http://localhost:5000/api/buyer`, {
        fullName: `${this.editedItem.first +
          this.editedItem.second +
          this.editedItem.third}, ${this.editedItem.fourth}`,
        ticketId: item.id
      });
      this.closeBuyDialog();
    }
  },
  data: () => ({
    buyDialog: false,
    editedItem: {
      first: "",
      second: "",
      third: "",
      fourth: 0
    }
  })
};
</script>

<style scoped></style>
