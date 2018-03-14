using System.Collections.Generic;
namespace HZBot
{
    public class HideOut
    {
        #region Properties

        public int id { get; set; }
        public int character_id { get; set; }
        public int hideout_points { get; set; }
        public int current_level { get; set; }
        public int idle_worker_count { get; set; }
        public int max_worker_count { get; set; }
        public int current_resource_glue { get; set; }
        public int max_resource_glue { get; set; }
        public int current_resource_stone { get; set; }
        public int max_resource_stone { get; set; }
        public int current_attacker_units { get; set; }
        public int max_attacker_units { get; set; }
        public int current_defender_units { get; set; }
        public int max_defender_units { get; set; }
        public int current_opponent_id { get; set; }
        public bool current_opponent_chest_reward { get; set; }
        public int ts_last_opponent_refresh { get; set; }
        public string last_opponent_ids { get; set; }
        public int active_battle_id { get; set; }
        public int ts_last_lost_attack { get; set; }
        public int current_worker_level { get; set; }
        public int current_wall_level { get; set; }
        public int current_barracks_level { get; set; }
        public int max_barracks_level { get; set; }
        public int current_gem_production_level { get; set; }
        public int current_broker_level { get; set; }
        public int current_robot_storage_level { get; set; }
        public int room_slot_0_0 { get; set; }
        public int room_slot_0_1 { get; set; }
        public int room_slot_0_2 { get; set; }
        public int room_slot_0_3 { get; set; }
        public int room_slot_0_4 { get; set; }
        public int room_slot_1_0 { get; set; }
        public int room_slot_1_1 { get; set; }
        public int room_slot_1_2 { get; set; }
        public int room_slot_1_3 { get; set; }
        public int room_slot_1_4 { get; set; }
        public int room_slot_2_0 { get; set; }
        public int room_slot_2_1 { get; set; }
        public int room_slot_2_2 { get; set; }
        public int room_slot_2_3 { get; set; }
        public int room_slot_2_4 { get; set; }
        public int room_slot_3_0 { get; set; }
        public int room_slot_3_1 { get; set; }
        public int room_slot_3_2 { get; set; }
        public int room_slot_3_3 { get; set; }
        public int room_slot_3_4 { get; set; }
        public int room_slot_4_0 { get; set; }
        public int room_slot_4_1 { get; set; }
        public int room_slot_4_2 { get; set; }
        public int room_slot_4_3 { get; set; }
        public int room_slot_4_4 { get; set; }
        public int room_slot_5_0 { get; set; }
        public int room_slot_5_1 { get; set; }
        public int room_slot_5_2 { get; set; }
        public int room_slot_5_3 { get; set; }
        public int room_slot_5_4 { get; set; }
        public int room_slot_6_0 { get; set; }
        public int room_slot_6_1 { get; set; }
        public int room_slot_6_2 { get; set; }
        public int room_slot_6_3 { get; set; }
        public int room_slot_6_4 { get; set; }
        public IEnumerable<HideOutRoom> Rooms => HzAccountManger.GetAccByCharacterID(character_id).Data.hideout_rooms;

        public IEnumerable<HideOutRoomSlot> Slots
        {
            get
            {
                for (int level = 0; level < HideoutUtil.MAX_LEVELS; level++)
                {
                    for (int slot = 0; slot < HideoutUtil.MAX_SLOTS; slot++)
                    {
                        var roomId = (int)this.GetType().GetProperty($"room_slot_{level}_{slot}").GetValue(this);
                        var hzSlot = new HideOutRoomSlot
                        {
                            HideOut = this,
                            Level = level,
                            Slot = slot,
                            SlotValue = roomId
                        };
                        yield return hzSlot;
                    }
                }
            }
        }

        #endregion Properties
    }
}