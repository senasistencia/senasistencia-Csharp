namespace senasistencia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("trimestre")]
    public partial class trimestre
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public trimestre()
        {
            ficha = new HashSet<ficha>();
        }

        [Key]
        public long ID_Trimestre { get; set; }

        public long Num_Trimestre { get; set; }

        public long Estado_Trimestre { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaDeCreacion_Trimestre { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaDeInactivacion_Trimestre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ficha> ficha { get; set; }
    }
}
