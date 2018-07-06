namespace CHUACSystem.Data.Models
{
    public class EquipTempSetting : BaseEntity
    {
        public string Name { get; set; }
        public float Start { get; set; }
        public float End { get; set; }
    }
}
