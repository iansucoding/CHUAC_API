namespace CHUACSystem.Service.ViewModels
{
    public class OtherSettingBase
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class OtherSettingView: OtherSettingBase
    {
        public long Id { get; set; }
    }
}
