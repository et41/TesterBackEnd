namespace TesterBackEnd.Models
{
    public class Transformer
    {
        public int Id { get; set; }
        public string? SerialNumber { get; set; }
        public string? TestDate { get; set; }
        public bool? ActivePartReport { get; set; }
        public bool? TestReport { get; set; }
        public int? ProjectId { get; set; }
        public Project? Project { get; set; } // Navigation property
    }
}
