namespace senasistencia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("aprendiz")]
    public partial class aprendiz
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public aprendiz()
        {
            asistencia = new HashSet<asistencia>();
            excusa = new HashSet<excusa>();
            notificacion = new HashSet<notificacion>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Numero de Identificacion")]
        public long ID_DocumentoAprendiz { get; set; }

        public long ID_Tipo_Documento { get; set; }

        [Required]
        [StringLength(60)]
        public string Nombre_Aprendiz { get; set; }

        [Required]
        [StringLength(60)]
        public string Apellido_Aprendiiz { get; set; }

        [Required]
        [StringLength(60)]
        public string Correo_Aprendiz { get; set; }

        public long? Telefono_Aprendiz { get; set; }

        public long ID_Ficha { get; set; }

        public bool Estado_Aprendiz { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaDeCreacion_Aprendiz { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaDeInactivacion_Aprendiz { get; set; }

        public virtual ficha ficha { get; set; }

        public virtual tipo_documento tipo_documento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<asistencia> asistencia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<excusa> excusa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<notificacion> notificacion { get; set; }
    }
}
