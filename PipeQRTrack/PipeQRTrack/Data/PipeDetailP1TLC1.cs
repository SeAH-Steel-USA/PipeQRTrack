using System.ComponentModel.DataAnnotations;

namespace PipeQRTrack.Data
{
    public class PipeDetailP1TLC1
    {

        [Key]
        public Guid Guid { get; set; }

        [Required(ErrorMessage = "Lot Number is required")]
        public string? LotNumber { get; set; }
        public string? JointNumber { get; set; }

        [Required(ErrorMessage = "Job Number is required")]
        public string? JobNumber { get; set; }

        [Required(ErrorMessage = "Heat Number is required")]
        public string? HeatNumber { get; set; }
        public char? Status { get; set; }
        public DateTime DateTime { get; set; }

        public short? Millitm { get; set; }
        public double? Val { get; set; }
        public char? Marker { get; set; }
    }
}
