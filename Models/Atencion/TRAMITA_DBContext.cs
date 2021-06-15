using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebAuthent.Models.Atencion
{
    
    public partial class TRAMITA_DBContext : DbContext
    {
        public TRAMITA_DBContext()
        {
        }

        public TRAMITA_DBContext(DbContextOptions<TRAMITA_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CatEmpleado> CatEmpleados { get; set; }
        public virtual DbSet<CatGrupoEmpledo> CatGrupoEmpledos { get; set; }
        public virtual DbSet<CatGrupoMunicipio> CatGrupoMunicipios { get; set; }
        public virtual DbSet<CatGruposAtencion> CatGruposAtencions { get; set; }
        public virtual DbSet<CatGruposSede> CatGruposSedes { get; set; }
        public virtual DbSet<CatMunicipio> CatMunicipios { get; set; }
        public virtual DbSet<CatMunicipioAtencion> CatMunicipioAtencions { get; set; }
        public virtual DbSet<CatSede> CatSedes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-C7DO8APT\\SQLEXPRESS;Database=TRAMITA_DB;Trusted_Connection=True; User ID=sa; Password=bebeto74;MultipleActiveResultSets=True;App=EntityFramework");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<CatEmpleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado);

                entity.ToTable("cat_empleados");

                entity.Property(e => e.IdEmpleado)
                    .ValueGeneratedNever()
                    .HasColumnName("id_empleado");

                entity.Property(e => e.ApellidoMaterno)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("apellido_materno");

                entity.Property(e => e.ApellidoPaterno)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("apellido_paterno");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("contraseña");

                entity.Property(e => e.IdMunicipio).HasColumnName("id_municipio");

                entity.Property(e => e.IdSede).HasColumnName("id_sede");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("usuario");

                entity.HasOne(d => d.IdMunicipioNavigation)
                    .WithMany(p => p.CatEmpleados)
                    .HasForeignKey(d => d.IdMunicipio)
                    .HasConstraintName("FK__cat_emple__id_mu__40106F4B");

                entity.HasOne(d => d.IdSedeNavigation)
                    .WithMany(p => p.CatEmpleados)
                    .HasForeignKey(d => d.IdSede)
                    .HasConstraintName("FK__cat_emple__id_se__3F1C4B12");
            });

            modelBuilder.Entity<CatGrupoEmpledo>(entity =>
            {
                entity.HasKey(e => new { e.IdGpoAtencion, e.IdEmpleado })
                    .HasName("PK__cat_grup__AAF48AD57E75D90B");

                entity.ToTable("cat_grupo_empleado");

                entity.Property(e => e.IdGpoAtencion).HasColumnName("id_gpo_atencion");

                entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.CatGrupoEmpledos)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cat_grupo__id_em__43E1002F");

                entity.HasOne(d => d.IdGpoAtencionNavigation)
                    .WithMany(p => p.CatGrupoEmpledos)
                    .HasForeignKey(d => d.IdGpoAtencion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cat_grupo__id_em__42ECDBF6");
            });

            modelBuilder.Entity<CatGrupoMunicipio>(entity =>
            {
                entity.HasKey(e => new { e.IdGpoAtencion, e.IdMunicipio })
                    .HasName("PK__cat_grup__72634555514D9078");

                entity.ToTable("cat_grupo_municipio");

                entity.Property(e => e.IdGpoAtencion).HasColumnName("id_gpo_atencion");

                entity.Property(e => e.IdMunicipio).HasColumnName("id_municipio");

                entity.HasOne(d => d.IdGpoAtencionNavigation)
                    .WithMany(p => p.CatGrupoMunicipios)
                    .HasForeignKey(d => d.IdGpoAtencion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cat_grupo__id_gp__377B294A");

                entity.HasOne(d => d.IdMunicipioNavigation)
                    .WithMany(p => p.CatGrupoMunicipios)
                    .HasForeignKey(d => d.IdMunicipio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cat_grupo__id_mu__386F4D83");
            });

            modelBuilder.Entity<CatGruposAtencion>(entity =>
            {
                entity.HasKey(e => e.IdGpoAtencion);

                entity.ToTable("cat_grupos_atencion");

                entity.HasIndex(e => e.Nombre, "UQ__cat_grup__72AFBCC69DE2F773")
                    .IsUnique();

                entity.Property(e => e.IdGpoAtencion).HasColumnName("id_gpo_atencion");

                entity.Property(e => e.Descripcion)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<CatGruposSede>(entity =>
            {
                entity.HasKey(e => new { e.IdGpoAtencion, e.IdSede })
                    .HasName("PK__cat_grup__5F16EEE8E8544615");

                entity.ToTable("cat_grupos_sedes");

                entity.Property(e => e.IdGpoAtencion).HasColumnName("id_gpo_atencion");

                entity.Property(e => e.IdSede).HasColumnName("id_sede");

                entity.HasOne(d => d.IdGpoAtencionNavigation)
                    .WithMany(p => p.CatGruposSedes)
                    .HasForeignKey(d => d.IdGpoAtencion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cat_grupo__id_gp__3B4BBA2E");

                entity.HasOne(d => d.IdSedeNavigation)
                    .WithMany(p => p.CatGruposSedes)
                    .HasForeignKey(d => d.IdSede)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cat_grupo__id_se__3C3FDE67");
            });

            modelBuilder.Entity<CatMunicipio>(entity =>
            {
                entity.HasKey(e => e.IdMunicipio);

                entity.ToTable("cat_municipios");

                entity.Property(e => e.IdMunicipio).HasColumnName("id_municipio");

                entity.Property(e => e.Descripcion)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<CatMunicipioAtencion>(entity =>
            {
                entity.HasKey(e => new { e.IdMpioAtencion, e.IdMunicipio })
                    .HasName("PK_cat_municipio_atiende");

                entity.ToTable("cat_municipio_atencion");

                entity.Property(e => e.IdMpioAtencion).HasColumnName("id_mpio_atencion");

                entity.Property(e => e.IdMunicipio).HasColumnName("id_municipio");

                entity.HasOne(d => d.IdMpioAtencionNavigation)
                   .WithMany(p => p.CatMunicipioAtencionIdMpioAtencionNavigations)
                   .HasForeignKey(d => d.IdMpioAtencion)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK__cat_munic__id_mp__4999D985");

                entity.HasOne(d => d.IdMunicipioNavigation)
                    .WithMany(p => p.CatMunicipioAtencionIdMunicipioNavigations)
                    .HasForeignKey(d => d.IdMunicipio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cat_munic__id_mu__48A5B54C");

               
            });

            modelBuilder.Entity<CatSede>(entity =>
            {
                entity.HasKey(e => e.IdSede);

                entity.ToTable("cat_sedes");

                entity.Property(e => e.IdSede).HasColumnName("id_sede");

                entity.Property(e => e.Direccion)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.IdMunicipio).HasColumnName("id_municipio");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Responsable)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("responsable");

                entity.HasOne(d => d.IdMunicipioNavigation)
                    .WithMany(p => p.CatSedes)
                    .HasForeignKey(d => d.IdMunicipio)
                    .HasConstraintName("FK__cat_sedes__id_mu__31C24FF4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
