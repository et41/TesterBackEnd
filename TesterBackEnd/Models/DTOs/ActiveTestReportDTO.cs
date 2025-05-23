﻿using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesterBackEnd.Models.DTOs
{
    public class ActiveTestReportDTO
    {
        public int Id { get; set; }
        public DateTime? TestDate { get; set; } = new();
        public ObservableCollection<double?> TtrPhaseURatio { get; set; } = new();
        public ObservableCollection<double?> TtrPhaseVRatio { get; set; } = new();
        public ObservableCollection<double?> TtrPhaseWRatio { get; set; } = new();
        public ObservableCollection<double?>? TtrPhaseUDiff { get; set; } = new();
        public ObservableCollection<double?>? TtrPhaseVDiff { get; set; } = new();
        public ObservableCollection<double?>? TtrPhaseWDiff { get; set; } = new();
        public ObservableCollection<double?>? TtrPhaseUAngle { get; set; } = new();
        public ObservableCollection<double?>? TtrPhaseVAngle { get; set; } = new();
        public ObservableCollection<double?>? TtrPhaseWAngle { get; set; } = new();
        public string? VectorGroup { get; set; }
        public string? Comments { get; set; }
        public double? TemperaturePhaseA { get; set; } = new();
        public double? TemperaturePhaseB { get; set; } = new();
        public double? TemperaturePhaseC { get; set; } = new();
        public ObservableCollection<double?>? LvResistancesBetweenPhases { get; set; } = new();

        //[Column(TypeName = "json")]
        //public ObservableCollection<ObservableCollection<double?>>? HvResistancesBetweenPhases { get; set; } = new();
        public ObservableCollection<double?>? HvResistancesU { get; set; } = new();
        public ObservableCollection<double?>? HvResistancesV { get; set; } = new();
        public ObservableCollection<double?>? HvResistancesW { get; set; } = new();
        public ObservableCollection<double?>? HvImbalances { get; set; } = new();
        public ObservableCollection<double?>? LvPhaseToPhaseImbalances { get; set; } = new();
        public ObservableCollection<double?>? LvPhaseToNeutralImbalances { get; set; } = new();

        public ObservableCollection<double?>? LvResistancesToNeutral { get; set; } = new();
        public ObservableCollection<double?>? HvResistancesToNeutral { get; set; } = new();
        public ObservableCollection<double?>? LvCore { get; set; } = new();
        public ObservableCollection<double?>? HvCore { get; set; } = new();
        public ObservableCollection<double?>? HvLv { get; set; } = new();
        public ObservableCollection<double?>? CoreTank { get; set; } = new();
        public int TransformerId { get; set; }

        //public ActiveTestReport Clone() => MemberwiseClone() as ActiveTestReport;   
        //public TransformerDTO? Transformer { get; set; } // Navigation property

    }
}
