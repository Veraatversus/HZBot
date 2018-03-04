﻿using System.Collections.Generic;
using System.Linq;

namespace HZBot
{
    public class Character
    {
        #region Properties

        public int id { get; set; }
        public int user_id { get; set; }
        public string name { get; set; }
        public string locale { get; set; }
        public string gender { get; set; }
        public int game_currency { get; set; }
        public int xp { get; set; }
        public int level { get; set; }
        public string description { get; set; }
        public string note { get; set; }
        public int ts_last_action { get; set; }
        public int online_status { get; set; }
        public int score_honor { get; set; }
        public int score_level { get; set; }
        public int stat_points_available { get; set; }
        public int stat_base_stamina { get; set; }
        public int stat_base_strength { get; set; }
        public int stat_base_critical_rating { get; set; }
        public int stat_base_dodge_rating { get; set; }
        public int stat_total_stamina { get; set; }
        public int stat_total_strength { get; set; }
        public int stat_total_critical_rating { get; set; }
        public int stat_total_dodge_rating { get; set; }
        public int FightStat => stat_total - stat_weapon_damage;
        public int stat_weapon_damage { get; set; }
        public int stat_total { get; set; }
        public int stat_bought_stamina { get; set; }
        public int stat_bought_strength { get; set; }
        public int stat_bought_critical_rating { get; set; }
        public int stat_bought_dodge_rating { get; set; }
        public string active_quest_booster_id { get; set; }
        public int ts_active_quest_boost_expires { get; set; }
        public string active_stats_booster_id { get; set; }
        public int ts_active_stats_boost_expires { get; set; }
        public string active_work_booster_id { get; set; }
        public int ts_active_work_boost_expires { get; set; }
        public int ts_active_sense_boost_expires { get; set; }
        public string active_league_booster_id { get; set; }
        public int ts_active_league_boost_expires { get; set; }
        public int ts_active_multitasking_boost_expires { get; set; }
        public int max_quest_stage { get; set; }
        public int current_quest_stage { get; set; }
        public int quest_energy { get; set; }
        public int max_quest_energy { get; set; }
        public int ts_last_quest_energy_refill { get; set; }
        public int quest_energy_refill_amount_today { get; set; }
        public int quest_reward_training_sessions_rewarded_today { get; set; }
        public int active_quest_id { get; set; }
        public string quest_pool { get; set; }
        public int honor { get; set; }
        public int ts_last_duel { get; set; }
        public int active_duel_id { get; set; }
        public int duel_stamina { get; set; }
        public int max_duel_stamina { get; set; }
        public int ts_last_duel_stamina_change { get; set; }
        public int duel_stamina_cost { get; set; }
        public int ts_last_duel_enemies_refresh { get; set; }
        public string current_work_offer_id { get; set; }
        public int active_work_id { get; set; }
        public int active_training_id { get; set; }
        public int stat_trained_stamina { get; set; }
        public int stat_trained_strength { get; set; }
        public int stat_trained_critical_rating { get; set; }
        public int stat_trained_dodge_rating { get; set; }
        public int training_progress_value_stamina { get; set; }
        public int training_progress_value_strength { get; set; }
        public int training_progress_value_critical_rating { get; set; }
        public int training_progress_value_dodge_rating { get; set; }
        public int training_progress_end_stamina { get; set; }
        public int training_progress_end_strength { get; set; }
        public int training_progress_end_critical_rating { get; set; }
        public int training_progress_end_dodge_rating { get; set; }
        public int ts_last_training { get; set; }
        public int training_count { get; set; }
        public int max_training_count { get; set; }
        public int active_worldboss_attack_id { get; set; }
        public int active_dungeon_quest_id { get; set; }
        public int ts_last_dungeon_quest_fail { get; set; }
        public int max_dungeon_index { get; set; }
        public int appearance_skin_color { get; set; }
        public int appearance_hair_color { get; set; }
        public int appearance_hair_type { get; set; }
        public int appearance_head_type { get; set; }
        public int appearance_eyes_type { get; set; }
        public int appearance_eyebrows_type { get; set; }
        public int appearance_nose_type { get; set; }
        public int appearance_mouth_type { get; set; }
        public int appearance_facial_hair_type { get; set; }
        public int appearance_decoration_type { get; set; }
        public bool show_mask { get; set; }
        public string tutorial_flags { get; set; }
        public int guild_id { get; set; }
        public int guild_rank { get; set; }
        public int finished_guild_battle_attack_id { get; set; }
        public int finished_guild_battle_defense_id { get; set; }
        public int finished_guild_dungeon_battle_id { get; set; }
        public int guild_donated_game_currency { get; set; }
        public int guild_donated_premium_currency { get; set; }
        public int guild_competition_points_gathered { get; set; }
        public int pending_guild_competition_tournament_rewards { get; set; }
        public bool new_guild_competition_tournament { get; set; }
        public int unread_mass_system_messages { get; set; }
        public int worldboss_event_id { get; set; }
        public int worldboss_event_attack_count { get; set; }
        public int ts_last_wash_item { get; set; }
        public int ts_last_daily_login_bonus { get; set; }
        public int daily_login_bonus_day { get; set; }
        public int pending_tournament_rewards { get; set; }
        public int ts_last_shop_refresh { get; set; }
        public int max_free_shop_refreshes { get; set; }
        public int shop_refreshes { get; set; }
        public int event_quest_id { get; set; }
        public string friend_data { get; set; }
        public string unused_resources { get; set; }
        public string used_resources { get; set; }
        public int league_points { get; set; }
        public int league_group_id { get; set; }
        public int active_league_fight_id { get; set; }
        public int ts_last_league_fight { get; set; }
        public int league_fight_count { get; set; }
        public string league_opponents { get; set; }
        public int ts_last_league_opponents_refresh { get; set; }
        public int league_stamina { get; set; }
        public int max_league_stamina { get; set; }
        public int ts_last_league_stamina_change { get; set; }
        public int league_stamina_cost { get; set; }
        public int pending_league_tournament_rewards { get; set; }
        public int herobook_objectives_renewed_today { get; set; }
        public int current_slotmachine_spin { get; set; }
        public int slotmachine_spin_count { get; set; }
        public int ts_last_slotmachine_refill { get; set; }
        public string new_user_voucher_ids { get; set; }
        public int current_energy_storage { get; set; }
        public int current_training_storage { get; set; }
        public CharacterStat Stamina => new CharacterStat() { StatType = StatType.Stamina, Gewichtung = .2f, BaseValue = stat_base_stamina, BoughtValue = stat_bought_stamina, TotalValue = stat_total_stamina, TrainingValue = training_progress_value_stamina, TrainingMaxValue = training_progress_end_stamina };
        public CharacterStat Strength => new CharacterStat() { StatType = StatType.Strength, Gewichtung = .5f, BaseValue = stat_base_strength, BoughtValue = stat_bought_strength, TotalValue = stat_total_strength, TrainingValue = training_progress_value_strength, TrainingMaxValue = training_progress_end_strength };
        public CharacterStat CriticalRating => new CharacterStat() { StatType = StatType.CriticalRating, Gewichtung = 1, BaseValue = stat_base_critical_rating, BoughtValue = stat_bought_critical_rating, TotalValue = stat_total_critical_rating, TrainingValue = training_progress_value_critical_rating, TrainingMaxValue = training_progress_end_critical_rating };
        public CharacterStat DodgeRating => new CharacterStat() { StatType = StatType.DodgeRating, Gewichtung = 1, BaseValue = stat_base_dodge_rating, BoughtValue = stat_bought_dodge_rating, TotalValue = stat_total_dodge_rating, TrainingValue = training_progress_value_dodge_rating, TrainingMaxValue = training_progress_end_dodge_rating };
        public List<CharacterStat> Stats => new List<CharacterStat>() { Stamina, Strength, CriticalRating, DodgeRating };
        public int CurrentGameCurrencyCostEnergyRefill => HzConstants.Default.GameCurrencyCostEnergyRefill(level, quest_energy_refill_amount_today);

        #endregion Properties

        #region Methods

        /// <summary>Gets the next Character Stat to Improve.</summary>
        /// <returns></returns>
        public CharacterStat GetNextImroveStat()
        {
            return Stats.OrderBy(stat => stat.BaseValue).FirstOrDefault();
        }

        /// <summary>Determines whether this Character [can improve character stat].</summary>
        /// <returns>
        ///   <c>true</c> if this instance [can improve character stat]; otherwise, <c>false</c>.</returns>
        public bool CanImproveCharacterStat()
        {
            return stat_points_available > 0;
        }

        /// <summary>Determines whether this Character can train.</summary>
        /// <returns>
        ///   <c>true</c> if this instance can train; otherwise, <c>false</c>.</returns>
        public bool CanTrain()
        {
            return training_count > 0;
        }

        #endregion Methods
    }
}