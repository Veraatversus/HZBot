﻿namespace HZBot
{
    public class Training : IWorkItem
    {
        public int id { get; set; }
        public int ts_creation { get; set; }
        public int character_id { get; set; }
        public int stat_type { get; set; }
        public int status { get; set; }
        public int ts_complete { get; set; }
        public int iterations { get; set; }
        public int used_resources { get; set; }
        public long RemainingTime => (ts_complete != 0 ? ts_complete : AccountManger.GetAccountByCharacterID(character_id).ServerTime) - AccountManger.GetAccountByCharacterID(character_id).ServerTime;
        public StatType StatType => (StatType)stat_type;
        public WorkType WorkerType => WorkType.Training;
    }
}