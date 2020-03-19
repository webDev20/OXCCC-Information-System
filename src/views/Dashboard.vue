<template>
    <div class="Dashboard">
        <appNavPBar />
        <v-layout align-center justify-center class="ma-8 text-center">
            <v-row class="ma-0 ml-8 md-12">
                <TransPanel dynamicID="assignedWorship">
                    <p id="worship_Counter">Under construction{{wCounter}}</p>
                    <p id="worshipTxt" class="headline">Assigned Worships</p>
                </TransPanel>
            </v-row>
            <v-row class="ma-0 md-12">
                <TransPanel dynamicID="pendingReq">
                    <p id="pendReq_Counter">Under contrusction{{prCounter}}</p>
                    <p id="pendingTxt" class="headline">Pending Swap Request</p>
                </TransPanel>
            </v-row>
        </v-layout>
        <v-layout align-center justify-center class="mt-10 text-center">
            <v-row class="mb-4 ml-8 md-12">
            <v-container class="news_Events">
                <v-card class="mx-auto" max-width="600">
                <v-carousel 
                cycle 
                height="300" 
                hide-delimiter-background  
                show-arrows-on-hover>
                    <v-carousel-item
                        :key="newS.key"
                        v-for="newS in newsList">
                        <v-sheet
                            color="green"
                            height="100%">
                            <v-row
                                class="fill-height"
                                align="center"
                                justify="center"
                            >
                            <p class="display-1 text--primary">
                                {{newS.name}}
                            </p>
                            <p id="newsText">
                                {{newS.newsDetails}}
                            </p>
                            </v-row>
                        </v-sheet>
                    </v-carousel-item>
                </v-carousel>
                </v-card>
            </v-container>
            </v-row>
            <v-row class="ma-0 md-12">
                <v-container class="upComing_Worship">
                    <p id="upC_WorshipHeading" class="text-center display-1 text--primary mx-auto">Upcoming Worship</p>
                    <ul id="upC_Worship_List" class="mt-10">
                        <li class="listItem" :key="event.key" v-for="event in events">
                            <div class="listContent">
                                <p id="eventName" class="headline">{{event.name}}</p>
                                <p id="eventDate" class="title">Worship date: {{event.start}}</p>
                            </div>
                        </li>
                    </ul>
                </v-container>
            </v-row>
        </v-layout>
    </div>
</template>

<script>
import appNavPBar from '@/components/appNavPBar.vue'
import TransPanel from '@/components/TransPanel.vue'
import { db } from '@/main';

export default {
    components: {
        appNavPBar,
        TransPanel
    },
    data: function () {
        return {
            wCounter: '',
            prCounter: '',
            iconList: ['looks_one', 'looks_two', 'looks_3', 'looks_4', 'looks_5', 'looks_6'],
            events: [],
            newsList: []
        }
    },
    mounted: function () {
        this.getEvents();
        this.getNews();
    },
    methods: {
        async getEvents () {
        let snapshot = await db.collection('rota')
        .where('news', '==', false)
        .where('startDate', '>', new Date())
        .orderBy('startDate', 'asc')
        .limit(3)
        .get()
        const events = []
        snapshot.forEach(doc => {
          let appData = doc.data()
          appData.id = doc.id
          events.push(appData)
        });
        this.events = events
        },
    async getNews () {
        let snapshotN = await db.collection('rota')
        .where('news', '==', true).get()
        const news = []
        snapshotN.forEach(doc => {
          let nData = doc.data()
          nData.id = doc.id
          news.push(nData)
        });
        this.newsList = news
        }
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

    #eventName, #eventDate {
        color: blue;
    }

    #assignedWorship {
        box-shadow: none;
        padding: 5.5px 10px;
        background: rgba(0, 0, 128, 0.7);
        height: 95px;
        width: 350px;;
        color: white;
    }

    #pendingReq {
        box-shadow: none;
        padding: 5.5px 10px;
        background: rgba(128, 0, 0, 0.7);
        height: 95px;
        width: 350px;
        color: white;
    }

    #worship_Counter, #pendingReq_Counter {
        font-size: 20px;
    }

    #newsEvent_List {
        list-style: none;
        padding-left: 10px;
    }

    .news_Events > #newsEvents_P {
        box-shadow: none;
        width: 450px;
    }

    .neList .neList_Item {
        font-size: 18px;
        text-decoration: none;
    }

    #newsText {
        width: 500px;
    }

    .upComing_Worship {
        margin-right: 100px;
    }

    #upC_Worship_List {
        display: block;
        list-style-type: none;
        counter-reset: steps;
        margin-left: 100px;
    }

    .listItem {
        color: yellow;
        font-size: 22px;
    }

    .listContent {
        margin-right: 100px;
    }

    #upC_Worship_List .listItem {
        padding: 0 0 10px 5px;
        position: relative;
        margin: 0;
    }
    #upC_Worship_List .listItem:after {
        position: absolute;
        top: 0;
        left: 0.125em;
        content: counter(steps);
        counter-increment: steps;
        border: 1.25px solid lightblue;
        border-radius: 1em;
        display: inline-block;
        height: 40px;
        width: 40px;
        text-align: center;
        line-height: 38px;
        background: dodgerblue;
    }
    #upC_Worship_List .listItem:before {
        position: absolute;
        left: 21px;
        top: 0;
        content: "";
        height: 120%;
        width: 0;
        border-left: 3.5px solid dodgerblue;
    }
    #upC_Worship_List .listItem:last-of-type:before {
        border: none;
    }
</style>