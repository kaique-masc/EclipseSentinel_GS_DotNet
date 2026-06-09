using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EclipseSentinel.API.Models;

[Table("GS_ECLIPSE_SENSOR")]
public class Sensor
{
    [Key]
    [Column("ID_SENSOR")]
    public long IdSensor { get; set; }

    [Column("TIPO_SENSOR")]
    public string? TipoSensor { get; set; }

    [Column("STATUS_SENSOR")]
    public string? StatusSensor { get; set; }

    [Column("ID_AREA")]
    public long? IdArea { get; set; }

    [ForeignKey("IdArea")]
    [JsonIgnore]
    public Area? Area { get; set; }

    [JsonIgnore]
    public ICollection<LeituraSensor>? Leituras { get; set; }
}