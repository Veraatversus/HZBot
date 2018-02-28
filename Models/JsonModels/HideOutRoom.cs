namespace HZBot
{
    public class HideOutRoom
    {
        public int id { get; set; }
        public int hideout_id { get; set; }
        public int ts_creation { get; set; }
        public string identifier { get; set; }
        public int status { get; set; }
        public int level { get; set; }
        public int current_resource_amount { get; set; }
        public int max_resource_amount { get; set; }
        public int ts_last_resource_change { get; set; }
        public int ts_activity_end { get; set; }
        public int current_generator_level { get; set; }
        public int additional_value_1 { get; set; }
        public string additional_value_2 { get; set; }
    }
}