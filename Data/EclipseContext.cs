using EclipseSentinel.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EclipseSentinel.API.Data;

public class EclipseContext : DbContext
{
    public EclipseContext(DbContextOptions<EclipseContext> options)
        : base(options)
    {
    }

    public DbSet<Area> Areas { get; set; }

    public DbSet<Sensor> Sensores { get; set; }

    public DbSet<LeituraSensor> LeiturasSensor { get; set; }

    public DbSet<Alerta> Alertas { get; set; }

    public DbSet<Ocorrencia> Ocorrencias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>()
            .HasMany(a => a.Sensores)
            .WithOne(s => s.Area)
            .HasForeignKey(s => s.IdArea);

        modelBuilder.Entity<Sensor>()
            .HasMany(s => s.Leituras)
            .WithOne(l => l.Sensor)
            .HasForeignKey(l => l.IdSensor);

        modelBuilder.Entity<Area>()
            .HasMany(a => a.Alertas)
            .WithOne(a => a.Area)
            .HasForeignKey(a => a.IdArea);

        modelBuilder.Entity<Area>()
            .HasMany(a => a.Ocorrencias)
            .WithOne(o => o.Area)
            .HasForeignKey(o => o.IdArea);

        base.OnModelCreating(modelBuilder);
    }
}