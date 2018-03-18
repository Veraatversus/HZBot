using System.Collections.Generic;

namespace HZBot
{
    public class PostContent
    {
        #region Properties

        public List<KeyValuePair<string, string>> Content { get; set; }
        public HzAccount Account { get; set; }
        public LogObject LogObject { get; set; } = new LogObject();
        public string RequestUrl => $"http://s{Account.Config.ServerId}.herozerogame.com/request.php";

        #endregion Properties
    }
}