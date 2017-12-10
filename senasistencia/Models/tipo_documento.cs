namespace senasistencia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tipo_documento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tipo_documento()
        {
            aprendiz = new HashSet<aprendiz>();
            cliente = new HashSet<cliente>();
        }

        [Key]
        public long ID_Tipo_Documento { get; set; }

        [Required]
        [StringLength(30)]
        public string Nombre_TipoDeDocumento { get; set; }

        [Required]
        [StringLength(3)]
        public string Nomenclatura_TipoDeDocumento { get; set; }

        public bool Estado_TipoDeDocumento { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaDeCreacion_Doc { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaDeInactivacion_Doc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<aprendiz> aprendiz { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cliente> cliente { get; set; }
    }
}
