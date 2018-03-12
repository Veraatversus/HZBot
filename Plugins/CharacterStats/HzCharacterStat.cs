using System.Linq;

namespace HZBot
{
    public class HzCharacterStat
    {
        #region Properties

        public Character Character { get; set; }
        public StatType StatType { get; set; }
        public int BaseValue { get; set; }
        public int BoughtValue { get; set; }
        public int TotalValue { get; set; }
        public int TrainingValue { get; set; }
        public int TrainingMaxValue { get; set; }
        public double ShouldValue => (Character.HzStats.AllStats.Where(stat => stat.SkillWeight > 0).Sum(stat => stat.BaseValue + stat.BoughtValue) / Character.HzStats.AllStats.Sum(stat => stat.SkillWeight)) * SkillWeight;
        public double StatDiffToShouldValue => ShouldValue -  (BaseValue + BoughtValue); 

        public double EquipWeight
        {
            get
            {
                switch (StatType)
                {
                    case StatType.Stamina:
                        return HzAccountManger.GetAccountByCharacterID(Character.id).Config.StaminaEquipWeight;

                    case StatType.Strength:
                        return HzAccountManger.GetAccountByCharacterID(Character.id).Config.StrengthEquipWeight;

                    case StatType.CriticalRating:
                        return HzAccountManger.GetAccountByCharacterID(Character.id).Config.CriticalRatingEquipWeight;

                    case StatType.DodgeRating:
                        return HzAccountManger.GetAccountByCharacterID(Character.id).Config.DodgeRatingEquipWeight;

                    case StatType.WeaponDamage:
                        return HzAccountManger.GetAccountByCharacterID(Character.id).Config.WeaponDamageEquipWeight;

                    case StatType.MissileDamage:
                        return HzAccountManger.GetAccountByCharacterID(Character.id).Config.MissileDamageEquipWeight;

                    default:
                        return 0;
                }
            }
        }

        public double SkillWeight
        {
            get
            {
                switch (StatType)
                {
                    case StatType.Stamina:
                        return HzAccountManger.GetAccountByCharacterID(Character.id).Config.StaminaSkillWeight;

                    case StatType.Strength:
                        return HzAccountManger.GetAccountByCharacterID(Character.id).Config.StrengthSkillWeight;

                    case StatType.CriticalRating:
                        return HzAccountManger.GetAccountByCharacterID(Character.id).Config.CriticalRatingSkillWeight;

                    case StatType.DodgeRating:
                        return HzAccountManger.GetAccountByCharacterID(Character.id).Config.DodgeRatingSkillWeight;

                    default:
                        return 0;
                }
            }
        }

        #endregion Properties
    }
}