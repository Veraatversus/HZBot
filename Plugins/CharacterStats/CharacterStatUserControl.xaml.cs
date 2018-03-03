namespace HZBot
{
    /// <summary>
    /// Interaktionslogik für ucCharacterStats.xaml
    /// </summary>
    public partial class CharacterStatUserControl : HzUserControl
    {
        #region Constructors

        public CharacterStatUserControl()
        {
            InitializeComponent();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            DataContext = Account.Plugins.CharacterStat;
        }
        #endregion Constructors
    }
}