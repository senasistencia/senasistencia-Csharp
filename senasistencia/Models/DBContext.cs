namespace senasistencia.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<ambiente_formacion> ambiente_formacion { get; set; }
        public virtual DbSet<aprendiz> aprendiz { get; set; }
        public virtual DbSet<asistencia> asistencia { get; set; }
        public virtual DbSet<cargo> cargo { get; set; }
        public virtual DbSet<centro_formacion> centro_formacion { get; set; }
        public virtual DbSet<cliente> cliente { get; set; }
        public virtual DbSet<excusa> excusa { get; set; }
        public virtual DbSet<ficha> ficha { get; set; }
        public virtual DbSet<Formato_Ftp> Formato_Ftp { get; set; }
        public virtual DbSet<jornada> jornada { get; set; }
        public virtual DbSet<notificacion> notificacion { get; set; }
        public virtual DbSet<password_token> password_token { get; set; }
        public virtual DbSet<perfil> perfil { get; set; }
        public virtual DbSet<programa_formacion> programa_formacion { get; set; }
        public virtual DbSet<sede> sede { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tipo_documento> tipo_documento { get; set; }
        public virtual DbSet<trimestre> trimestre { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ambiente_formacion>()
                .HasMany(e => e.ficha)
                .WithRequired(e => e.ambiente_formacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<aprendiz>()
                .Property(e => e.Nombre_Aprendiz)
                .IsUnicode(false);

            modelBuilder.Entity<aprendiz>()
                .Property(e => e.Apellido_Aprendiiz)
                .IsUnicode(false);

            modelBuilder.Entity<aprendiz>()
                .Property(e => e.Correo_Aprendiz)
                .IsUnicode(false);

            modelBuilder.Entity<aprendiz>()
                .HasMany(e => e.asistencia)
                .WithRequired(e => e.aprendiz)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<aprendiz>()
                .HasMany(e => e.excusa)
                .WithRequired(e => e.aprendiz)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<aprendiz>()
                .HasMany(e => e.notificacion)
                .WithRequired(e => e.aprendiz)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<asistencia>()
                .HasMany(e => e.Formato_Ftp)
                .WithRequired(e => e.asistencia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<cargo>()
                .Property(e => e.Tipo_Cargo)
                .IsUnicode(false);

            modelBuilder.Entity<cargo>()
                .HasMany(e => e.cliente)
                .WithRequired(e => e.cargo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<centro_formacion>()
                .Property(e => e.Nombre_Centro)
                .IsUnicode(false);

            modelBuilder.Entity<centro_formacion>()
                .Property(e => e.Direccion_Centro)
                .IsUnicode(false);

            modelBuilder.Entity<centro_formacion>()
                .HasMany(e => e.sede)
                .WithRequired(e => e.centro_formacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.PrimerNombre_Cliente)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.SegundoNombre_Cliente)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.PrimerApellido_Cliente)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.SegundoApellido_Cliente)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.Correo_Cliente)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .HasMany(e => e.notificacion)
                .WithRequired(e => e.cliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<cliente>()
                .HasMany(e => e.usuario)
                .WithRequired(e => e.cliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ficha>()
                .HasMany(e => e.aprendiz)
                .WithRequired(e => e.ficha)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formato_Ftp>()
                .Property(e => e.Nombre_Formato)
                .IsUnicode(false);

            modelBuilder.Entity<Formato_Ftp>()
                .Property(e => e.Url_Ftp)
                .IsUnicode(false);

            modelBuilder.Entity<Formato_Ftp>()
                .HasMany(e => e.notificacion)
                .WithRequired(e => e.Formato_Ftp)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<jornada>()
                .Property(e => e.Descripcion_Jornada)
                .IsUnicode(false);

            modelBuilder.Entity<jornada>()
                .HasMany(e => e.ficha)
                .WithRequired(e => e.jornada)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<notificacion>()
                .Property(e => e.Mensaje_Notificacion)
                .IsUnicode(false);

            modelBuilder.Entity<password_token>()
                .Property(e => e.Token_Hash)
                .IsUnicode(false);

            modelBuilder.Entity<perfil>()
                .Property(e => e.Perfil1)
                .IsUnicode(false);

            modelBuilder.Entity<perfil>()
                .HasMany(e => e.cliente)
                .WithRequired(e => e.perfil)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<programa_formacion>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<programa_formacion>()
                .HasMany(e => e.ficha)
                .WithRequired(e => e.programa_formacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sede>()
                .Property(e => e.Nombre_Sede)
                .IsUnicode(false);

            modelBuilder.Entity<sede>()
                .Property(e => e.Direccion_Sede)
                .IsUnicode(false);

            modelBuilder.Entity<sede>()
                .HasMany(e => e.ambiente_formacion)
                .WithRequired(e => e.sede)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tipo_documento>()
                .Property(e => e.Nombre_TipoDeDocumento)
                .IsUnicode(false);

            modelBuilder.Entity<tipo_documento>()
                .Property(e => e.Nomenclatura_TipoDeDocumento)
                .IsUnicode(false);

            modelBuilder.Entity<tipo_documento>()
                .HasMany(e => e.aprendiz)
                .WithRequired(e => e.tipo_documento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tipo_documento>()
                .HasMany(e => e.cliente)
                .WithRequired(e => e.tipo_documento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<trimestre>()
                .HasMany(e => e.ficha)
                .WithRequired(e => e.trimestre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.Password_Hash)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .HasMany(e => e.password_token)
                .WithRequired(e => e.usuario)
                .WillCascadeOnDelete(false);
        }
    }
}
