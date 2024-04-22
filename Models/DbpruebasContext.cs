using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SistemaControl.Models;

public partial class DbpruebasContext : DbContext
{
    public DbpruebasContext()
    {
    }

    public DbpruebasContext(DbContextOptions<DbpruebasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Interrupcione> Interrupciones { get; set; }

    public virtual DbSet<Maestro> Maestros { get; set; }

    public virtual DbSet<Ordene> Ordenes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local); DataBase=DBPRUEBAS;Trusted_Connection=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Interrupcione>(entity =>
        {
            entity.HasKey(e => e.IdInte).HasName("PK__Interrup__B0BFD1371515C249");

            entity.Property(e => e.IdInte).HasColumnName("idInte");
            entity.Property(e => e.DiaFin)
                .HasColumnType("datetime")
                .HasColumnName("diaFin");
            entity.Property(e => e.DiaIni)
                .HasColumnType("datetime")
                .HasColumnName("diaIni");
            entity.Property(e => e.HoraFin)
                .HasColumnType("datetime")
                .HasColumnName("horaFin");
            entity.Property(e => e.HoraIni)
                .HasColumnType("datetime")
                .HasColumnName("horaIni");
            entity.Property(e => e.IdOrden)
                .HasMaxLength(9)
                .HasColumnName("idOrden");
            entity.Property(e => e.Motivo)
                .HasMaxLength(300)
                .HasColumnName("motivo");
            entity.Property(e => e.MotivoBase)
                .HasMaxLength(200)
                .HasColumnName("motivoBase");

            entity.HasOne(d => d.IdOrdenNavigation).WithMany(p => p.Interrupciones)
                .HasForeignKey(d => d.IdOrden)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Interrupc__idOrd__403A8C7D");
        });

        modelBuilder.Entity<Maestro>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Maestro");

            entity.Property(e => e.Codigo)
                .HasMaxLength(40)
                .HasColumnName("codigo");
            entity.Property(e => e.IdMaestro)
                .ValueGeneratedOnAdd()
                .HasColumnName("idMaestro");
            entity.Property(e => e.Texto)
                .HasMaxLength(200)
                .HasColumnName("texto");
            entity.Property(e => e.Valor).HasColumnName("valor");
        });

        modelBuilder.Entity<Ordene>(entity =>
        {
            entity.HasKey(e => e.IdOrden).HasName("PK__Ordenes__C8AAF6F31B423946");

            entity.Property(e => e.IdOrden)
                .HasMaxLength(9)
                .HasColumnName("idOrden");
            entity.Property(e => e.Detalle)
                .HasMaxLength(200)
                .HasColumnName("detalle");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Tipo).HasColumnName("tipo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
