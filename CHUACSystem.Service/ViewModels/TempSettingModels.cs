namespace CHUACSystem.Service.ViewModels
{
    public class TempSettingBase
    {
        public string SeqNo { get; set; }
        public string Name { get; set; }
        public float Adjust { get; set; }
    }
    public class TempSettingView: TempSettingBase
    {
        public long Id { get; set; }
    }
}
