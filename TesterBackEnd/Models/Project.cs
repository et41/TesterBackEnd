using Microsoft.EntityFrameworkCore;


namespace TesterBackEnd.Models
{
    public class Project
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        //HVVoltage  must accept 2.5 like numbers 

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

        public int GuaranteedNoLoadLoss { get; set; }
        public int GuaranteedLoadLoss { get; set; }
        public string? TestDate { get; set; }
        public double GuaranteedShortCircuitVoltage { get; set; }



    }
}
