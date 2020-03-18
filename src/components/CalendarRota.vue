<template>
    <div class="CalendarRota">
        <v-row class="fill-height">
            <v-col class="pa-0">
            <v-sheet height="66">
                <v-toolbar flat color="white">
                <v-btn outlined class="mr-4 ml-5" color="grey darken-2" @click="setToday">
                    Today
                </v-btn>
                <v-btn fab text small color="grey darken-2" @click="prev">
                    <v-icon small>mdi-chevron-left</v-icon>
                </v-btn>
                <v-btn fab text small color="grey darken-2" @click="next">
                    <v-icon small>mdi-chevron-right</v-icon>
                </v-btn>
                <v-toolbar-title>{{ title }}</v-toolbar-title>
                <v-spacer></v-spacer>
                <v-btn color="primary" dark @click.stop="dialog = true">
                  New rota
                </v-btn>
                <v-btn id="newsBtn" color="success" class="ml-3" dark @click.stop="news = true">
                  New news
                </v-btn>
                <v-spacer></v-spacer>
                <v-menu bottom right>
                    <template v-slot:activator="{ on }">
                    <v-btn
                        outlined
                        class="mr-5"
                        color="grey darken-2"
                        v-on="on"
                    >
                        <span>{{ typeToLabel[type] }}</span>
                        <v-icon right>mdi-menu-down</v-icon>
                    </v-btn>
                    </template>
                    <v-list>
                    <v-list-item @click="type = 'day'">
                        <v-list-item-title>Day</v-list-item-title>
                    </v-list-item>
                    <v-list-item @click="type = 'week'">
                        <v-list-item-title>Week</v-list-item-title>
                    </v-list-item>
                    <v-list-item @click="type = 'month'">
                        <v-list-item-title>Month</v-list-item-title>
                    </v-list-item>
                    <v-list-item @click="type = '4day'">
                        <v-list-item-title>4 days</v-list-item-title>
                    </v-list-item>
                    </v-list>
                </v-menu>
                </v-toolbar>
            </v-sheet>
            <v-dialog v-model="dialog" max-width="1250">
              <v-card>
                <v-toolbar :color="eventType" dark>
                  <v-toolbar-title v-html="name"></v-toolbar-title>
                </v-toolbar>
                <v-container fluid>
                <v-layout>
                  <v-row class="mr-5 md-12" align-center justify-center>
                    <v-container>
                      <v-form @submit.prevent="addEvent">
                        <v-text-field 
                        autofocus 
                        dense 
                        outlined 
                        v-model="name" 
                        type="text" 
                        label="Sermon title (required)"></v-text-field>
                        <v-text-field 
                        dense 
                        outlined 
                        v-model="scriptures" 
                        type="text" 
                        label="Scriptures (required)"></v-text-field>
                        <v-textarea 
                        dense 
                        outlined 
                        auto-grow 
                        label="Service details" v-model="details"></v-textarea>
                        <v-text-field 
                        dense 
                        outlined 
                        v-model="start" 
                        type="date" 
                        label="Event start date"></v-text-field>
                        <v-text-field 
                        dense 
                        outlined 
                        v-model="end" 
                        type="date" 
                        label="Event end date"></v-text-field>
                        <v-text-field 
                        dense 
                        outlined 
                        v-model="worshipDetails" 
                        type="text" 
                        label="Worship details"></v-text-field>
                        <v-select 
                        outlined 
                        dense 
                        v-model="eventType" 
                        :items="eventTypes" 
                        label="Choose Type" 
                        item-text="eType" 
                        item-value="eColor"></v-select>
                        <v-btn 
                        block 
                        :color="eventType" 
                        type="submit" 
                        @click.stop="dialog = false" 
                        dark>Save</v-btn>
                      </v-form>
                    </v-container>
                  </v-row>
                  <v-row class="mr-1 md-5" align-center justify-center>
                    <v-container id="songList">
                    <v-list dense>
                      <p class="text-center">Song Flow</p>
                      <v-list-item-group v-model="songs" color="primary">
                        <v-list-item v-for="(song, i) in songs" :key="i">
                          <v-list-item-icon>
                            <v-icon v-text="icon" @click="deleteSong(i)"></v-icon>
                          </v-list-item-icon>
                          <v-list-item-content>
                            <v-list-item-title v-text="song.songTitle + ' ' + song.songKey"></v-list-item-title>
                          </v-list-item-content>
                        </v-list-item>
                      </v-list-item-group>
                    </v-list>
                    </v-container>
                    <v-text-field id="songT" dense outlined v-model="songT" type="text" label="Song title"></v-text-field>
                    <v-select id="songK" outlined dense v-model="songKey" :items="songKeys" label="Key" item-text="eType"></v-select>
                    <v-btn block @click.prevent="addSong" dark>Add Song</v-btn>
                  </v-row>
                  <v-row class="ml-5 md-2" align-center justify-center>
                    <v-container>
                    <v-list dense>
                      <p class="text-center">Rota</p>
                      <v-list-item-group v-model="users" color="primary">
                        <v-list-item v-for="(user, i) in rota" :key="i">
                          <v-list-item-icon>
                            <v-icon v-text="icon" @click="deleteUser(i)"></v-icon>
                          </v-list-item-icon>
                          <v-list-item-content>
                            <v-list-item-title v-text="user.displayName + ' ' + user.role"></v-list-item-title>
                          </v-list-item-content>
                        </v-list-item>
                      </v-list-item-group>
                    </v-list>
                    </v-container>
                    <v-select id="userlist" outlined dense v-model="user" :items="users" label="Add user" item-text="displayName"></v-select>
                    <v-select id="rolelist" outlined dense v-model="role" :items="roles" label="Role"></v-select>
                    <v-btn block @click.prevent="addRota" dark>Add to rota</v-btn>
                  </v-row>
                </v-layout>
                </v-container>
              </v-card>
            </v-dialog>
            <v-dialog v-model="news" max-width="500">
              <v-card>
                <v-toolbar :color="newsColor" dark>
                  <v-toolbar-title v-html="name"></v-toolbar-title>
                </v-toolbar>
                    <v-container>
                      <v-form @submit.prevent="addNews">
                        <v-text-field 
                        autofocus 
                        dense 
                        outlined 
                        v-model="name" 
                        type="text" 
                        label="News title (required)"></v-text-field>
                        <v-text-field 
                        dense 
                        outlined 
                        v-model="start" 
                        type="date" 
                        label="News start date"></v-text-field>
                        <v-text-field 
                        dense 
                        outlined 
                        v-model="end" 
                        type="date" 
                        label="News end date"></v-text-field>
                        <v-textarea 
                        dense 
                        outlined 
                        auto-grow 
                        label="Enter the news information" v-model="newsDetails"></v-textarea>
                        <v-btn 
                        block 
                        :color="newsColor" 
                        type="submit" 
                        @click.stop="news = false" 
                        dark>Save news</v-btn>
                      </v-form>
                    </v-container>
              </v-card>
            </v-dialog>
            <v-dialog v-if="selectedEvent.color != 'green'" v-model="deleteDialog" persistent max-width="250">
              <v-card>
                <v-card-title class="headline">Confirm delete ?</v-card-title>
                <v-card-text>This rota will be deleted forever, are you sure?</v-card-text>
                <v-card-actions>
                  <v-spacer></v-spacer>
                  <v-btn text color="primary" @click="deleteDialog = false">Cancel</v-btn>
                  <v-btn text color="red accent-4" @click="deleteEN(selectedEvent.id)">Delete</v-btn>
                </v-card-actions>
              </v-card>
            </v-dialog>
            <v-dialog v-else v-model="deleteDialog" persistent max-width="250">
              <v-card>
                <v-card-title class="headline">Confirm delete ?</v-card-title>
                <v-card-text>This news will be deleted forever, are you sure?</v-card-text>
                <v-card-actions>
                  <v-spacer></v-spacer>
                  <v-btn text color="primary" @click="deleteDialog = false">Cancel</v-btn>
                  <v-btn text color="red accent-4" @click="deleteEN(selectedEvent.id)">Delete</v-btn>
                </v-card-actions>
              </v-card>
            </v-dialog>
            <v-sheet minHeight="700" height="700" class="ml-3">
                <v-calendar
                ref="calendar"
                v-model="focus"
                color="primary"
                :events="events"
                :event-color="getEventColor"
                :event-margin-bottom="3"
                :now="today"
                :type="type"
                @click:event="showEvent"
                @click:more="viewDay"
                @click:date="viewDay"
                @change="updateRange"
                ></v-calendar>
                <v-menu
                v-if="selectedEvent.color != 'green'"
                v-model="selectedOpen"
                :close-on-content-click="false"
                :activator="selectedElement"
                offset-x
                >
                <v-card
                    color="grey lighten-4"
                    min-width="725px"
                    flat
                >
                    <v-toolbar
                    :color="selectedEvent.color"
                    dark
                    >
                    <v-btn 
                    icon 
                    v-if="edit !== selectedEvent.id"
                    @click.prevent="edit(selectedEvent)">
                        <v-icon >mdi-pencil</v-icon>
                    </v-btn>
                    <v-toolbar-title v-html="selectedEvent.name"></v-toolbar-title>
                    </v-toolbar>
                  <v-container fluid v-if="editMode !== selectedEvent.id">
                  <v-layout>
                    <v-row class="mr-5 md-12" align-center justify-center>
                      <v-container>
                        <v-form>
                          <v-text-field
                          readonly
                          dense
                          outlined 
                          v-model="selectedEvent.name" 
                          type="text" 
                          label="Sermon title (required)"></v-text-field>
                          <v-text-field
                          readonly
                          dense 
                          outlined 
                          v-model="selectedEvent.scriptures" 
                          type="text" 
                          label="Scriptures (required)"></v-text-field>
                          <v-textarea 
                          readonly
                          dense 
                          outlined 
                          auto-grow 
                          label="Service details" v-model="selectedEvent.details"></v-textarea>
                          <v-text-field
                          readonly
                          dense 
                          outlined 
                          v-model="selectedEvent.start" 
                          type="date" 
                          label="Event start date"></v-text-field>
                          <v-text-field
                          readonly
                          dense 
                          outlined 
                          v-model="selectedEvent.end" 
                          type="date" 
                          label="Event end date"></v-text-field>
                          <v-text-field
                          readonly
                          dense 
                          outlined 
                          v-model="selectedEvent.worshipDetails" 
                          type="text" 
                          label="Worship details"></v-text-field>
                        </v-form>
                      </v-container>
                    </v-row>
                    <v-row class="mr-1 md-5" align-center justify-center>
                      <v-container id="songList">
                      <v-list dense>
                        <p class="text-center">Song Flow</p>
                        <v-list-item-group v-model="songs" color="primary">
                          <v-list-item v-for="(song, i) in selectedEvent.songs" :key="i">
                            <v-list-item-content>
                              <v-list-item-title v-text="song.songTitle + ' ' + song.songKey"></v-list-item-title>
                            </v-list-item-content>
                          </v-list-item>
                        </v-list-item-group>
                      </v-list>
                      </v-container>
                    </v-row>
                    <v-row class="ml-5 md-2" align-center justify-center>
                      <v-container>
                      <v-list dense>
                        <p class="text-center">Rota</p>
                        <v-list-item-group v-model="users" color="primary">
                          <v-list-item v-for="(user, i) in selectedEvent.rota" :key="i">
                            <v-list-item-content>
                              <v-list-item-title v-text="user.displayName + ' ' + user.role"></v-list-item-title>
                            </v-list-item-content>
                          </v-list-item>
                        </v-list-item-group>
                      </v-list>
                      </v-container>
                    </v-row>
                  </v-layout>
                  </v-container>
                <v-container fluid v-else>
                <v-layout>
                  <v-row class="mr-5 md-12" align-center justify-center>
                    <v-container>
                      <v-form @submit.prevent="updateEvent">
                        <v-text-field 
                        autofocus 
                        dense 
                        outlined
                        v-if="selectedevent.name != null"
                        v-model="selectedEvent.name" 
                        type="text" 
                        label="Sermon title (required)"></v-text-field>
                        <v-text-field 
                        autofocus 
                        dense 
                        outlined
                        v-else
                        v-model="name" 
                        type="text" 
                        label="Sermon title (required)"></v-text-field>
                        <v-text-field 
                        dense 
                        outlined
                        v-if="selectedEvent.scriptures != null"
                        v-model="selectedEvent.scriptures" 
                        type="text" 
                        label="Scriptures (required)"></v-text-field>
                        <v-text-field 
                        dense 
                        outlined
                        v-else
                        v-model="scriptures" 
                        type="text" 
                        label="Scriptures (required)"></v-text-field>
                        <v-textarea 
                        dense 
                        outlined 
                        auto-grow 
                        label="Service details"
                        v-if="selectedEvent.details == null" 
                        v-model="selectedEvent.details"></v-textarea>
                        <v-textarea 
                        dense 
                        outlined 
                        auto-grow 
                        label="Service details"
                        v-else 
                        v-model="selectedEvent.details"></v-textarea>
                        <v-text-field 
                        dense 
                        outlined
                        v-if="selectedEvent.start != null"
                        v-model="selectedEvent.start" 
                        type="date" 
                        label="Event start date"></v-text-field>
                        <v-text-field 
                        dense 
                        outlined
                        v-else
                        v-model="selectedEvent.start" 
                        type="date" 
                        label="Event start date"></v-text-field>
                        <v-text-field 
                        dense 
                        outlined
                        v-if="selectedEvent.end != null"
                        v-model="selectedEvent.end" 
                        type="date" 
                        label="Event end date"></v-text-field>
                        <v-text-field 
                        dense 
                        outlined
                        v-else
                        v-model="selectedEvent.end" 
                        type="date" 
                        label="Event end date"></v-text-field>
                        <v-text-field 
                        dense 
                        outlined
                        v-if="selectedEvent.worshipDetails != null" 
                        v-model="selectedEvent.worshipDetails" 
                        type="text" 
                        label="Worship details"></v-text-field>
                        <v-text-field 
                        dense 
                        outlined
                        v-else 
                        v-model="worshipDetails" 
                        type="text" 
                        label="Worship details"></v-text-field>
                        <v-select 
                        outlined 
                        dense 
                        v-model="selectedEvent.color" 
                        :items="eventTypes" 
                        label="Choose Type" 
                        item-text="eType" 
                        item-value="eColor"></v-select>
                        <v-btn 
                        block 
                        :color="eventType" 
                        type="submit" 
                        @click.stop="dialog = false" 
                        dark>Update</v-btn>
                      </v-form>
                    </v-container>
                  </v-row>
                  <v-row class="mr-1 md-5" align-center justify-center>
                    <v-container id="songList" v-if="selectedEvent.songs != null">
                    <v-list dense>
                      <p class="text-center">Song Flow</p>
                      <v-list-item-group v-model="selectedEvent.songs" color="primary"> <!--potential error --> 
                        <v-list-item v-for="(song, i) in selectedEvent.songs" :key="i">
                          <v-list-item-icon>
                            <v-icon v-text="icon" @click="deleteSong(i)"></v-icon>
                          </v-list-item-icon>
                          <v-list-item-content>
                            <v-list-item-title v-text="song.songTitle + ' ' + song.songKey"></v-list-item-title>
                          </v-list-item-content>
                        </v-list-item>
                      </v-list-item-group>
                    </v-list>
                    </v-container>
                    <v-container id="songList" v-else>
                    <v-list dense>
                      <p class="text-center">Song Flow</p>
                      <v-list-item-group v-model="songs" color="primary"> <!--potential error --> 
                        <v-list-item v-for="(song, i) in songs" :key="i">
                          <v-list-item-icon>
                            <v-icon v-text="icon" @click="deleteSong(i)"></v-icon>
                          </v-list-item-icon>
                          <v-list-item-content>
                            <v-list-item-title v-text="song.songTitle + ' ' + song.songKey"></v-list-item-title>
                          </v-list-item-content>
                        </v-list-item>
                      </v-list-item-group>
                    </v-list>
                    </v-container>
                    <v-text-field id="songT" dense outlined v-model="songT" type="text" label="Song title"></v-text-field>
                    <v-select id="songK" outlined dense v-model="songKey" :items="songKeys" label="Key" item-text="eType"></v-select>
                    <v-btn block @click.prevent="addSong" dark>Add Song</v-btn>
                  </v-row>
                  <v-row class="ml-5 md-2" align-center justify-center>
                    <v-container v-if="selectedEvent.rota != null">
                    <v-list dense>
                      <p class="text-center">Rota</p>
                      <v-list-item-group v-model="selectedEvent.users" color="primary">
                        <v-list-item v-for="(user, i) in selectedEvent.rota" :key="i">
                          <v-list-item-icon>
                            <v-icon v-text="icon" @click="deleteUser(i)"></v-icon>
                          </v-list-item-icon>
                          <v-list-item-content>
                            <v-list-item-title v-text="user.displayName + ' ' + user.role"></v-list-item-title>
                          </v-list-item-content>
                        </v-list-item>
                      </v-list-item-group>
                    </v-list>
                    </v-container>
                    <v-container v-else>
                    <v-list dense>
                      <p class="text-center">Rota</p>
                      <v-list-item-group v-model="users" color="primary">
                        <v-list-item v-for="(user, i) in rota" :key="i">
                          <v-list-item-icon>
                            <v-icon v-text="icon" @click="deleteUser(i)"></v-icon>
                          </v-list-item-icon>
                          <v-list-item-content>
                            <v-list-item-title v-text="user.displayName + ' ' + user.role"></v-list-item-title>
                          </v-list-item-content>
                        </v-list-item>
                      </v-list-item-group>
                    </v-list>
                    </v-container>
                    <v-select id="userlist" outlined dense v-model="user" :items="users" label="Add user" item-text="displayName"></v-select>
                    <v-select id="rolelist" outlined dense v-model="role" :items="roles" label="Role"></v-select>
                    <v-btn block @click.prevent="addRota" dark>Add to rota</v-btn>
                  </v-row>
                </v-layout>
                </v-container>
                    <v-card-actions>
                    <v-btn
                        text
                        color="primary"
                        @click="selectedOpen = false"
                    >
                        Close
                    </v-btn>
                    <v-btn
                        text
                        color="red accent-4"
                        @click="deleteDialog = true"
                    >
                        Delete
                    </v-btn>
                    </v-card-actions>
                </v-card>
                </v-menu>
                <v-menu
                v-else
                v-model="selectedOpen"
                :close-on-content-click="false"
                :activator="selectedElement"
                offset-x
                >
                <v-card
                    color="grey lighten-4"
                    min-width="725px"
                    flat
                >
                    <v-toolbar
                    :color="selectedEvent.color"
                    dark
                    >
                    <v-btn 
                    icon 
                    v-if="edit !== selectedEvent.id"
                    @click.prevent="editNews(selectedEvent)">
                        <v-icon >mdi-pencil</v-icon>
                    </v-btn>
                    <v-toolbar-title v-html="selectedEvent.name"></v-toolbar-title>
                    </v-toolbar>
                    <v-container fluid v-if="editMode !== selectedEvent.id">
                      <v-form>
                        <v-text-field 
                        readonly 
                        dense 
                        outlined 
                        v-model="selectedEvent.name" 
                        type="text" 
                        label="News title (required)"></v-text-field>
                        <v-text-field
                        readonly 
                        dense 
                        outlined 
                        v-model="selectedEvent.start" 
                        type="date" 
                        label="News start date"></v-text-field>
                        <v-text-field
                        readonly 
                        dense 
                        outlined 
                        v-model="selectedEvent.end" 
                        type="date" 
                        label="News end date"></v-text-field>
                        <v-textarea
                        readonly
                        dense 
                        outlined 
                        auto-grow 
                        label="Enter the news information" v-model="selectedEvent.newsDetails"></v-textarea>
                      </v-form>
                    </v-container>
                    <v-container fluid v-else>
                      <v-form @submit.prevent="updateNews">
                        <v-text-field 
                        autofocus 
                        dense 
                        outlined
                        v-if="selectedElement.name != null"
                        v-model="selectedEvent.name" 
                        type="text" 
                        label="News title (required)"></v-text-field>
                        <v-text-field 
                        autofocus 
                        dense 
                        outlined
                        v-else
                        v-model="name" 
                        type="text" 
                        label="News title (required)"></v-text-field>
                        <v-text-field
                        dense 
                        outlined
                        v-if="selectedEvent.start != null"
                        v-model="selectedEvent.start" 
                        type="date" 
                        label="News start date"></v-text-field>
                        <v-text-field
                        dense 
                        outlined
                        v-else
                        v-model="start" 
                        type="date" 
                        label="News start date"></v-text-field>
                        <v-text-field
                        dense 
                        outlined
                        v-if="selectedEvent.end != null"
                        v-model="selectedEvent.end" 
                        type="date" 
                        label="News end date"></v-text-field>
                        <v-text-field
                        dense 
                        outlined
                        v-else
                        v-model="end" 
                        type="date" 
                        label="News end date"></v-text-field>
                        <v-textarea
                        dense 
                        outlined 
                        auto-grow 
                        label="Enter the news information"
                        v-if="selectedEvent.newsDetails != null"
                        v-model="selectedEvent.newsDetails"></v-textarea>
                        <v-textarea
                        dense 
                        outlined 
                        auto-grow 
                        label="Enter the news information"
                        v-else
                        v-model="newsDetails"></v-textarea>
                        <v-btn 
                        block 
                        :color="newsColor" 
                        type="submit"
                        @click.stop="news = false"
                        dark>Update news</v-btn>
                      </v-form>
                    </v-container>
                      <v-card-actions>
                        <v-btn
                            text
                            color="primary"
                            @click="selectedOpen = false"
                        >
                            Close
                        </v-btn>
                        <v-btn
                            text
                            color="red accent-4"
                            @click="deleteDialog = true"
                        >
                            Delete
                        </v-btn>
                      </v-card-actions>
                </v-card>
                </v-menu>
            </v-sheet>
            </v-col>
        </v-row>
    </div>
</template>

<script>
import { db } from '@/main';
import firebase from "firebase";
export default {
    data: function() {
      return {
        focus: '',
        type: 'month',
        typeToLabel: {
          month: 'Month',
          week: 'Week',
          day: 'Day',
          '4day': '4 Days',
        },
        start: '',
        end: '',
        selectedEvent: {},
        selectedElement: null,
        selectedOpen: false,
        events: [],
        colors: 'blue',
        icon: 'delete',
        dialog: false,
        news: false,
        deleteDialog: false,
        name: null,
        details: null,
        scriptures: null,
        worshipDetails: null,
        eventType: null,
        eventTypes: [
          {eColor: 'blue', eType: 'Sunday service'},
          {eColor: 'red', eType: 'Student fellowship'}
        ],
        songT: null,
        songs: [],
        songKey: null,
        songKeys: ["A", "Ab", "A#", "Bb", "B", "C", "C#", "Db", "D", "D#", "Eb", "E", "F", "F#", "Gb", "G", "G#"],
        rota: [],
        role: null,
        roles: ["Worship leader","Vocalist", "Piano (Keyboard)", "Drummer", "AV", "Speaker translator", "Chair person"],
        user: null,
        users: [],
        editMode: null,
        newsColor: 'green',
        newsDetails: null
      }
    },
    computed: {
      title () {
        const { start, end } = this
        if (!start || !end) {
          return ''
        }

        const startMonth = this.monthFormatter(start)
        const endMonth = this.monthFormatter(end)
        const suffixMonth = startMonth === endMonth ? '' : endMonth

        const startYear = start.year
        const endYear = end.year
        const suffixYear = startYear === endYear ? '' : endYear

        const startDay = start.day + this.nth(start.day)
        const endDay = end.day + this.nth(end.day)

        switch (this.type) {
          case 'month':
            return `${startMonth} ${startYear}`
          case 'week':
          case '4day':
            return `${startMonth} ${startDay} ${startYear} - ${suffixMonth} ${endDay} ${suffixYear}`
          case 'day':
            return `${startMonth} ${startDay} ${startYear}`
        }
        return ''
      },
      monthFormatter () {
        return this.$refs.calendar.getFormatter({
          timeZone: 'UTC', month: 'long',
        })
      },
    },
    mounted: function () {
      this.getEvents();
      this.getUsers();
    },
    methods: {
      async deleteEN(selectedEvent) {
        await db.collection('rota').doc(selectedEvent).delete()
        this.deleteDialog = false,
        this.getEvents()
      },
      editNews (selectedEvent) {
        this.editMode = selectedEvent.id;
        if (selectedEvent.newsDetails == null) {
          this.newsDetails = null;
          console.log(this.newsDetails);
        } else {
          this.newsDetails = selectedEvent.newsDetails;
          console.log(this.newsDetails);
        }
        this.name = selectedEvent.name;
        this.start = selectedEvent.start;
        this.end = selectedEvent.end;
      },
      async updateNews() {
        await db.collection('rota').doc(this.editMode).update({
          name: this.name,
          newsDetails: this.newsDetails,
          color: this.newsColor,
          startDate: new firebase.firestore.Timestamp.fromDate(new Date(this.start + "T00:00:00")),
          endDate: new firebase.firestore.Timestamp.fromDate(new Date(this.end + "T00:00:00")),
          start: new Date(this.start).toISOString().substring(0, 10),
          end: new Date(this.end).toISOString().substring(0, 10)
        });
        this.getEvents();
        this.selectedOpen = false,
        this.editMode = null,
        this.name = '',
        this.start = '',
        this.end = '',
        this.newsDetails = null
      },
      async addNews() {
        if (this.name && this.start && this.end) {
          await db.collection('rota').add({
            name: this.name,
            startDate: new firebase.firestore.Timestamp.fromDate(new Date(this.start + "T00:00:00")),
            endDate: new firebase.firestore.Timestamp.fromDate(new Date(this.end + "T00:00:00")),
            start: new Date(this.start).toISOString().substring(0, 10),
            end: new Date(this.end).toISOString().substring(0, 10),
            newsDetails: this.newsDetails,
            color: this.newsColor,
            news: true
          });
          this.getEvents()
          this.name = '',
          this.start = '',
          this.end = ''
          this.newsDetails = null
        } else {
          alert('You must enter News title, start, and end time')
        }
      },
      async updateEvent() {
        await db.collection('rota').doc(this.editMode).update({
          name: this.name,
          details: this.details,
          worshipDetails: this.worshipDetails,
          scriptures: this.scriptures,
          startDate: new firebase.firestore.Timestamp.fromDate(new Date(this.start + "T00:00:00")),
          endDate: new firebase.firestore.Timestamp.fromDate(new Date(this.end + "T00:00:00")),
          start: new Date(this.start).toISOString().substring(0, 10),
          end: new Date(this.end).toISOString().substring(0, 10),
          color: this.selectedEvent.color,
          songs: this.songs,
          rota: this.rota
        });
        this.getEvents();
        this.selectedOpen = false,
        this.editMode = null,
        this.name = '',
        this.details = '',
        this.worshipDetails = '',
        this.start = '',
        this.end = '',
        this.color = '',
        this.scriptures = '',
        this.songs = [],
        this.rota = []
      },
      edit (selectedEvent) {
        this.editMode = selectedEvent.id;
        if (selectedEvent.name == null) {
          this.name = null
        } else {
          this.name = selectedEvent.name;
        }
        if (selectedEvent.start == null) {
          this.start = ''
        } else {
          this.start = selectedEvent.start;
        }
        if (selectedEvent.end == null) {
          this.end = ''
        } else {
          this.end = selectedEvent.end;
        }
        if (selectedEvent.eventType == null) {
          this.eventType = null;
        } else {
          this.eventType = selectedEvent.eventType;
        }
        if (selectedEvent.details == null) {
          this.details = null;
        } else {
          this.details = selectedEvent.details;
        }
        if (selectedEvent.worshipDetails == null) {
          this.worshipDetails = null;
        } else {
          this.worshipDetails = selectedEvent.worshipDetails;
        }
        if (selectedEvent.worshipDetails == null) {
          this.scriptures = null;
        } else {
          this.scriptures = selectedEvent.scriptures;
        }
        if (selectedEvent.songs == null) {
          this.songs = [];
        } else {
          this.songs = selectedEvent.songs;
        }
        if (selectedEvent.rota == null) {
          this.rota = [];
        } else {
          this.rota = selectedEvent.rota;
        }
      },
      addRota() {
        this.rota.push({displayName: this.user, role: this.role});
        this.user = null;
        this.role = null;
      },
      deleteUser(i) {
        this.rota.splice(i, 1);
      },
      addSong() {
        this.songs.push({songTitle: this.songT, songKey: this.songKey});
        this.songT = null;
        this.songKey = null;
      },
        deleteSong(i) {
          this.songs.splice(i, 1);
      },
        async getUsers() {
          let snapshot = await db.collection('users').get()
          const users = []
          snapshot.forEach(doc => {
            let uData = doc.data()
            uData.id = doc.id
            users.push(uData)
          });
          this.users = users
      },
        async getEvents () {
        let snapshot = await db.collection('rota').get()
        const events = []
        snapshot.forEach(doc => {
          let appData = doc.data()
          appData.id = doc.id
          events.push(appData)
        });
        this.events = events
      },
        async addEvent () {
        if (this.name && this.start && this.end) {
          await db.collection('rota').add({
            name: this.name,
            details: this.details,
            worshipDetails: this.worshipDetails,
            scriptures: this.scriptures,
            startDate: new firebase.firestore.Timestamp.fromDate(new Date(this.start + "T00:00:00")),
            endDate: new firebase.firestore.Timestamp.fromDate(new Date(this.end + "T00:00:00")),
            start: new Date(this.start).toISOString().substring(0, 10),
            end: new Date(this.end).toISOString().substring(0, 10),
            color: this.eventType,
            songs: this.songs,
            rota: this.rota,
            news: false
          })
          this.getEvents()
          this.name = '',
          this.details = '',
          this.worshipDetails = '',
          this.start = '',
          this.end = '',
          this.color = '',
          this.scriptures = '',
          this.songs = [],
          this.rota = []
        } else {
          alert('You must enter service title, start, and end time')
        }
      },
      viewDay ({ date }) {
        this.focus = date
        this.type = 'day'
      },
      getEventColor (event) {
        return event.color
      },
      setToday () {
        this.focus = this.today
      },
      prev () {
        this.$refs.calendar.prev()
      },
      next () {
        this.$refs.calendar.next()
      },
      showEvent ({ nativeEvent, event }) {
        const open = () => {
          this.selectedEvent = event
          this.selectedElement = nativeEvent.target
          setTimeout(() => this.selectedOpen = true, 10)
        }

        if (this.selectedOpen) {
          this.selectedOpen = false
          setTimeout(open, 10)
        } else {
          open()
        }

        nativeEvent.stopPropagation()
      },
      updateRange ({ start, end }) {
        this.start = start
        this.end = end
      },
      nth (d) {
        return d > 3 && d < 21
          ? 'th'
          : ['th', 'st', 'nd', 'rd', 'th', 'th', 'th', 'th', 'th', 'th'][d % 10]
      },
      formatDate (a, withTime) {
        return withTime
          ? `${a.getFullYear()}-${a.getMonth() + 1}-${a.getDate()} ${a.getHours()}:${a.getMinutes()}`
          : `${a.getFullYear()}-${a.getMonth() + 1}-${a.getDate()}`
      },
    }
}
</script>

<style lang="scss">
  #songT   {
    width: 15px;
  }

  #songK  {
    width: 1px;
  }

  #userlist, #rolelist {
    width: 15px;
  }
</style>