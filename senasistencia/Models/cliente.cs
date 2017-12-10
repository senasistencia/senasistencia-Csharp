namespace senasistencia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cliente")]
    public partial class cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cliente()
        {
            notificacion = new HashSet<notificacion>();
            usuario = new HashSet<usuario>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID_DocumentoCliente { get; set; }

        public long ID_Tipo_Documento { get; set; }

        [Required]
        [StringLength(60)]
        public string PrimerNombre_Cliente { get; set; }

        [Required]
        [StringLength(60)]
        public string SegundoNombre_Cliente { get; set; }

        [Required]
        [StringLength(60)]
        public string PrimerApellido_Cliente { get; set; }

        [Required]
        [StringLength(60)]
        public string SegundoApellido_Cliente { get; set; }

        [Required]
        [StringLength(60)]
        public string Correo_Cliente { get; set; }

        public long Telefono_Cliente { get; set; }

        public long ID_Cargo { get; set; }

        public long ID_Perfil { get; set; }

        public bool Estado_Cliente { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaDeCreacion_Cliente { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaDeInactivacion_Cliente { get; set; }

        public virtual cargo cargo { get; set; }

        public virtual perfil perfil { get; set; }

        public virtual tipo_documento tipo_documento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<notificacion> notificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuario> usuario { get; set; }
    }
}
