namespace TesterBackEnd.Models
{
    public class Checklist
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        public bool IncomingCoreInsulation { get; set; } = false;
        public bool WindingAssemblyInsulation { get; set; } = false;
        public bool WindingAssemblyTTR { get; set; } = false;

        public bool LidAssemblyInsulation { get; set; } = false;
        public bool LidAssemblyTTR { get; set; } = false;
        public bool TankAssemblyTests { get; set; } = false;
        public bool LabTests { get; set; } = false;

        public int TransformerId { get; set; }

        public Transformer? Transformer { get; set; } // Navigation property

    }
}
