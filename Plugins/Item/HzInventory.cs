using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HZBot
{
    public class HzInventory
    {
        #region Constructors

        public HzInventory(Data data)
        {
            this.data = data;
        }

        #endregion Constructors

        #region Properties

        public int BagItemCount => BagItems.Count(item => item != null);

        public int BagSlotsUnlocked => bagSlotsUnlocked();
        public double GearScore => GearItems.Sum(item => item.GearScore());

        public int FreeBagSpace => BagSlotsUnlocked - BagItemCount;

        public IEnumerable<Item> BagItems => slots.Where(slot => slot.Type == HzInventorySlotType.Bag && slot.Item != null).Select(slot => slot.Item);

        public IEnumerable<Item> GearItems => slots.Where(slot => slot.Type == HzInventorySlotType.Gear && slot.Item != null).Select(slot => slot.Item);

        #endregion Properties

        #region Methods

        public double CompareToEquip(Item item)
        {
            return item.GearScore() - (GearItems.FirstOrDefault(i => i.type == item.type)?.GearScore() ?? 0);
        }

        #endregion Methods

        #region Fields

        private readonly Data data;

        #endregion Fields

        private IEnumerable<HzBagSlot> slots => data.inventory.GetType().GetProperties()
                         .Where(prop => prop.Name.Contains("item") && prop.Name.Contains("id"))
                 .Select(prop =>
                 {
                     var slot = new HzBagSlot();
                     if (prop.Name.Contains("bag_"))
                     {
                         slot.Type = HzInventorySlotType.Bag;
                     }
                     else if (prop.Name.Contains("shop2_"))
                     {
                         slot.Type = HzInventorySlotType.Shop2;
                     }
                     else if (prop.Name.Contains("shop_"))
                     {
                         slot.Type = HzInventorySlotType.Shop;
                     }
                     else
                     {
                         slot.Type = HzInventorySlotType.Gear;
                     }
                     slot.Item = HzAccountManger.GetItemById((int)prop.GetValue(data.inventory), data.character.id);
                     slot.Id = ToInventoryId(prop.Name);
                     SetIsUnlocked(slot);
                     return slot;
                 });

        private int bagSlotsUnlocked()
        {
            if (data.character.level > HzConstants.Default.Constants["inventory_bag3_unlock_level"].Value<int>())
                return 18;
            else if (data.character.level > HzConstants.Default.Constants["inventory_bag2_unlock_level"].Value<int>())
                return 12;
            else
                return 6;
        }

        public HzBagSlot GetFreeBagSlot()
        {
            return slots.FirstOrDefault(slot => slot.Type == HzInventorySlotType.Bag && slot.Item == null && slot.IsUnlocked);
        }

        private static HzInventoryId ToInventoryId(string slotName)
        {
            return Enum.GetValues(typeof(HzInventoryId)).Cast<HzInventoryId>().FirstOrDefault(slot => slotName.Contains(slot.ToString().ToLower()));
        }

        private void SetIsUnlocked(HzBagSlot bagSlot)
        {
            if (bagSlot.Id != HzInventoryId.Unknown)
            {
                bagSlot.IsUnlocked = (bagSlot.Id - HzInventoryId.Missiles) <= BagSlotsUnlocked;
            }
        }
    }
}