namespace TesterBackEnd.Models.DTOs
{
    public class HvResistanceDTO
    {
        public int ActiveTestReportId { get; set; }  // Foreign key
        public int PhaseIndex { get; set; }  // Row index
        public int SubIndex { get; set; }    // Column index
        public double? ResistanceValue { get; set; }
    }
}
