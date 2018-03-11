namespace HZBot
{
    /// <summary>
    /// 
    /// </summary>
    public interface IWorkItem
    {
        int id { get; set; }
        int character_id { get; set; }
        WorkStatus status { get; }

        long RemainingTime { get; }

        WorkType WorkerType { get; }
    }
}