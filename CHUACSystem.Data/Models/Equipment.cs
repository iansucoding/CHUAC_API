namespace CHUACSystem.Data.Models
{
    public class Equipment: BaseEntity
    {
        public string Name { get; set; }
        public int Seq { get; set; }
        public string Desc { get; set; }
        public double Value { get; set; }
    }
}
