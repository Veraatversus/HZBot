using System.Collections.Generic;
using System.Linq;

namespace HZBot
{
    public class HzCharacterStats

    {
        #region Constructors

        public HzCharacterStats(Character character)
        {
            this.character = character;
        }

        #endregion Constructors

        #region Properties

        public HzCharacterStat Stamina => new HzCharacterStat() { Character = character, StatType = StatType.Stamina, BaseValue = character.stat_base_stamina, BoughtValue = character.stat_bought_stamina, TotalValue = character.stat_total_stamina, TrainingValue = character.training_progress_value_stamina, TrainingMaxValue = character.training_progress_end_stamina };
        public HzCharacterStat Strength => new HzCharacterStat() { Character = character, StatType = StatType.Strength, BaseValue = character.stat_base_strength, BoughtValue = character.stat_bought_strength, TotalValue = character.stat_total_strength, TrainingValue = character.training_progress_value_strength, TrainingMaxValue = character.training_progress_end_strength };
        public HzCharacterStat CriticalRating => new HzCharacterStat() { Character = character, StatType = StatType.CriticalRating, BaseValue = character.stat_base_critical_rating, BoughtValue = character.stat_bought_critical_rating, TotalValue = character.stat_total_critical_rating, TrainingValue = character.training_progress_value_critical_rating, TrainingMaxValue = character.training_progress_end_critical_rating };
        public HzCharacterStat DodgeRating => new HzCharacterStat() { Character = character, StatType = StatType.DodgeRating, BaseValue = character.stat_base_dodge_rating, BoughtValue = character.stat_bought_dodge_rating, TotalValue = character.stat_total_dodge_rating, TrainingValue = character.training_progress_value_dodge_rating, TrainingMaxValue = character.training_progress_end_dodge_rating };
        public HzCharacterStat WeaponDamage => new HzCharacterStat() { Character = character, StatType = StatType.WeaponDamage, BaseValue = 0, TotalValue = character.stat_weapon_damage };
        public IEnumerable<HzCharacterStat> TrainStats => trainStats();
        public IEnumerable<HzCharacterStat> AllStats => allStats();
        public int StatsTotal => AllStats.Sum(stat => stat.TotalValue);

        #endregion Properties

        #region Methods

        /// <summary>Gets the next Character Stat to Improve.</summary>
        /// <returns></returns>
        public HzCharacterStat GetNextImroveStat()
        {
            return TrainStats.OrderByDescending(stat => stat.StatDiffToShouldValue).FirstOrDefault();
        }

        /// <summary>Determines whether this instance [can improve character stat] the specified stat.</summary>
        /// <param name="stat">The stat.</param>
        /// <returns><c>true</c> if this instance [can improve character stat] the specified stat; otherwise, <c>false</c>.</returns>
        public bool CanImproveCharacterStat(HzCharacterStat stat)
        {
            if (stat.StatType != StatType.Unknown && stat.StatType <= StatType.DodgeRating)
            {
                return character.stat_points_available > 0;
            }
            return false;
        }

        /// <summary>Determines whether this instance can train the specified stat.</summary>
        /// <param name="stat">The stat.</param>
        /// <returns><c>true</c> if this instance can train the specified stat; otherwise, <c>false</c>.</returns>
        public bool CanTrain(HzCharacterStat stat)
        {
            if (stat.StatType != StatType.Unknown && stat.StatType <= StatType.DodgeRating)
            {
                return character.training_count > 0;
            }
            return false;
        }

        #endregion Methods

        #region Fields

        private readonly Character character;

        #endregion Fields

        private IEnumerable<HzCharacterStat> trainStats()
        {
            yield return Stamina;
            yield return Strength;
            yield return CriticalRating;
            yield return DodgeRating;
        }

        private IEnumerable<HzCharacterStat> allStats()
        {
            return TrainStats.Concat(new[] { WeaponDamage });
        }
    }
}