using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EclipseSentinel.API.Models;

[Table("GS_ECLIPSE_AREA")]
public class Area
{
    [Key]
    [Column("ID_AREA")]
    public long IdArea { get; set; }

    [Column("LATITUDE")]
    public double? Latitude { get; set; }

    [Column("LONGITUDE")]
    public double? Longitude { get; set; }

    [Column("NIVEL_RISCO")]
    public string? NivelRisco { get; set; }

    [Column("NOME")]
    public string? Nome { get; set; }

    [Column("STATUS_AREA")]
    public string? StatusArea { get; set; }

    [JsonIgnore]
    public ICollection<Sensor>? Sensores { get; set; }

    [JsonIgnore]
    public ICollection<Alerta>? Alertas { get; set; }

    [JsonIgnore]
    public ICollection<Ocorrencia>? Ocorrencias { get; set; }
}