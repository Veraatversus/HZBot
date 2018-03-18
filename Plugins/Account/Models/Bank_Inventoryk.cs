
public class JsonRoot
{
    public Data data { get; set; }
    public string error { get; set; }
}

public class Data
{
    public User user { get; set; }
    public Character character { get; set; }
    public string user_geo_location { get; set; }
    public Inventory inventory { get; set; }
    public Bank_Inventory bank_inventory { get; set; }
    public Quest[] quests { get; set; }
    public Item[] items { get; set; }
    public object[] campaigns { get; set; }
    public object[] worldboss_event_character_data { get; set; }
    public Event_Quest event_quest { get; set; }
    public Bonus_Info bonus_info { get; set; }
    public string _ref { get; set; }
    public bool reskill_enabled { get; set; }
    public Advertisment_Info advertisment_info { get; set; }
    public bool show_advertisment { get; set; }
    public bool show_preroll_advertisment { get; set; }
    public int tournament_end_timestamp { get; set; }
    public int league_season_end_timestamp { get; set; }
    public Current_Goal_Values current_goal_values { get; set; }
    public Collected_Goals[] collected_goals { get; set; }
    public Current_Item_Pattern_Values current_item_pattern_values { get; set; }
    public object[] collected_item_pattern { get; set; }
    public Current_Optical_Changes current_optical_changes { get; set; }
    public object[] collected_optical_changes { get; set; }
    public int missed_duels { get; set; }
    public int missed_league_fights { get; set; }
    public Streams_Info streams_info { get; set; }
    public int new_guild_log_entries { get; set; }
    public bool league_locked { get; set; }
    public bool tos_update_needed { get; set; }
    public string[] ad_provider_keys { get; set; }
    public Local_Notification_Settings local_notification_settings { get; set; }
    public int missed_hideout_attacks { get; set; }
    public int guild_gem_production_level { get; set; }
    public bool new_version { get; set; }
    public int login_count { get; set; }
    public int server_timestamp_offset { get; set; }
    public float time_correction { get; set; }
    public int server_time { get; set; }
}

public class Event_Quest
{
    public int id { get; set; }
    public int character_id { get; set; }
    public string identifier { get; set; }
    public int status { get; set; }
    public int objective1_value { get; set; }
    public int objective2_value { get; set; }
    public int objective3_value { get; set; }
    public int objective4_value { get; set; }
    public int objective5_value { get; set; }
    public int objective6_value { get; set; }
    public int objective7_value { get; set; }
    public int objective8_value { get; set; }
    public int objective9_value { get; set; }
    public int objective10_value { get; set; }
    public string rewards { get; set; }
    public int reward_item1_id { get; set; }
    public int reward_item2_id { get; set; }
    public int reward_item3_id { get; set; }
    public string end_date { get; set; }
}

public class Bonus_Info
{
    public int quest_energy { get; set; }
    public int duel_stamina { get; set; }
    public int league_stamina { get; set; }
    public int training_count { get; set; }
    public int quest_xp { get; set; }
    public int quest_coins { get; set; }
}

public class Advertisment_Info
{
    public bool show_advertisment { get; set; }
    public bool show_preroll_advertisment { get; set; }
    public bool show_left_skyscraper_advertisment { get; set; }
    public bool show_pop_under_advertisment { get; set; }
    public bool show_footer_billboard_advertisment { get; set; }
    public int advertisment_refresh_rate { get; set; }
    public int mobile_interstitial_cooldown { get; set; }
    public int remaining_video_advertisment_cooldown__1 { get; set; }
    public int video_advertisment_blocked_time__1 { get; set; }
    public int remaining_video_advertisment_cooldown__2 { get; set; }
    public int video_advertisment_blocked_time__2 { get; set; }
    public int remaining_video_advertisment_cooldown__3 { get; set; }
    public int video_advertisment_blocked_time__3 { get; set; }
    public int remaining_video_advertisment_cooldown__4 { get; set; }
    public int video_advertisment_blocked_time__4 { get; set; }
    public int remaining_video_advertisment_cooldown__5 { get; set; }
    public int video_advertisment_blocked_time__5 { get; set; }
}

public class Current_Goal_Values
{
    public Level_Reached level_reached { get; set; }
    public Stage_Reached stage_reached { get; set; }
    public Second_Quests_Completed second_quests_completed { get; set; }
    public Quests_Completed quests_completed { get; set; }
    public Second_Duel_Completed second_duel_completed { get; set; }
    public Duels_Completed duels_completed { get; set; }
    public Second_Day_Logged_In second_day_logged_in { get; set; }
    public Days_Logged_In days_logged_in { get; set; }
    public Shop_Refresh shop_refresh { get; set; }
    public Shop_Refreshed shop_refreshed { get; set; }
    public Time_Worked time_worked { get; set; }
    public First_Training_Absolved first_training_absolved { get; set; }
    public Trainings_Absolved trainings_absolved { get; set; }
    public Honor_Reached honor_reached { get; set; }
    public All_Stats_Value_Reached all_stats_value_reached { get; set; }
    public Duels_Won duels_won { get; set; }
    public Duels_Won_In_Row duels_won_in_row { get; set; }
    public Duels_Lost duels_lost { get; set; }
    public Fight_Quests_Won_Hard fight_quests_won_hard { get; set; }
    public Player_Profile_Visit player_profile_visit { get; set; }
    public Leaderboard_Visit leaderboard_visit { get; set; }
    public Stat_Point_Bought stat_point_bought { get; set; }
    public Rare_Item_Bought rare_item_bought { get; set; }
    public Epic_Item_Bought epic_item_bought { get; set; }
    public Mission_Booster_Bought mission_booster_bought { get; set; }
    public Stats_Booster_Bought stats_booster_bought { get; set; }
    public Work_Booster_Bought work_booster_bought { get; set; }
    public Character_Full_Equipped character_full_equipped { get; set; }
    public Energy_Bought energy_bought { get; set; }
    public Item_Sold item_sold { get; set; }
    public Tutorial_Completed tutorial_completed { get; set; }
    public Coins_Spent_A_Day coins_spent_a_day { get; set; }
    public Quest_Stage1_Fight1 quest_stage1_fight1 { get; set; }
    public Quest_Stage1_Fight2 quest_stage1_fight2 { get; set; }
    public Quest_Stage1_Fight3 quest_stage1_fight3 { get; set; }
    public Quest_Stage1_Fight7 quest_stage1_fight7 { get; set; }
    public Quest_Stage1_Fight8 quest_stage1_fight8 { get; set; }
    public Quest_Stage1_Time5 quest_stage1_time5 { get; set; }
    public Quest_Stage2_Fight5 quest_stage2_fight5 { get; set; }
    public Quest_Stage2_Fight6 quest_stage2_fight6 { get; set; }
    public Quest_Stage2_Fight7 quest_stage2_fight7 { get; set; }
    public Quest_Stage2_Fight8 quest_stage2_fight8 { get; set; }
    public Quest_Stage2_Fight10 quest_stage2_fight10 { get; set; }
    public Quest_Stage2_Time16 quest_stage2_time16 { get; set; }
    public Quest_Stage3_Fight4 quest_stage3_fight4 { get; set; }
    public Quest_Stage3_Fight5 quest_stage3_fight5 { get; set; }
    public Quest_Stage3_Fight6 quest_stage3_fight6 { get; set; }
    public Quest_Stage3_Fight7 quest_stage3_fight7 { get; set; }
    public Quest_Stage3_Fight8 quest_stage3_fight8 { get; set; }
    public Quest_Stage3_Time12 quest_stage3_time12 { get; set; }
    public Quest_Stage4_Fight3 quest_stage4_fight3 { get; set; }
    public Quest_Stage4_Fight7 quest_stage4_fight7 { get; set; }
    public Quest_Stage4_Time8 quest_stage4_time8 { get; set; }
    public Quest_Stage4_Time15 quest_stage4_time15 { get; set; }
    public Quest_Stage4_Time16 quest_stage4_time16 { get; set; }
    public Quest_Stage5_Fight1 quest_stage5_fight1 { get; set; }
    public Quest_Stage5_Fight2 quest_stage5_fight2 { get; set; }
    public Quest_Stage5_Fight5 quest_stage5_fight5 { get; set; }
    public Quest_Stage5_Time11 quest_stage5_time11 { get; set; }
    public Quest_Stage5_Time15 quest_stage5_time15 { get; set; }
    public Quest_Stage6_Fight5 quest_stage6_fight5 { get; set; }
    public Quest_Stage6_Fight7 quest_stage6_fight7 { get; set; }
    public Quest_Stage6_Fight8 quest_stage6_fight8 { get; set; }
    public Quest_Stage6_Time4 quest_stage6_time4 { get; set; }
    public Quest_Stage6_Time5 quest_stage6_time5 { get; set; }
    public Quest_Stage6_Time7 quest_stage6_time7 { get; set; }
    public Quest_Stage6_Time14 quest_stage6_time14 { get; set; }
    public Quest_Stage6_Time15 quest_stage6_time15 { get; set; }
    public Quest_Stage6_Time19 quest_stage6_time19 { get; set; }
    public Duels_Started_A_Day duels_started_a_day { get; set; }
    public Shop_Refreshed_A_Day shop_refreshed_a_day { get; set; }
    public Missles_Fired missles_fired { get; set; }
    public Donuts_Spent donuts_spent { get; set; }
    public Guild_Joined guild_joined { get; set; }
    public Guild_Donated guild_donated { get; set; }
    public Guild_Visited guild_visited { get; set; }
    public Account_Confirmed account_confirmed { get; set; }
    public First_Guild_Battle_Fought first_guild_battle_fought { get; set; }
    public Guild_Battles_Fought guild_battles_fought { get; set; }
    public Guild_Battles_Won guild_battles_won { get; set; }
    public Guild_Battles_Lost guild_battles_lost { get; set; }
    public First_Guild_Artifact_Won first_guild_artifact_won { get; set; }
    public Guild_Artifacts_Won guild_artifacts_won { get; set; }
    public Quest_Stage7_Time2 quest_stage7_time2 { get; set; }
    public Quest_Stage7_Time4 quest_stage7_time4 { get; set; }
    public Quest_Stage7_Time7 quest_stage7_time7 { get; set; }
    public Quest_Stage7_Time12 quest_stage7_time12 { get; set; }
    public Quest_Stage7_Time14 quest_stage7_time14 { get; set; }
    public Quest_Stage7_Time16 quest_stage7_time16 { get; set; }
    public Quest_Stage7_Fight1 quest_stage7_fight1 { get; set; }
    public Quest_Stage7_Fight2 quest_stage7_fight2 { get; set; }
    public Quest_Stage7_Fight6 quest_stage7_fight6 { get; set; }
    public Quest_Stage7_Fight9 quest_stage7_fight9 { get; set; }
    public First_Worldboss_Attack_Completed first_worldboss_attack_completed { get; set; }
    public Worldboss_Attacks_Completed worldboss_attacks_completed { get; set; }
    public First_Worldboss_Event_Won first_worldboss_event_won { get; set; }
    public Quest_Stage8_Time1 quest_stage8_time1 { get; set; }
    public Quest_Stage8_Time2 quest_stage8_time2 { get; set; }
    public Quest_Stage8_Fight3 quest_stage8_fight3 { get; set; }
    public Quest_Stage8_Time7 quest_stage8_time7 { get; set; }
    public Quest_Stage8_Fight5 quest_stage8_fight5 { get; set; }
    public Quest_Stage8_Time12 quest_stage8_time12 { get; set; }
    public Quest_Stage8_Fight8 quest_stage8_fight8 { get; set; }
    public Quest_Stage8_Time15 quest_stage8_time15 { get; set; }
    public Quest_Stage8_Time18 quest_stage8_time18 { get; set; }
    public Quest_Stage8_Time20 quest_stage8_time20 { get; set; }
    public Dungeon1_Unlocked dungeon1_unlocked { get; set; }
    public Dungeon1_Normal_Completed dungeon1_normal_completed { get; set; }
    public Dungeon1_Hard_Completed dungeon1_hard_completed { get; set; }
    public Dungeon2_Unlocked dungeon2_unlocked { get; set; }
    public Dungeon2_Normal_Completed dungeon2_normal_completed { get; set; }
    public Dungeon2_Hard_Completed dungeon2_hard_completed { get; set; }
    public Dungeon3_Unlocked dungeon3_unlocked { get; set; }
    public Dungeon3_Normal_Completed dungeon3_normal_completed { get; set; }
    public Dungeon3_Hard_Completed dungeon3_hard_completed { get; set; }
    public Dungeon4_Unlocked dungeon4_unlocked { get; set; }
    public Dungeon4_Normal_Completed dungeon4_normal_completed { get; set; }
    public Dungeon4_Hard_Completed dungeon4_hard_completed { get; set; }
    public Dungeon5_Unlocked dungeon5_unlocked { get; set; }
    public Dungeon5_Normal_Completed dungeon5_normal_completed { get; set; }
    public Dungeon5_Hard_Completed dungeon5_hard_completed { get; set; }
    public First_Item_Washed first_item_washed { get; set; }
    public Item_Washed item_washed { get; set; }
    public First_Item_Sewed first_item_sewed { get; set; }
    public Item_Sewed item_sewed { get; set; }
    public Quest_Stage9_Time1 quest_stage9_time1 { get; set; }
    public Quest_Stage9_Time4 quest_stage9_time4 { get; set; }
    public Quest_Stage9_Fight1 quest_stage9_fight1 { get; set; }
    public Quest_Stage9_Time7 quest_stage9_time7 { get; set; }
    public Quest_Stage9_Fight5 quest_stage9_fight5 { get; set; }
    public Quest_Stage9_Time10 quest_stage9_time10 { get; set; }
    public Quest_Stage9_Time14 quest_stage9_time14 { get; set; }
    public Quest_Stage9_Fight8 quest_stage9_fight8 { get; set; }
    public Quest_Stage9_Time16 quest_stage9_time16 { get; set; }
    public Quest_Stage9_Time18 quest_stage9_time18 { get; set; }
    public Quest_Stage10_Time2 quest_stage10_time2 { get; set; }
    public Quest_Stage10_Time4 quest_stage10_time4 { get; set; }
    public Quest_Stage10_Fight1 quest_stage10_fight1 { get; set; }
    public Quest_Stage10_Time8 quest_stage10_time8 { get; set; }
    public Quest_Stage10_Time9 quest_stage10_time9 { get; set; }
    public Quest_Stage10_Time16 quest_stage10_time16 { get; set; }
    public Quest_Stage10_Fight7 quest_stage10_fight7 { get; set; }
    public Quest_Stage10_Fight8 quest_stage10_fight8 { get; set; }
    public Quest_Stage10_Time20 quest_stage10_time20 { get; set; }
    public First_Guild_Dungeon_Fought first_guild_dungeon_fought { get; set; }
    public Guild_Dungeons_Fought guild_dungeons_fought { get; set; }
    public Guild_Dungeons_Won guild_dungeons_won { get; set; }
    public Tournament_Attended tournament_attended { get; set; }
    public Tournament_Top10_Reached tournament_top10_reached { get; set; }
    public Tournament_Top3_Reached tournament_top3_reached { get; set; }
    public Quest_Stage11_Time2 quest_stage11_time2 { get; set; }
    public Quest_Stage11_Time6 quest_stage11_time6 { get; set; }
    public Quest_Stage11_Fight4 quest_stage11_fight4 { get; set; }
    public Quest_Stage11_Time8 quest_stage11_time8 { get; set; }
    public Quest_Stage11_Fight7 quest_stage11_fight7 { get; set; }
    public Quest_Stage11_Time12 quest_stage11_time12 { get; set; }
    public Quest_Stage11_Time16 quest_stage11_time16 { get; set; }
    public Quest_Stage11_Time14 quest_stage11_time14 { get; set; }
    public Quest_Stage11_Time18 quest_stage11_time18 { get; set; }
    public Quest_Stage11_Time21 quest_stage11_time21 { get; set; }
    public Quest_Refresh quest_refresh { get; set; }
    public Quest_Refreshed quest_refreshed { get; set; }
    public Quest_Refreshed_A_Day quest_refreshed_a_day { get; set; }
    public Booster_Sense_Use booster_sense_use { get; set; }
    public Booster_Sense_Used booster_sense_used { get; set; }
    public Booster_Sense_Used_A_Day booster_sense_used_a_day { get; set; }
    public First_Sidekick_Collected first_sidekick_collected { get; set; }
    public Sidekick_Collected sidekick_collected { get; set; }
    public First_Sidekick_Maxed first_sidekick_maxed { get; set; }
    public Sidekick_Maxed sidekick_maxed { get; set; }
    public Dungeon6_Unlocked dungeon6_unlocked { get; set; }
    public Dungeon6_Normal_Completed dungeon6_normal_completed { get; set; }
    public Dungeon6_Hard_Completed dungeon6_hard_completed { get; set; }
    public First_Surprise_Box_Opened first_surprise_box_opened { get; set; }
    public Surprise_Box_Opened surprise_box_opened { get; set; }
    public Dungeon7_Unlocked dungeon7_unlocked { get; set; }
    public Dungeon7_Normal_Completed dungeon7_normal_completed { get; set; }
    public Dungeon7_Hard_Completed dungeon7_hard_completed { get; set; }
    public First_Sidekick_Merged first_sidekick_merged { get; set; }
    public Sidekick_Merged sidekick_merged { get; set; }
    public Quest_Stage12_Time3 quest_stage12_time3 { get; set; }
    public Quest_Stage12_Time5 quest_stage12_time5 { get; set; }
    public Quest_Stage12_Time6 quest_stage12_time6 { get; set; }
    public Quest_Stage12_Time9 quest_stage12_time9 { get; set; }
    public Quest_Stage12_Fight7 quest_stage12_fight7 { get; set; }
    public Quest_Stage12_Time12 quest_stage12_time12 { get; set; }
    public Quest_Stage12_Time14 quest_stage12_time14 { get; set; }
    public Quest_Stage12_Fight8 quest_stage12_fight8 { get; set; }
    public Quest_Stage12_Fight9 quest_stage12_fight9 { get; set; }
    public Quest_Stage12_Time17 quest_stage12_time17 { get; set; }
    public Dungeon8_Unlocked dungeon8_unlocked { get; set; }
    public Dungeon8_Normal_Completed dungeon8_normal_completed { get; set; }
    public Dungeon8_Hard_Completed dungeon8_hard_completed { get; set; }
    public League_Points_Reached league_points_reached { get; set; }
    public League_Fights_Won league_fights_won { get; set; }
    public League_Fights_Won_In_Row league_fights_won_in_row { get; set; }
    public First_League_Fight_Completed first_league_fight_completed { get; set; }
    public League_Fights_Completed league_fights_completed { get; set; }
    public League_Fights_Started_A_Day league_fights_started_a_day { get; set; }
    public Quest_Stage13_Time2 quest_stage13_time2 { get; set; }
    public Quest_Stage13_Time6 quest_stage13_time6 { get; set; }
    public Quest_Stage13_Time14 quest_stage13_time14 { get; set; }
    public Quest_Stage13_Fight2 quest_stage13_fight2 { get; set; }
    public Quest_Stage13_Fight4 quest_stage13_fight4 { get; set; }
    public Quest_Stage13_Fight6 quest_stage13_fight6 { get; set; }
    public Quest_Stage13_Fight7 quest_stage13_fight7 { get; set; }
    public Herobook_First_Objetive_Finished herobook_first_objetive_finished { get; set; }
    public Herobook_Objectives_Finished herobook_objectives_finished { get; set; }
    public Different_Sidekick_Collected different_sidekick_collected { get; set; }
    public Dungeon9_Unlocked dungeon9_unlocked { get; set; }
    public Dungeon9_Normal_Completed dungeon9_normal_completed { get; set; }
    public Dungeon9_Hard_Completed dungeon9_hard_completed { get; set; }
    public First_Quest_Resource_Request_Accepted first_quest_resource_request_accepted { get; set; }
    public Quest_Resource_Request_Accepted quest_resource_request_accepted { get; set; }
    public Hideout_Glue_Collected hideout_glue_collected { get; set; }
    public Hideout_Stone_Collected hideout_stone_collected { get; set; }
    public Hideout_Room_Upgraded hideout_room_upgraded { get; set; }
    public Hideout_Unlock_Room_Slot hideout_unlock_room_slot { get; set; }
    public Hideout_Hideout_Points_Reached hideout_hideout_points_reached { get; set; }
    public Hideout_Units_Produced hideout_units_produced { get; set; }
    public Hideout_Build_Generator hideout_build_generator { get; set; }
    public Quest_Stage14_Time1 quest_stage14_time1 { get; set; }
    public Quest_Stage14_Time4 quest_stage14_time4 { get; set; }
    public Quest_Stage14_Time7 quest_stage14_time7 { get; set; }
    public Quest_Stage14_Time10 quest_stage14_time10 { get; set; }
    public Quest_Stage14_Time12 quest_stage14_time12 { get; set; }
    public Quest_Stage14_Fight3 quest_stage14_fight3 { get; set; }
    public Quest_Stage14_Fight5 quest_stage14_fight5 { get; set; }
    public Quest_Stage14_Fight6 quest_stage14_fight6 { get; set; }
    public Quest_Stage14_Fight10 quest_stage14_fight10 { get; set; }
    public Quest_Stage14_Fight11 quest_stage14_fight11 { get; set; }
    public Hideout_First_Improvement_Collected hideout_first_improvement_collected { get; set; }
    public Hideout_Improvement_Collected hideout_improvement_collected { get; set; }
    public Hideout_Build_Gem_Production hideout_build_gem_production { get; set; }
    public Hideout_Visited hideout_visited { get; set; }
    public Hideout_Build_Broker hideout_build_broker { get; set; }
    public Hideout_Room_Broker_Upgraded hideout_room_broker_upgraded { get; set; }
    public Hideout_Build_Robot_Storage hideout_build_robot_storage { get; set; }
    public Hideout_Room_Robot_Storage_Upgraded hideout_room_robot_storage_upgraded { get; set; }
    public Guild_Competition_Visit guild_competition_visit { get; set; }
    public Guild_Competition_Top_100 guild_competition_top_100 { get; set; }
    public Guild_Competition_First_Place guild_competition_first_place { get; set; }
    public Guild_Competition_Score_3000 guild_competition_score_3000 { get; set; }
    public League_First_Place league_first_place { get; set; }
    public League_Top_3 league_top_3 { get; set; }
    public League_Top_100 league_top_100 { get; set; }
    public Hideout_Exchange_Collected hideout_exchange_collected { get; set; }
}

public class Level_Reached
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Stage_Reached
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Second_Quests_Completed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quests_Completed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Second_Duel_Completed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Duels_Completed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Second_Day_Logged_In
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Days_Logged_In
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Shop_Refresh
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Shop_Refreshed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Time_Worked
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class First_Training_Absolved
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Trainings_Absolved
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Honor_Reached
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class All_Stats_Value_Reached
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Duels_Won
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Duels_Won_In_Row
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Duels_Lost
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Fight_Quests_Won_Hard
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Player_Profile_Visit
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Leaderboard_Visit
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Stat_Point_Bought
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Rare_Item_Bought
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Epic_Item_Bought
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Mission_Booster_Bought
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Stats_Booster_Bought
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Work_Booster_Bought
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Character_Full_Equipped
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Energy_Bought
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Item_Sold
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Tutorial_Completed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Coins_Spent_A_Day
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage1_Fight1
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage1_Fight2
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage1_Fight3
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage1_Fight7
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage1_Fight8
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage1_Time5
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage2_Fight5
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage2_Fight6
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage2_Fight7
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage2_Fight8
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage2_Fight10
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage2_Time16
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage3_Fight4
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage3_Fight5
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage3_Fight6
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage3_Fight7
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage3_Fight8
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage3_Time12
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage4_Fight3
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage4_Fight7
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage4_Time8
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage4_Time15
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage4_Time16
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage5_Fight1
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage5_Fight2
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage5_Fight5
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage5_Time11
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage5_Time15
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage6_Fight5
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage6_Fight7
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage6_Fight8
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage6_Time4
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage6_Time5
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage6_Time7
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage6_Time14
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage6_Time15
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage6_Time19
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Duels_Started_A_Day
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Shop_Refreshed_A_Day
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Missles_Fired
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Donuts_Spent
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Guild_Joined
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Guild_Donated
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Guild_Visited
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Account_Confirmed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class First_Guild_Battle_Fought
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Guild_Battles_Fought
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Guild_Battles_Won
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Guild_Battles_Lost
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class First_Guild_Artifact_Won
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Guild_Artifacts_Won
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage7_Time2
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage7_Time4
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage7_Time7
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage7_Time12
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage7_Time14
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage7_Time16
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage7_Fight1
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage7_Fight2
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage7_Fight6
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage7_Fight9
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class First_Worldboss_Attack_Completed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Worldboss_Attacks_Completed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class First_Worldboss_Event_Won
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage8_Time1
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage8_Time2
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage8_Fight3
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage8_Time7
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage8_Fight5
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage8_Time12
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage8_Fight8
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage8_Time15
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage8_Time18
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage8_Time20
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Dungeon1_Unlocked
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Dungeon1_Normal_Completed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Dungeon1_Hard_Completed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Dungeon2_Unlocked
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Dungeon2_Normal_Completed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Dungeon2_Hard_Completed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Dungeon3_Unlocked
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Dungeon3_Normal_Completed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Dungeon3_Hard_Completed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Dungeon4_Unlocked
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Dungeon4_Normal_Completed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Dungeon4_Hard_Completed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Dungeon5_Unlocked
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Dungeon5_Normal_Completed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Dungeon5_Hard_Completed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class First_Item_Washed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Item_Washed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class First_Item_Sewed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Item_Sewed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage9_Time1
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage9_Time4
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage9_Fight1
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage9_Time7
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage9_Fight5
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage9_Time10
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage9_Time14
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage9_Fight8
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage9_Time16
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage9_Time18
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage10_Time2
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage10_Time4
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage10_Fight1
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage10_Time8
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage10_Time9
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage10_Time16
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage10_Fight7
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage10_Fight8
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage10_Time20
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class First_Guild_Dungeon_Fought
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Guild_Dungeons_Fought
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Guild_Dungeons_Won
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Tournament_Attended
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Tournament_Top10_Reached
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Tournament_Top3_Reached
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage11_Time2
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage11_Time6
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage11_Fight4
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage11_Time8
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage11_Fight7
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage11_Time12
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage11_Time16
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage11_Time14
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage11_Time18
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage11_Time21
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Refresh
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Refreshed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Refreshed_A_Day
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Booster_Sense_Use
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Booster_Sense_Used
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Booster_Sense_Used_A_Day
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class First_Sidekick_Collected
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Sidekick_Collected
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class First_Sidekick_Maxed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Sidekick_Maxed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Dungeon6_Unlocked
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Dungeon6_Normal_Completed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Dungeon6_Hard_Completed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class First_Surprise_Box_Opened
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Surprise_Box_Opened
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Dungeon7_Unlocked
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Dungeon7_Normal_Completed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Dungeon7_Hard_Completed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class First_Sidekick_Merged
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Sidekick_Merged
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage12_Time3
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage12_Time5
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage12_Time6
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage12_Time9
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage12_Fight7
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage12_Time12
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage12_Time14
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage12_Fight8
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage12_Fight9
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage12_Time17
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Dungeon8_Unlocked
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Dungeon8_Normal_Completed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Dungeon8_Hard_Completed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class League_Points_Reached
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class League_Fights_Won
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class League_Fights_Won_In_Row
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class First_League_Fight_Completed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class League_Fights_Completed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class League_Fights_Started_A_Day
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage13_Time2
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage13_Time6
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage13_Time14
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage13_Fight2
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage13_Fight4
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage13_Fight6
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage13_Fight7
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Herobook_First_Objetive_Finished
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Herobook_Objectives_Finished
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Different_Sidekick_Collected
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Dungeon9_Unlocked
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Dungeon9_Normal_Completed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Dungeon9_Hard_Completed
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class First_Quest_Resource_Request_Accepted
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Resource_Request_Accepted
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Hideout_Glue_Collected
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Hideout_Stone_Collected
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Hideout_Room_Upgraded
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Hideout_Unlock_Room_Slot
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Hideout_Hideout_Points_Reached
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Hideout_Units_Produced
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Hideout_Build_Generator
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage14_Time1
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage14_Time4
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage14_Time7
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage14_Time10
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage14_Time12
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage14_Fight3
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage14_Fight5
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage14_Fight6
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage14_Fight10
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Quest_Stage14_Fight11
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Hideout_First_Improvement_Collected
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Hideout_Improvement_Collected
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Hideout_Build_Gem_Production
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Hideout_Visited
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Hideout_Build_Broker
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Hideout_Room_Broker_Upgraded
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Hideout_Build_Robot_Storage
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Hideout_Room_Robot_Storage_Upgraded
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Guild_Competition_Visit
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Guild_Competition_Top_100
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Guild_Competition_First_Place
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Guild_Competition_Score_3000
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class League_First_Place
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class League_Top_3
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class League_Top_100
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Hideout_Exchange_Collected
{
    public int value { get; set; }
    public int current_value { get; set; }
}

public class Current_Item_Pattern_Values
{
    public Biker biker { get; set; }
    public Costume costume { get; set; }
    public Disco disco { get; set; }
    public Doctor doctor { get; set; }
    public Movie movie { get; set; }
    public Robinhood robinhood { get; set; }
    public Superherozero superherozero { get; set; }
    public Superheroset1 superheroset1 { get; set; }
    public Superheroset2 superheroset2 { get; set; }
    public Superheroset3 superheroset3 { get; set; }
    public Olympia_2016_Rio olympia_2016_rio { get; set; }
    public Asian asian { get; set; }
    public Frogman1 frogman1 { get; set; }
    public Ironman1 ironman1 { get; set; }
    public Movienew movienew { get; set; }
    public Musketeer musketeer { get; set; }
    public Overall overall { get; set; }
    public Powerset1 powerset1 { get; set; }
    public Powerset2 powerset2 { get; set; }
    public Safari safari { get; set; }
    public Nano nano { get; set; }
    public Pirates pirates { get; set; }
    public Wrestling wrestling { get; set; }
    public Octoberfest octoberfest { get; set; }
    public Halloween halloween { get; set; }
    public Superhero superhero { get; set; }
    public Work work { get; set; }
    public League_Custom1 league_custom1 { get; set; }
    public League_Custom2 league_custom2 { get; set; }
    public Xmas xmas { get; set; }
    public Carnival carnival { get; set; }
    public St_Patricks_Day st_patricks_day { get; set; }
    public Easter easter { get; set; }
    public Egypt egypt { get; set; }
    public League_Bronze league_bronze { get; set; }
    public League_Champion league_champion { get; set; }
    public League_Gold league_gold { get; set; }
    public League_Silver league_silver { get; set; }
    public Archer archer { get; set; }
    public Sysadmin sysadmin { get; set; }
    public Summer_Event summer_event { get; set; }
    public Powerset3 powerset3 { get; set; }
    public Powerset4 powerset4 { get; set; }
    public League_Superhero league_superhero { get; set; }
    public Improvised improvised { get; set; }
    public Casual casual { get; set; }
    public Tech tech { get; set; }
}

public class Biker
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Costume
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Disco
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Doctor
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Movie
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Robinhood
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Superherozero
{
    public int value { get; set; }
    public string[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Superheroset1
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Superheroset2
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Superheroset3
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Olympia_2016_Rio
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Asian
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Frogman1
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Ironman1
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Movienew
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Musketeer
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Overall
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Powerset1
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Powerset2
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Safari
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Nano
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Pirates
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Wrestling
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Octoberfest
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Halloween
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Superhero
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Work
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class League_Custom1
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class League_Custom2
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Xmas
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Carnival
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class St_Patricks_Day
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Easter
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Egypt
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class League_Bronze
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class League_Champion
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class League_Gold
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class League_Silver
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Archer
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Sysadmin
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Summer_Event
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Powerset3
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Powerset4
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class League_Superhero
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Improvised
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Casual
{
    public int value { get; set; }
    public string[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Tech
{
    public int value { get; set; }
    public object[] collected_items { get; set; }
    public bool is_new { get; set; }
}

public class Current_Optical_Changes
{
    public int id { get; set; }
    public int character_id { get; set; }
    public int resource { get; set; }
    public int ts_last_free_chest { get; set; }
    public string available_chests { get; set; }
    public string active_options { get; set; }
    public string unlocked_options { get; set; }
    public bool use_for_character { get; set; }
    public bool use_for_quest { get; set; }
    public bool use_for_duel { get; set; }
    public bool use_for_league { get; set; }
}

public class Streams_Info
{
    public M m { get; set; }
    public R r { get; set; }
    public V v { get; set; }
    public S s { get; set; }
}

public class M
{
    public _25814 _25814 { get; set; }
}

public class _25814
{
    public int id { get; set; }
    public string type { get; set; }
    public int unread { get; set; }
}

public class R
{
    public _26570 _26570 { get; set; }
}

public class _26570
{
    public int id { get; set; }
    public string type { get; set; }
    public int unread { get; set; }
}

public class V
{
    public _258141 _25814 { get; set; }
    public _265701 _26570 { get; set; }
}

public class _258141
{
    public int id { get; set; }
    public string type { get; set; }
    public int unread { get; set; }
}

public class _265701
{
    public int id { get; set; }
    public string type { get; set; }
    public int unread { get; set; }
}

public class S
{
    public _258142 _25814 { get; set; }
}

public class _258142
{
    public int id { get; set; }
    public string type { get; set; }
    public int unread { get; set; }
}

public class Local_Notification_Settings
{
    public Mission_Finished mission_finished { get; set; }
    public Training_Finished training_finished { get; set; }
    public Work_Finished work_finished { get; set; }
    public Free_Duel_Available free_duel_available { get; set; }
    public Worldboss_Attack_Finished worldboss_attack_finished { get; set; }
    public Hideout_Room_Build hideout_room_build { get; set; }
    public Hideout_Room_Stored hideout_room_stored { get; set; }
    public Hideout_Room_Placed hideout_room_placed { get; set; }
    public Hideout_Room_Upgraded1 hideout_room_upgraded { get; set; }
    public Hideout_Room_Slot_Unlocked hideout_room_slot_unlocked { get; set; }
    public Hideout_Attacker_Production_Finished hideout_attacker_production_finished { get; set; }
    public Hideout_Defender_Production_Finished hideout_defender_production_finished { get; set; }
    public Hideout_Improvement_Production_Finished hideout_improvement_production_finished { get; set; }
}

public class Mission_Finished
{
    public int id { get; set; }
    public bool active { get; set; }
    public bool vibrate { get; set; }
    public string title { get; set; }
    public string body { get; set; }
}

public class Training_Finished
{
    public int id { get; set; }
    public bool active { get; set; }
    public bool vibrate { get; set; }
    public string title { get; set; }
    public string body { get; set; }
}

public class Work_Finished
{
    public int id { get; set; }
    public bool active { get; set; }
    public bool vibrate { get; set; }
    public string title { get; set; }
    public string body { get; set; }
}

public class Free_Duel_Available
{
    public int id { get; set; }
    public bool active { get; set; }
    public bool vibrate { get; set; }
    public string title { get; set; }
    public string body { get; set; }
}

public class Worldboss_Attack_Finished
{
    public int id { get; set; }
    public bool active { get; set; }
    public bool vibrate { get; set; }
    public string title { get; set; }
    public string body { get; set; }
}

public class Hideout_Room_Build
{
    public int id { get; set; }
    public bool active { get; set; }
    public bool vibrate { get; set; }
    public string title { get; set; }
    public string body { get; set; }
}

public class Hideout_Room_Stored
{
    public int id { get; set; }
    public bool active { get; set; }
    public bool vibrate { get; set; }
    public string title { get; set; }
    public string body { get; set; }
}

public class Hideout_Room_Placed
{
    public int id { get; set; }
    public bool active { get; set; }
    public bool vibrate { get; set; }
    public string title { get; set; }
    public string body { get; set; }
}

public class Hideout_Room_Upgraded1
{
    public int id { get; set; }
    public bool active { get; set; }
    public bool vibrate { get; set; }
    public string title { get; set; }
    public string body { get; set; }
}

public class Hideout_Room_Slot_Unlocked
{
    public int id { get; set; }
    public bool active { get; set; }
    public bool vibrate { get; set; }
    public string title { get; set; }
    public string body { get; set; }
}

public class Hideout_Attacker_Production_Finished
{
    public int id { get; set; }
    public bool active { get; set; }
    public bool vibrate { get; set; }
    public string title { get; set; }
    public string body { get; set; }
}

public class Hideout_Defender_Production_Finished
{
    public int id { get; set; }
    public bool active { get; set; }
    public bool vibrate { get; set; }
    public string title { get; set; }
    public string body { get; set; }
}

public class Hideout_Improvement_Production_Finished
{
    public int id { get; set; }
    public bool active { get; set; }
    public bool vibrate { get; set; }
    public string title { get; set; }
    public string body { get; set; }
}

public class Collected_Goals
{
    public Tutorial_Completed1 tutorial_completed { get; set; }
    public Second_Day_Logged_In1 second_day_logged_in { get; set; }
    public Second_Quests_Completed1 second_quests_completed { get; set; }
    public Level_Reached1 level_reached { get; set; }
    public Days_Logged_In1 days_logged_in { get; set; }
    public Booster_Sense_Use1 booster_sense_use { get; set; }
}

public class Tutorial_Completed1
{
    public int value { get; set; }
    public string date { get; set; }
}

public class Second_Day_Logged_In1
{
    public int value { get; set; }
    public string date { get; set; }
}

public class Second_Quests_Completed1
{
    public int value { get; set; }
    public string date { get; set; }
}

public class Level_Reached1
{
    public int value { get; set; }
    public string date { get; set; }
}

public class Days_Logged_In1
{
    public int value { get; set; }
    public string date { get; set; }
}

public class Booster_Sense_Use1
{
    public int value { get; set; }
    public string date { get; set; }
}
