namespace CHUACSystem.Data.Models
{
    public class TempSetting: BaseEntity
    {
        public string SeqNo { get; set; }
        public string Name { get; set; }
        public float Adjust { get; set; }
        public int Sequence { get; set; }
    }
}
