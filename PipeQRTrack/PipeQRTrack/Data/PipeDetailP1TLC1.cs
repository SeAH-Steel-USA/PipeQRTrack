using System.ComponentModel.DataAnnotations;

namespace PipeQRTrack.Data
{
    public class PipeDetailP1TLC1
    {

        [Key]
        public Guid Guid { get; set; }

        public string? LotNumber { get; set; }
        public string? JointNumber { get; set; }
        public string? JobNumber { get; set; }
        public string? HeatNumber { get; set; }
        public char? Status { get; set; }
        public DateTime DateTime { get; set; }

        public short? Millitm { get; set; }
        public double? Val { get; set; }
        public char? Marker { get; set; }
    }
}
