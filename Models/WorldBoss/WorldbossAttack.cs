namespace HZBot
{

    public class WorldbossAttack : IWorkItem
    {
        public int id { get; set; }
        public int worldboss_event_id { get; set; }
        public int character_id { get; set; }
        public WorldbossAttackStatus status { get; set; }
        public int duration_raw { get; set; }
        public int duration { get; set; }
        public int ts_complete { get; set; }
        public int level { get; set; }
        public int total_damage { get; set; }
        public int battle_id { get; set; }
        public int used_resources { get; set; }

        public long RemainingTime => (ts_complete != 0 ? ts_complete : HzAccountManger.GetAccountByCharacterID(character_id).ServerTime) - HzAccountManger.GetAccountByCharacterID(character_id).ServerTime;

        public WorkType WorkerType => WorkType.WorldbossAttack;

        WorkStatus IWorkItem.status
        {
            get
            {
                switch (status)
                {
                    case WorldbossAttackStatus.Unknown:
                        return WorkStatus.Unknown;

                    case WorldbossAttackStatus.Started:
                        return WorkStatus.Started;
                    case WorldbossAttackStatus.Aborted:
                        return WorkStatus.Aborted;
                    case WorldbossAttackStatus.Finished:
                        return WorkStatus.Finished;
                }
                return WorkStatus.Unknown;
            }
        }
    }

}
