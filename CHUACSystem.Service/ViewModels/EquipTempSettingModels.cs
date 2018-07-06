namespace CHUACSystem.Service.ViewModels
{
    public class EquipTempSettingBM
    {
        public string Name { get; set; }
        public float Start { get; set; }
        public float End { get; set; }
    }
    public class EquipTempSettingVM : EquipTempSettingBM
    {
        public long Id { get; set; }
    }
}
