using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MVC.Entities
{
    public partial class PeliculasContext : DbContext
    {
        public PeliculasContext()
        {
        }

        public PeliculasContext(DbContextOptions<PeliculasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OrdenesRentasDetalle> OrdenesRentasDetalles { get; set; }
        public virtual DbSet<OrdenesRentum> OrdenesRenta { get; set; }
        public virtual DbSet<OrdenesVenta> OrdenesVentas { get; set; }
        public virtual DbSet<OrdenesVentasDetalle> OrdenesVentasDetalles { get; set; }
        public virtual DbSet<Pelicula> Peliculas { get; set; }
        public virtual DbSet<TipoPelicula> TipoPeliculas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("data source=DOUGLAS;initial catalog=Peliculas;Integrated Security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<OrdenesRentasDetalle>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("OrdenesRentasDetalle");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.EstadoDetalle).HasColumnName("estadoDetalle");

                entity.Property(e => e.IdOrdenRenta).HasColumnName("idOrdenRenta");

                entity.Property(e => e.IdOrdenRentaDetalle)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idOrdenRentaDetalle");

                entity.Property(e => e.IdPelicula).HasColumnName("idPelicula");

                entity.HasOne(d => d.IdOrdenRentaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdOrdenRenta)
                    .HasConstraintName("FK_OrdenesRentasDetalle_OrdenesRenta");

                entity.HasOne(d => d.IdPeliculaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPelicula)
                    .HasConstraintName("FK_OrdenesRentasDetalle_Peliculas");
            });

            modelBuilder.Entity<OrdenesRentum>(entity =>
            {
                entity.HasKey(e => e.IdOrdenRenta)
                    .HasName("PK_OrdenesRentas");

                entity.Property(e => e.IdOrdenRenta).HasColumnName("idOrdenRenta");

                entity.Property(e => e.EstadoOrdenRenta).HasColumnName("estadoOrdenRenta");

                entity.Property(e => e.FechaHoraOrdenRenta)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaHoraOrdenRenta");

                entity.Property(e => e.FechaVencimiento)
                    .HasColumnType("date")
                    .HasColumnName("fechaVencimiento");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.OrdenesRenta)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_OrdenesRenta_Usuarios");
            });

            modelBuilder.Entity<OrdenesVenta>(entity =>
            {
                entity.HasKey(e => e.IdOrdenVenta);

                entity.Property(e => e.IdOrdenVenta).HasColumnName("idOrdenVenta");

                entity.Property(e => e.EstadoOrdenVenta).HasColumnName("estadoOrdenVenta");

                entity.Property(e => e.FechaHoraOrdenVenta)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaHoraOrdenVenta");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.TotalVenta)
                    .HasColumnType("decimal(14, 2)")
                    .HasColumnName("totalVenta");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.OrdenesVenta)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_OrdenesVentas_Usuarios");
            });

            modelBuilder.Entity<OrdenesVentasDetalle>(entity =>
            {
                entity.HasKey(e => e.IdOrdenVentaDetalle);

                entity.ToTable("OrdenesVentasDetalle");

                entity.Property(e => e.IdOrdenVentaDetalle).HasColumnName("idOrdenVentaDetalle");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.EstadoDetalle).HasColumnName("estadoDetalle");

                entity.Property(e => e.IdOrdenVenta).HasColumnName("idOrdenVenta");

                entity.Property(e => e.IdPelicula).HasColumnName("idPelicula");

                entity.Property(e => e.MontoVenta)
                    .HasColumnType("decimal(14, 2)")
                    .HasColumnName("montoVenta");

                entity.HasOne(d => d.IdOrdenVentaNavigation)
                    .WithMany(p => p.OrdenesVentasDetalles)
                    .HasForeignKey(d => d.IdOrdenVenta)
                    .HasConstraintName("FK_OrdenesVentasDetalle_OrdenesVentas");

                entity.HasOne(d => d.IdPeliculaNavigation)
                    .WithMany(p => p.OrdenesVentasDetalles)
                    .HasForeignKey(d => d.IdPelicula)
                    .HasConstraintName("FK_OrdenesVentasDetalle_Peliculas");
            });

            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.HasKey(e => e.IdPelicula);

                entity.Property(e => e.IdPelicula).HasColumnName("idPelicula");

                entity.Property(e => e.Clasificacion)
                    .HasMaxLength(1)
                    .HasColumnName("clasificacion");

                entity.Property(e => e.EstadoPelicula).HasColumnName("estadoPelicula");

                entity.Property(e => e.FechaEstreno)
                    .HasColumnType("date")
                    .HasColumnName("fechaEstreno");

                entity.Property(e => e.IdTipoPelicula).HasColumnName("idTipoPelicula");

                entity.Property(e => e.Imagen)
                    .HasColumnType("image")
                    .HasColumnName("imagen");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(14, 2)")
                    .HasColumnName("precio");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.HasOne(d => d.IdTipoPeliculaNavigation)
                    .WithMany(p => p.Peliculas)
                    .HasForeignKey(d => d.IdTipoPelicula)
                    .HasConstraintName("FK_Peliculas_TipoPelicula");
            });

            modelBuilder.Entity<TipoPelicula>(entity =>
            {
                entity.HasKey(e => e.IdTipoPelicula);

                entity.ToTable("TipoPelicula");

                entity.Property(e => e.IdTipoPelicula).HasColumnName("idTipoPelicula");

                entity.Property(e => e.EstadoTipoPelicula).HasColumnName("estadoTipoPelicula");

                entity.Property(e => e.TipoPelicula1)
                    .HasMaxLength(100)
                    .HasColumnName("tipoPelicula");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Apellidos).HasMaxLength(125);

                entity.Property(e => e.Contrasena).HasMaxLength(25);

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(150)
                    .HasColumnName("correoElectronico");

                entity.Property(e => e.Dui).HasMaxLength(10);

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(250)
                    .HasColumnName("nombreCompleto");

                entity.Property(e => e.Nombres).HasMaxLength(125);

                entity.Property(e => e.TelefonoContacto)
                    .HasMaxLength(15)
                    .HasColumnName("telefonoContacto");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
