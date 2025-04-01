namespace TesterBackEnd.Models
{
    public class HvResistance
    {
        public int Id { get; set; }
        public int ActiveTestReportId { get; set; }  // Foreign key
        public int PhaseIndex { get; set; }  // Row index
        public int SubIndex { get; set; }    // Column index
        public double? ResistanceValue { get; set; }
        public ActiveTestReport? ActiveTestReport { get; set; }
    }
}
