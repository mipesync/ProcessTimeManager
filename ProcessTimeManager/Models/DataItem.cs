namespace ProcessTimeManager.Models
{
    public class DataItem
    {
        public bool IsChecked { get; set; }
        public int ProcessId { get; set; }
        public string? Name { get; set; }
        public string? Time { get; set; }
        public Icon? Image { get; set; }
    }
}
