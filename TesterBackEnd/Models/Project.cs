using Microsoft.EntityFrameworkCore;


namespace TesterBackEnd.Models
{
    public class Project
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int HvVoltage { get; set; }
        public int LvVoltage { get; set; }
        public int Taps { get; set; }
        public int RatedTap { get; set; }
        public string? CustomerName { get; set; }
        public string? VectorGroup { get; set; }
        public int Power { get; set; }

        public float DiffBetweenTaps { get; set; }

        public int LVTurns { get; set; }
        public int HVTurns { get; set; }
        public int TapTurns { get; set; }

        public float GuaranteedNoLoadLoss { get; set; }
        public float GuaranteedLoadLoss { get; set; }
        public float GuaranteedShortCircuitVoltage { get; set; }



    }
}
