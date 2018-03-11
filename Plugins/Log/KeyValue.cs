
namespace HZBot
{
    public class KeyValue : ViewModelBase
    {
        private string _key;
        private int _value;

        public string Key { get => _key; set { _key = value; RaisePropertyChanged(); } }
        public int Value { get => _value; set { _value = value; RaisePropertyChanged(); } }
    }
}
