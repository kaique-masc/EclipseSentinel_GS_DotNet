using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EclipseSentinel.API.Models;

[Table("GS_ECLIPSE_ALERTA")]
public class Alerta
{
    [Key]
    [Column("ID_ALERTA")]
    public long IdAlerta { get; set; }

    [Column("TIPO_ALERTA")]
    public string? TipoAlerta { get; set; }

    [Column("SEVERIDADE")]
    public string? Severidade { get; set; }

    [Column("DESCRICAO")]
    public string? Descricao { get; set; }

    [Column("DATA_ALERTA")]
    public DateTime? DataAlerta { get; set; }

    [Column("ID_AREA")]
    public long? IdArea { get; set; }

    [ForeignKey("IdArea")]
    [JsonIgnore]
    public Area? Area { get; set; }
}