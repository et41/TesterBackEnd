namespace TesterBackEnd.Models
{
    public class ActiveTestReport
    {
        public int Id { get; set; }
        public string? TestDate { get; set; }
        public double? TtrPhaseURatio { get; set; }
        public double? TtrPhaseVRatio { get; set; }
        public double? TtrPhaseWRatio { get; set; }
        public double? TtrPhaseUDiff { get; set; } 
        public double? TtrPhaseVDiff { get; set; }
        public double? TtrPhaseWDiff { get; set; } 
        public string? VectorGroup { get; set; }
        public string? Comments { get; set; }
        public double? TemperaturePhaseA { get; set; }
        public double? TemperaturePhaseB { get; set; }
        public double? TemperaturePhaseC { get; set; }
        public List<double>? LvResistancesBetweenPhases { get; set; }
        public List<double>? HvResistancesBetweenPhases { get; set; }
        public List<double>? LvResistancesToNeutral { get; set; }
        public List<double>? HvResistancesToNeutral { get; set; }
        public List<double>? LvCore { get; set; }
        public List<double>? HvCore { get; set; }
        public List<double>? HvLv { get; set; }
        public int TransformerId { get; set; } 
        public Transformer? Transformer { get; set; } // Navigation property


    }
}
