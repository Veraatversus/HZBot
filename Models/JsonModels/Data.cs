﻿using System.Collections.Generic;
using System.Linq;

namespace HZBot
{
    public class Data
    {
        #region Properties

        public Bank_Inventory bank_inventory { get; set; }
        public Character character { get; set; }
        public Inventory inventory { get; set; }
        public List<Item> items { get; set; }
        public List<Quest> quests { get; set; }
        public User user { get; set; }
        public long server_time { get; set; }
        public HideOut hideout { get; set; }
        public List<HideOutRoom> hideout_rooms { get; set; }
        public Quest ActiveQuest => quests.FirstOrDefault(quest => quest.id == character.active_quest_id);
        public Training ActiveTraining => character.active_training_id == training?.id ? training : null;

        public IWorkItem ActiveWorker
        {
            get
            {
                if (ActiveTraining != null) return ActiveTraining;
                if (ActiveQuest != null) return ActiveQuest;
                return null;
            }
        }

        public Training training { get; set; }
        public Quest BestQuest => quests.Aggregate((q1, q2) => q1.XPCurrencyPerEneryAverage > q2.XPCurrencyPerEneryAverage ? q1 : q2);

        #endregion Properties
    }
}