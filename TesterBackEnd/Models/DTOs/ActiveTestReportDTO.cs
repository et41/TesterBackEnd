namespace TesterBackEnd.Models.DTOs
{
    public class ActiveTestReportDTO
    {
        public int Id { get; set; }
        public DateTime? TestDate { get; set; }
        public List<double>? TtrPhaseURatio { get; set; }
        public List<double>? TtrPhaseVRatio { get; set; }
        public List<double>? TtrPhaseWRatio { get; set; }
        public List<double>? TtrPhaseUDiff { get; set; }
        public List<double>? TtrPhaseVDiff { get; set; }
        public List<double>? TtrPhaseWDiff { get; set; }
        public List<double>? TtrPhaseUAngle { get; set; }
        public List<double>? TtrPhaseVAngle { get; set; }
        public List<double>? TtrPhaseWAngle { get; set; }
        public string? VectorGroup { get; set; }

        public string? Comments { get; set; }
        public double? TemperaturePhaseA { get; set; }
        public double? TemperaturePhaseB { get; set; }
        public double? TemperaturePhaseC { get; set; }
        public List<double>? LvResistancesBetweenPhases { get; set; }
        public List<HvResistanceDTO>? HvResistances { get; set; }

        public List<double>? HvImbalances { get; set; }
        public List<double?>? LvPhaseToPhaseImbalances { get; set; }

        public List<double>? LvPhaseToNeutralImbalances { get; set; }

        public List<double>? LvResistancesToNeutral { get; set; }
        public List<double>? HvResistancesToNeutral { get; set; }
        public List<double>? LvCore { get; set; }
        public List<double>? HvCore { get; set; }
        public List<double>? HvLv { get; set; }
        public int TransformerId { get; set; }
        public List<TransformerDTO> Transformers { get; set; }


        public List<double>? CoreTank { get; set; }
    }
}
