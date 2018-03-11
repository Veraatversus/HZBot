using Newtonsoft.Json.Linq;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace HZBot
{
    public class HzConstants
    {
        #region Properties

        public static HzConstants Default
        {
            get
            {
                if (_default == null)
                {
                    _default = new HzConstants();
                }
                return _default;
            }
        }

        public JObject Constants { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>Generate MD5 Hash from the request action and the userid</summary>
        /// <param name="action">The action.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public static string MD5Hash(string action, string userId)
        {
            var hash = new StringBuilder();
            using (var md5provider = new MD5CryptoServiceProvider())
            {
                var bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes($"{action}bpHgj5214{userId}"));

                for (int i = 0; i < bytes.Length; i++)
                {
                    hash.Append(bytes[i].ToString("x2"));
                }
                return hash.ToString();
            }
        }

        #endregion Methods

        #region Fields

        private static HzConstants _default;

        #endregion Fields

        #region Constructors

        private HzConstants()
        {
            const string resourceName = "HZBot.Assets.constantsReadable.json";
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                var result = reader.ReadToEnd();
                Constants = JObject.Parse(result);
            }
        }

        #endregion Constructors
    }
}