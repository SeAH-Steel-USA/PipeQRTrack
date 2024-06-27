using System.ComponentModel.DataAnnotations;

namespace PipeQRTrack.Data
{
    public class WorkOrderDetail
    {
        [Key]
        public Guid Guid { get; set; }

        public string WorkOrder { get; set; }
        public string LotNumber { get; set;}
        public string JointNumber { get; set; }
        public DateTime DateSubmitted { get; set; }

    }
}
