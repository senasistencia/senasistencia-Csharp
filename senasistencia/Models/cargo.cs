namespace senasistencia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cargo")]
    public partial class cargo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cargo()
        {
            cliente = new HashSet<cliente>();
        }

        [Key]
        public long ID_Cargo { get; set; }

        [Required]
        [StringLength(60)]
        public string Tipo_Cargo { get; set; }

        public bool Estado_Cargo { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaDeCreacion_Cargo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaDeInactivacion_Cargo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cliente> cliente { get; set; }
    }
}
