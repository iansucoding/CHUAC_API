namespace CHUACSystem.Service.ViewModels
{
    public class EquipConnBase
    {
        public string Name { get; set; }
        public bool Enable { get; set; }
    }
    public class EquipConnView: EquipConnBase
    {
        public long Id { get; set; }
    }
}
