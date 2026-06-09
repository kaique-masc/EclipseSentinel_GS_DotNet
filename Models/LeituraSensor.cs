using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EclipseSentinel.API.Models;

[Table("GS_ECLIPSE_LEITURA_SENSOR")]
public class LeituraSensor
{
    [Key]
    [Column("ID_LEITURA")]
    public long IdLeitura { get; set; }

    [Column("TEMPERATURA")]
    public decimal? Temperatura { get; set; }

    [Column("UMIDADE")]
    public decimal? Umidade { get; set; }

    [Column("FUMACA")]
    public decimal? Fumaca { get; set; }

    [Column("DATA_LEITURA")]
    public DateTime? DataLeitura { get; set; }

    [Column("ID_SENSOR")]
    public long? IdSensor { get; set; }

    [ForeignKey("IdSensor")]
    [JsonIgnore]
    public Sensor? Sensor { get; set; }
}