using Microsoft.EntityFrameworkCore;


namespace TesterBackEnd.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string? ProjectId { get; set; }
        public string? HvVoltage { get; set; }
        public string? LvVoltage { get; set; }
        public string? Taps { get; set; }
        public string? RatedTap { get; set; }
        public string? CustomerName { get; set; }
        public string? VectorGroup { get; set; }
        public string? Power { get; set; }

        public string? DiffBetweenTaps { get; set; }

        public string? LVTurns { get; set; }
        public string? HVTurns { get; set; }
        public string? TapTurns { get; set; }

        public string? GuaranteedNoLoadLoss { get; set; }
        public string? GuaranteedLoadLoss { get; set; }
        public string? GuaranteedShortCircuitVoltage { get; set; }



    }
}
