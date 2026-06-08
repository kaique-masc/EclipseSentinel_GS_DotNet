using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EclipseSentinel.API.Models;

[Table("GS_ECLIPSE_OCORRENCIA")]
public class Ocorrencia
{
    [Key]
    [Column("ID_OCORRENCIA")]
    public long IdOcorrencia { get; set; }

    [Column("DESCRICAO")]
    public string? Descricao { get; set; }

    [Column("DATA_OCORRENCIA")]
    public DateTime? DataOcorrencia { get; set; }

    [Column("IMAGEM_URL")]
    public string? ImagemUrl { get; set; }

    [Column("ID_USUARIO")]
    public long? IdUsuario { get; set; }

    [Column("ID_AREA")]
    public long? IdArea { get; set; }

    [ForeignKey("IdArea")]
    public Area? Area { get; set; }
}