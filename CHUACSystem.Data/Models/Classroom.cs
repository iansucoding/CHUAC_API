namespace CHUACSystem.Data.Models
{
    public class Classroom: BaseEntity
    {
        public string Name { get; set; }
        public int Seq { get; set; }
        // 冷氣開啟
        public bool IsAcOn { get; set; }
        // 手動(true)/手動(false)/關閉(null)
        public bool? IsAuto { get; set; }
    }
}
