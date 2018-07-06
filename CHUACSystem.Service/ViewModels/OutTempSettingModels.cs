namespace CHUACSystem.Service.ViewModels
{
    public class OutTempSettingBase
    {
        public string Name { get; set; }
        public float Start { get; set; }
        public float? End { get; set; }
    }
    public class OutTempSettingView: OutTempSettingBase
    {
        public long Id { get; set; }
    }
}
