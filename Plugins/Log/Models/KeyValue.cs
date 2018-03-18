namespace HZBot
{
    public class KeyValue : ViewModelBase
    {
        #region Properties

        public string Key { get => _key; set { _key = value; RaisePropertyChanged(); } }
        public int Value { get => _value; set { _value = value; RaisePropertyChanged(); } }

        #endregion Properties

        #region Fields

        private string _key;
        private int _value;

        #endregion Fields
    }
}