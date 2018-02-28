namespace HZBot
{
    public interface IWorkItem
    {
        int id { get; set; }
        int character_id { get; set; }
        int status { get; set; }
        int ts_complete { get; set; }
        long RemainingTime { get; }
        WorkType WorkerType { get; }
    }
}