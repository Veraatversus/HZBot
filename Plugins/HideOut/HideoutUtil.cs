﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HZBot
{
    public static class HideoutUtil
    {
        #region Fields

        public static int MAX_LEVELS = 7;

        public static int MAX_SLOTS = 5;

        #endregion Fields

        #region Methods

        public static double secondsTillActivityFinished(this HideOutRoom room)
        {
            long _loc3_ = 0;
            double _loc5_ = 0;
            var _loc1_ = double.NaN;
            double _loc4_ = 0;
            double _loc2_ = 0;
            if (room.status == HideoutRoomStatus.Producing && !room.isManuallyProductionRoom)
            {
                _loc3_ = HzAccountManger.GetAccByHideOutID(room.hideout_id).ServerTime - room.ts_last_resource_change;
                _loc5_ = Math.Floor(_loc3_ / 60.0f);
                _loc1_ = resourceAmountPerMinute(room);
                _loc4_ = Math.Floor(_loc1_ * _loc5_) + room.current_resource_amount;
                if (_loc4_ < room.max_resource_amount)
                {
                    _loc2_ = Math.Ceiling((room.max_resource_amount - _loc4_) / (_loc1_ / 60) - (_loc3_ - _loc5_ * 60));
                }
            }
            else if (room.status == HideoutRoomStatus.Upgrading ||
                   room.status == HideoutRoomStatus.Building ||
                   room.status == HideoutRoomStatus.Placing ||
                   room.status == HideoutRoomStatus.Storing ||
                   room.status == HideoutRoomStatus.Producing && room.isManuallyProductionRoom)
            {
                _loc2_ = room.ts_activity_end - HzAccountManger.GetAccByHideOutID(room.hideout_id).ServerTime;
            }
            return _loc2_;
        }

        public static double currentCalculatedResourceAmount(this HideOutRoom room)
        {
            var _loc3_ = room.current_resource_amount;
            var _loc1_ = room.max_resource_amount;
            if (room.status != HideoutRoomStatus.Producing || _loc3_ >= _loc1_)
            {
                return _loc3_;
            }
            if (room.isManuallyProductionRoom && room.ts_activity_end < HzAccountManger.GetAccByHideOutID(room.hideout_id).ServerTime)
            {
                return _loc1_;
            }
            var _loc4_ = room.ts_last_resource_change;
            var _loc5_ = HzAccountManger.GetAccByHideOutID(room.hideout_id).ServerTime - _loc4_;
            var _loc6_ = Math.Floor(_loc5_ / 60.0f);
            if (_loc6_ <= 0)
            {
                return _loc3_;
            }
            var _loc2_ = Math.Floor(resourceAmountPerMinute(room) * _loc6_);
            return Math.Min(_loc2_ + _loc3_, _loc1_);
        }

        public static double resourceAmountPerMinute(this HideOutRoom room)
        {
            var _loc3_ = Double.NaN;
            JToken _loc4_;
            double _loc2_ = 0;
            double _loc1_ = 0;
            if (room.isManuallyProductionRoom)
            {
                _loc3_ = (room.ts_activity_end - room.ts_last_resource_change) / (room.max_resource_amount - room.current_resource_amount);
                _loc1_ = 60 / _loc3_;
            }
            else if (room.isAutoProductionRoom)
            {
                _loc4_ = HzConstants.Default.Constants["hideout_rooms"][room.identifier]["levels"][room.level.ToString()];
                _loc2_ = Math.Max(Math.Round(_loc4_["min_till_max_resource"].Value<double>() * HzConstants.Default.Constants["hideout_min_till_max_resource_duration_scaling"].Value<double>()), 1);
                _loc1_ = room.max_resource_amount / _loc2_;
            }
            return _loc1_;
        }

        public static double maxResourceAmount(this HideOutRoom room)
        {
            if (room.isAutoProductionRoom)
            {
                return room.max_resource_amount * currentGeneratorFactor(room);
            }
            return room.max_resource_amount;
        }

        public static double currentGeneratorFactor(this HideOutRoom room)
        {
            double _loc1_ = 1;
            if (room.isAutoProductionRoom && room.current_generator_level > 0)
            {
                _loc1_ = 1 + room.CGeneratator.passiv_bonus_amount_1 / 100;
            }
            return _loc1_;
        }


        public static bool HasRewardToCollect(this HideOutRoom room, int IsFullInProzent)
        {
            return room.status == HideoutRoomStatus.Producing && room.isAutoProductionRoom && room.currentCalculatedResourceAmount() / room.maxResourceAmount() * 100 >= IsFullInProzent;  
            }

        public static IEnumerable<HideOutRoom> RoomsToRewardCollect(this HideOut hideout, int IsFullInProzent)
        {
            if (hideout != null)
            {
                foreach (var room in hideout.Rooms)
                {
                    if (room.HasRewardToCollect(IsFullInProzent))
                    {
                        yield return room;
                    }
                }
            }
        }

        public static string getSlotIdFromLevelAndSlot(int level, int slot)
        {
            return level + "_" + slot;
        }

        public static bool isSlotUnlockInProgress(this HideOut hideout, int level, int slot)
        {
            var _loc3_ = "room_slot_" + HideoutUtil.getSlotIdFromLevelAndSlot(level, slot);
            var endslot = (int)hideout.GetType().GetProperty(_loc3_).GetValue(hideout);

            return endslot < -1;
        }

        public static int getSlotUnlockTsEnd(this HideOut hideout, int level, int slot)
        {
            var _loc3_ = "room_slot_" + HideoutUtil.getSlotIdFromLevelAndSlot(level, slot);
            var endslot = (int)hideout.GetType().GetProperty(_loc3_).GetValue(hideout);

            return endslot + -1;
        }

        public static HideoutWorkerActivity getCurrentWorkerActivity(this HideOut hideout)
        {
            var _loc4_ = 0;
            var _loc7_ = 0;
            var _loc6_ = 0;
            HideOutRoom _loc2_ = null;
            var _loc1_ = -1;
            var _loc3_ = -1;
            foreach (var room in hideout.Rooms)
            {
                if (room.status == HideoutRoomStatus.Building || room.status == HideoutRoomStatus.Placing || room.status == HideoutRoomStatus.Storing || room.status == HideoutRoomStatus.Upgrading)
                {
                    if (room.ts_activity_end > _loc6_ && room.ts_activity_end > HzAccountManger.GetAccByCharacterID(hideout.character_id).ServerTime)
                    {
                        _loc6_ = room.ts_activity_end;
                        _loc2_ = room;
                    }
                }
            }
            _loc4_ = 0;
            while (_loc4_ < HideoutUtil.MAX_LEVELS)
            {
                _loc7_ = 0;
                while (_loc7_ < HideoutUtil.MAX_SLOTS)
                {
                    if (hideout.isSlotUnlockInProgress(_loc4_, _loc7_) && hideout.getSlotUnlockTsEnd(_loc4_, _loc7_) > _loc6_ && hideout.getSlotUnlockTsEnd(_loc4_, _loc7_) > HzAccountManger.GetAccByCharacterID(hideout.character_id).ServerTime)
                    {
                        _loc6_ = hideout.getSlotUnlockTsEnd(_loc4_, _loc7_);
                        _loc1_ = _loc4_;
                        _loc3_ = _loc7_;
                    }
                    _loc7_++;
                }
                _loc4_++;
            }
            return new HideoutWorkerActivity(_loc2_, _loc1_, _loc3_);
        }

        public static int getRoomCountWithIdentifier(this IEnumerable<HideOutRoom> rooms, string identifier)
        {
            var _loc2_ = 0;

            foreach (var room in rooms)
            {
                if (room.identifier == identifier)
                {
                    _loc2_++;
                }
            }
            return _loc2_;
        }

        public static HideOutRoom getRoomBySlot(this HideOut hideout, string identifier)
        {
            var slotName = "room_slot_" + identifier;
            var slot = (int)hideout.GetType().GetProperty(slotName).GetValue(hideout);
            if (slot == 0)
            {
                return null;
            }

            foreach (var room in hideout.Rooms)
            {
                if (room.id == slot)
                {
                    return room;
                }
            }
            return null;
        }

        public static bool isRoomInStore(this HideOutRoom room)
        {
            var level = 0;
            var slot = 0;
            HideOutRoom _loc4_ = null;
            level = 0;
            while (level < HideoutUtil.MAX_LEVELS)
            {
                slot = 0;
                while (slot < HideoutUtil.MAX_SLOTS)
                {
                    _loc4_ = HzAccountManger.GetAccByHideOutID(room.hideout_id).Data.hideout.getRoomBySlot(HideoutUtil.getSlotIdFromLevelAndSlot(level, slot));
                    if (_loc4_ != null && _loc4_.id == room.id)
                    {
                        return false;
                    }
                    slot++;
                }
                level++;
            }
            return true;

        }

        public static bool canRoomBeBuild(this HideOut hideOut, string hideOutRoomType)
        {
            var param3 = HzConstants.Default.Constants["hideout_rooms"][hideOutRoomType];
            if (param3["limit"].Value<int>() == 0)
            {
                return false;
            }
            var _loc5_ = hideOut.Rooms.getRoomCountWithIdentifier(hideOutRoomType);
            if (_loc5_ >= param3["limit"].Value<int>())
            {
                return false;
            }
            var _loc7_ = 0;
            var _loc6_ = hideOut.Rooms.FirstOrDefault(r => r.identifier == HideoutRoomTypes.MainBuilding);
            if (_loc6_ != null && !_loc6_.isRoomInStore())
            {
                _loc7_ = _loc6_.level;
            }
            var _loc4_ = 0;
            var _loc8_ = _loc5_ + 1;
            if (1 != _loc8_)
            {
                if (2 != _loc8_)
                {
                    if (3 != _loc8_)
                    {
                        if (4 == _loc8_)
                        {
                            _loc4_ = param3["unlock_with_mainbuilding_4"].Value<int>();
                        }
                    }
                    else
                    {
                        _loc4_ = param3["unlock_with_mainbuilding_3"].Value<int>();
                    }
                }
                else
                {
                    _loc4_ = param3["unlock_with_mainbuilding_2"].Value<int>();
                }
            }
            else
            {
                _loc4_ = param3["unlock_with_mainbuilding_1"].Value<int>();
            }
            if (_loc7_ < _loc4_)
            {
                return false; // LocText.current.text("dialog/hideout/place_room/error_room_needs_mainbuilding_level", _loc4_);
            }
            return true;
        }

        public static double getReducedGameCurrencyValue(this HideOutRoom room)
        {
            var priceGold = room.CNextLevel.price_gold;
            var currentBrokerLevel = HzAccountManger.GetAccByHideOutID(room.hideout_id).Data.hideout.current_broker_level;
            if (currentBrokerLevel == 0)
            {
                return priceGold;
            }
            var _loc4_ = HzConstants.Default.Constants["hideout_rooms"]["broker"];
            double _loc3_ = priceGold;
            var brokerlevel = _loc4_["levels"].OfType<JProperty>().FirstOrDefault(tok => tok.Name == currentBrokerLevel.ToString());
            if (brokerlevel != null)
            {
                _loc3_ = (1 - brokerlevel["passiv_bonus_amount_1"].Value<int>() / 100) * _loc3_;
            }
            return Math.Ceiling(_loc3_);
        }

        public static bool isRoomActivityFinished(this HideOut hideout)
        {
            var _loc1_ = 0;
            var _loc4_ = 0;
            var _loc2_ = HzAccountManger.GetAccByCharacterID(hideout.character_id).ServerTime;

            foreach (var room in hideout.Rooms)
            {
                if (room.isManuallyProductionRoom && room.status == HideoutRoomStatus.Producing && room.currentCalculatedResourceAmount() >= room.maxResourceAmount())
                {
                    return true;
                }
                if ((room.status == HideoutRoomStatus.Building || room.status == HideoutRoomStatus.Upgrading || room.status == HideoutRoomStatus.Storing || room.status == HideoutRoomStatus.Placing) && room.ts_activity_end <= _loc2_)
                {
                    return true;
                }
            }
            _loc1_ = 0;
            while (_loc1_ < HideoutUtil.MAX_LEVELS)
            {
                _loc4_ = 0;
                while (_loc4_ < HideoutUtil.MAX_SLOTS)
                {
                    if (hideout.isSlotUnlockInProgress(_loc1_, _loc4_) && hideout.getSlotUnlockTsEnd(_loc1_, _loc4_) <= _loc2_)
                    {
                        return true;
                    }
                    _loc4_++;
                }
                _loc1_++;
            }
            return false;
        }

        public static bool refreshUpgradableIcon(this HideOutRoom room, HideOut hideOut, JToken hideoutroomlevel = null)
        {
            //if(!_room || !_btnUpgrade.visible || !User.current.character.hasTutorialFlag("hideout_first_attack"))
            //{
            //   _content.ui.upgradeAvailable.visible = false;
            //   return;
            //}
            if (hideoutroomlevel == null)
            {
                hideoutroomlevel = HzConstants.Default.Constants["hideout_rooms"][room.identifier]["levels"].OfType<JProperty>().FirstOrDefault(tok => tok.Name == (room.level + 1).ToString())?.Value; //CHideoutRoom.fromId(_room.identifier).getLevel(_room.level + 1);
            }
            var _loc3_ = HzConstants.Default.Constants["hideout_room_upgrade"].OfType<JProperty>().FirstOrDefault(tok => tok.Name == (room.level + 1).ToString())?.Value["character_min_level"].Value<int>(); //CHideoutRoomUpgrade.fromId(_room.level + 1).characterMinLevel;
            if (_loc3_ > HzAccountManger.GetAccByHideOutID(hideOut.id).Character?.level)
            {
                return false;
            }
            else
            {
                if (HzAccountManger.GetAccByHideOutID(hideOut.id).Character?.game_currency >= room.getReducedGameCurrencyValue() && hideOut.current_resource_glue >= room.CNextLevel.price_glue && hideOut.current_resource_stone >= room.CNextLevel.price_stone)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion Methods
    }
}