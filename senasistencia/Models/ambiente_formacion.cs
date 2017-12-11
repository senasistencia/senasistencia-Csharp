namespace senasistencia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ambiente_formacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ambiente_formacion()
        {
            ficha = new HashSet<ficha>();
        }

        [Key]
        public long ID_Ambiente { get; set; }
        [Display(Name = "Numero de ambiente")]
        public long Num_Ambiente { get; set; }
        [Display(Name = "Sede")]
        public long ID_Sede { get; set; }
        [Display(Name = "Estado Ambiente")]
        public bool Estado_Ambiente { get; set; }
        [Display(Name = "Fecha de Creacion")]
        [Column(TypeName = "date")]
        public DateTime FechaDeCreacion_Ambiente { get; set; }
        [Display(Name = "Fecha de Inactivacion")]
        [Column(TypeName = "date")]
        public DateTime? FechaDeInactivacion_Ambiente { get; set; }

        public virtual sede sede { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ficha> ficha { get; set; }
    }
}
