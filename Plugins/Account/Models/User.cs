namespace HZBot
{
    public class User
    {
        #region Properties

        public int id { get; set; }
        public string registration_source { get; set; }
        public string _ref { get; set; }
        public string subid { get; set; }
        public int ts_creation { get; set; }
        public string network { get; set; }
        public bool confirmed { get; set; }
        public string email { get; set; }
        public int login_count { get; set; }
        public string session_id { get; set; }
        public string locale { get; set; }
        public int premium_currency { get; set; }
        public string geo_country_code { get; set; }
        public string settings { get; set; }
        public int status { get; set; }
        public bool trusted { get; set; }

        #endregion Properties
    }
}