namespace CHUACSystem.Service.ViewModels
{
    public class FlowStatusBM
    {
        public string SeqNo { get; set; }
        public string Name { get; set; }
        public bool Enable { get; set; }
    }

    public class FlowStatusVM : FlowStatusBM
    {
        public long Id { get; set; }
    }
}
