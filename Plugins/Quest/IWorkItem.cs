namespace HZBot
{
    public interface IWorkItem
    {
        #region Properties

        int id { get; set; }
        int character_id { get; set; }
        WorkStatus status { get; set; }
        //int ts_complete { get; set; }
        long RemainingTime { get; }
        WorkType WorkerType { get; }

        #endregion Properties
    }
}