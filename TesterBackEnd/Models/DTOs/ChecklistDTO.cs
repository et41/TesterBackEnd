namespace TesterBackEnd.Models.DTOs
{
    public class ChecklistDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public bool IncomingCoreInsulation { get; set; }
        public bool WindingAssemblyInsulation { get; set; }
        public bool WindingAssemblyTTR { get; set; }
        public bool LidAssemblyInsulation { get; set; }
        public bool LidAssemblyTTR { get; set; }
        public bool TankAssemblyTests { get; set; }
        public bool LabTests { get; set; }

        public int TransformerId { get; set; }
    }
}
