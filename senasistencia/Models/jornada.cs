namespace senasistencia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("jornada")]
    public partial class jornada
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public jornada()
        {
            ficha = new HashSet<ficha>();
        }

        [Key]
        public long ID_Jornada { get; set; }

        [Required]
        [StringLength(60)]
        public string Descripcion_Jornada { get; set; }

        public bool Estado_Jornada { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaDeCreacion_Jornada { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaDeInactivacion_Jornada { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ficha> ficha { get; set; }
    }
}
