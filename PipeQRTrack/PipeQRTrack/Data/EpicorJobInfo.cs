using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;



namespace PipeQRTrack.Data
{
    public class EpicorJobInfo
    {

        [Key]
        [JsonProperty("UD09_Key4")]
        public string LotNumber { get; set; } = null!;

        [JsonProperty("UD09_Key1")]
        public string JobNumber { get; set; } = null!;

        [JsonProperty("UD09_ShortChar01")]
        public string HeatNumber { get; set; } = null!;
        [JsonProperty("RowIdent")]
        public string Row { get; set; } = null!;
    }
}
