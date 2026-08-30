using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace sistemaUñas_MimoraNails.Models;

public partial class MimoraNailsAgusAtelierContext : DbContext
{
    public MimoraNailsAgusAtelierContext()
    {
    }

    public MimoraNailsAgusAtelierContext(DbContextOptions<MimoraNailsAgusAtelierContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<MovimientosStock> MovimientosStocks { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<Turno> Turnos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Agus\\SQLEXPRESS01;Database=MimoraNails_AgusAtelier;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Clientes__D594664289FFA38E");

            entity.HasIndex(e => e.Email, "UQ__Clientes__A9D10534173973F8").IsUnique();

            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Observaciones)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MovimientosStock>(entity =>
        {
            entity.HasKey(e => e.IdMstock).HasName("PK__Movimien__741E050424D6283C");

            entity.ToTable("MovimientosStock");

            entity.Property(e => e.IdMstock).HasColumnName("IdMStock");
            entity.Property(e => e.FechaMovimiento).HasColumnName("Fecha_Movimiento");
            entity.Property(e => e.TipoMovimiento)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.MovimientosStocks)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MovimientosStock_Productos");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PK__Pagos__FC851A3A0452C06C");

            entity.Property(e => e.FechaPago).HasColumnName("Fecha_pago");
            entity.Property(e => e.MetodoPago)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Metodo_Pago");
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SaldoPendiente)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Saldo_Pendiente");

            entity.HasOne(d => d.IdTurnoNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdTurno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pagos_Turnos");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__09889210328D914C");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_Producto");
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.StockActual).HasColumnName("Stock_Actual");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PK__Servicio__2DCCF9A218ADF591");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.NombreServicio)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_Servicio");
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Turno>(entity =>
        {
            entity.HasKey(e => e.IdTurno).HasName("PK__Turnos__C1ECF79A28B44FCC");

            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Pendiente");
            entity.Property(e => e.FechaTurno).HasColumnName("Fecha_turno");
            entity.Property(e => e.HoraTurno).HasColumnName("Hora_turno");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Turnos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Turnos_Clientes");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.Turnos)
                .HasForeignKey(d => d.IdServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Turnos_Servicios");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__5B65BF97E7B39FFA");

            entity.HasIndex(e => e.NombreUsuario, "UQ__Usuarios__57A4BD19C6571A55").IsUnique();

            entity.Property(e => e.Contrasena)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_Usuario");
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
