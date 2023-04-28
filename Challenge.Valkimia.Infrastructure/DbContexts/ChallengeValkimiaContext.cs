using Challenge.Valkimia.Application;
using Challenge.Valkimia.Infrastructure.Models.Application;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Valkimia.Infrastructure;

public partial class ChallengeValkimiaContext : DbContext, IUnitOfWork
{
    public ChallengeValkimiaContext()
    {
    }

    public ChallengeValkimiaContext(DbContextOptions<ChallengeValkimiaContext> options)
        : base(options)
    {
    }

    public DbSet<Ciudad> Ciudades { get; set; }

    public DbSet<Cliente> Clientes { get; set; }

    public DbSet<Factura> Facturas { get; set; }


    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ciudades__3214EC07214474C4");

            entity.ToTable("Ciudades", "Facturacion");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Nombre)
                .HasMaxLength(90)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clientes__3214EC07FDF3C59F");

            entity.ToTable("Clientes", "Facturacion");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Domicilio)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCiudadNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdCiudad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClienteCiudad");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Facturas__3214EC07E1F6F11F");

            entity.ToTable("Facturas", "Facturacion");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Detalle)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Importe).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacturaCliente");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
