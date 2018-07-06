namespace CHUACSystem.Data.Models
{
    public class Host : BaseEntity
    {
        public string Name { get; set; }
        public string HeaderName { get; set; }
        public long HostGroupId { get; set; }
        public HostGroup HostGroup { get; set; }
        public bool Enable { get; set; }
        public bool Week0 { get; set; }
        public bool Week1 { get; set; }
        public bool Week2 { get; set; }
        public bool Week3{ get; set; }
        public bool Week4 { get; set; }
        public bool Week5 { get; set; }
        public bool Week6 { get; set; }
    }
}
