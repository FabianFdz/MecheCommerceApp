using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Backend.Entities
{
    public partial class MecheDBContext : IdentityDbContext
    {
        public MecheDBContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<MecheDBContext>();
            optionsBuilder.UseSqlServer(Utilities.Util.ConnectionString);
        }

        public MecheDBContext(DbContextOptions<MecheDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<LineasOrden> LineasOrdens { get; set; }
        public virtual DbSet<Orden> Ordens { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Utilities.Util.ConnectionString);
            optionsBuilder.EnableSensitiveDataLogging(true);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.HasIndex(e => e.Correo, "UQ__tmp_ms_x__60695A194F020AB9")
                    .IsUnique();

                entity.Property(e => e.Canton)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Distrito)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Provincia)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Comentario)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Feedback__IdProd__68487DD7");
            });

            modelBuilder.Entity<LineasOrden>(entity =>
            {
                entity.ToTable("LineasOrden");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Precio).HasColumnType("money");

                entity.HasOne(d => d.IdOrdenNavigation)
                    .WithMany(p => p.LineasOrdens)
                    .HasForeignKey(d => d.IdOrden)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LineasOrd__IdOrd__6754599E");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.LineasOrdens)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LineasOrd__IdPro__66603565");
            });

            modelBuilder.Entity<Orden>(entity =>
            {
                entity.ToTable("Orden");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.FacturaHash)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaEntrega).HasColumnType("date");

                entity.Property(e => e.PrecioTotal).HasColumnType("money");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Ordens)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orden__IdCliente__06CD04F7");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioBase).HasColumnType("money");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
