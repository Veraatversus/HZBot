using System.Linq;

namespace HZBot
{
    public class Item
    {
        #region Properties

        public int id { get; set; }
        public int character_id { get; set; }
        public string identifier { get; set; }
        public ItemType type { get; set; }
        public int quality { get; set; }
        public int required_level { get; set; }
        public int charges { get; set; }
        public int item_level { get; set; }
        public int ts_availability_start { get; set; }
        public int ts_availability_end { get; set; }
        public bool premium_item { get; set; }
        public int buy_price { get; set; }
        public int sell_price { get; set; }
        public int stat_stamina { get; set; }
        public int stat_strength { get; set; }
        public int stat_critical_rating { get; set; }
        public int stat_dodge_rating { get; set; }
        public int stat_weapon_damage { get; set; }
        public bool IsEquiped => HzAccountManger.GetAccByCharacterID(character_id).Data.HzInventory.GearItems.FirstOrDefault(item => item.id == id) != null ? true : false;
        public double GearScoreDiffToEquiped => HzAccountManger.GetAccByCharacterID(character_id).Data.HzInventory.CompareToEquip(this);
        public string ImageUrl => getIconImageUrl();

        #endregion Properties

        #region Methods

        public double GearScore()
        {
            return stat_stamina * HzAccountManger.GetAccByCharacterID(character_id).Character.HzStats.Stamina.EquipWeight +
               stat_strength * HzAccountManger.GetAccByCharacterID(character_id).Character.HzStats.Strength.EquipWeight +
               stat_dodge_rating * HzAccountManger.GetAccByCharacterID(character_id).Character.HzStats.DodgeRating.EquipWeight +
               stat_critical_rating * HzAccountManger.GetAccByCharacterID(character_id).Character.HzStats.CriticalRating.EquipWeight +
               stat_weapon_damage * HzAccountManger.GetAccByCharacterID(character_id).Character.HzStats.WeaponDamage.EquipWeight;
        }

        private string getIconImageUrl()
        {
            if (identifier.IndexOf("surprise_box") != -1)
            {
                identifier = "sb" + identifier.Substring(0, identifier.LastIndexOf("_"));
            }
            if (type == ItemType.Improvement)
            {
                identifier = "ip_" + identifier;
            }
            return "http://hz-static-2.akamaized.net/assets/items/" + identifier + "_i.png";
        }

        #endregion Methods
    }
}