<template>
    <div class="Dashboard">
        <ProfileNavBar />
        <v-layout align-center justify-center class="ma-8 text-center">
            <v-row class="ma-0 ml-8 md-12">
                <TransPanel dynamicID="assignedWorship">
                    <p id="worship_Counter">Counter{{wCounter}}</p>
                    <p id="worshipTxt" class="headline">Assigned Worships</p>
                </TransPanel>
            </v-row>
            <v-row class="ma-0 md-12">
                <TransPanel dynamicID="pendingReq">
                    <p id="pendReq_Counter">Counter{{prCounter}}</p>
                    <p id="pendingTxt" class="headline">Pending Swap Request</p>
                </TransPanel>
            </v-row>
        </v-layout>
        <v-layout align-center justify-center class="mt-10 text-center">
            <v-row class="mb-12 ml-5 md-12">
            <v-container class="news_Events">
                <p id="newsEvent_Heading" class="headline text-center ">News &amp; Events</p>
                <TransPanel dynamicID="newsEvents_P">
                    <ul id="newsEvent_List">
                        <li class="neList"><a class="neList_Item" href="_blank">News</a></li>
                        <li class="neList"><a class="neList_Item" href="_blank">News</a></li>
                        <li class="neList"><a class="neList_Item" href="_blank">Events</a></li>
                        <li class="neList"><a class="neList_Item" href="_blank">Events</a></li>
                    </ul>
                </TransPanel>
            </v-container>
            </v-row>
            <v-row class="ma-0 md-12">
                <v-container class="upComing_Worship">
                    <p id="upC_WorshipHeading" class="text-center headline ml-5 mb-6">Upcoming Worship</p>
                    <ul id="upC_Worship_List" class="mt-8">
                        <li class="listItem">
                            <div class="listContent">
                                <p>Event name</p>
                                <p>Event date</p>
                            </div>
                        </li>
                        <li class="listItem">
                            <div class="listContent">
                                <p>Event name</p>
                                <p>Event date</p>
                            </div>
                        </li>
                        <li class="listItem">
                            <div class="listContent">
                                <p>Event name</p>
                                <p>Event date</p>
                            </div>
                        </li>
                    </ul>
                </v-container>
            </v-row>
        </v-layout>
    </div>
</template>

<script>
import ProfileNavBar from '@/components/ProfileNavBar.vue'
import TransPanel from '@/components/TransPanel.vue'

export default {
    components: {
        ProfileNavBar,
        TransPanel
    }
}
</script>

<style lang="scss">
    html {
        width: 100%;
        height: 100%;
        background: url("../assets/DashBackground.png");
        background-size: 100%;
        overflow: hidden;
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
        color: white;
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
        height: 24px;
        width: 23px;
        text-align: center;
        line-height: 24px;
        background: dodgerblue;
    }
    #upC_Worship_List .listItem:before {
        position: absolute;
        left: 13px;
        top: 0;
        content: "";
        height: 125%;
        width: 0;
        border-left: 3.5px solid dodgerblue;
    }
    #upC_Worship_List .listItem:last-of-type:before {
        border: none;
    }
</style>