using Microsoft.EntityFrameworkCore;


namespace TesterBackEnd.Models
{
    public class Project
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int Pieces { get; set; }

        public double HvVoltage { get; set; }
        public double LvVoltage { get; set; }
        public int Taps { get; set; }
        public int RatedTap { get; set; }
        public string? CustomerName { get; set; }
        public string? VectorGroup { get; set; }
        public int Power { get; set; }
        public double DiffBetweenTaps { get; set; }
        public int LVTurns { get; set; }
        public int HVTurns { get; set; }
        public int TapTurns { get; set; }
        public double HVDesignRes { get; set; }
        public double LVDesignRes { get; set; }
        public int GuaranteedNoLoadLoss { get; set; }
        public int GuaranteedLoadLoss { get; set; }
        public string? TestDate { get; set; }
        public double GuaranteedShortCircuitVoltage { get; set; }
        public ICollection<Transformer>? Transformers { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }



    }
}
