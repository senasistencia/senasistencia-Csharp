namespace senasistencia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class programa_formacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public programa_formacion()
        {
            ficha = new HashSet<ficha>();
        }

        [Key]
        public long ID_Programa { get; set; }

        [Required]
        [StringLength(60)]
        public string Nombre { get; set; }

        public bool Estado_Programa { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaDeCreacion_Programa { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaDeInactivacion_Programa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ficha> ficha { get; set; }
    }
}
