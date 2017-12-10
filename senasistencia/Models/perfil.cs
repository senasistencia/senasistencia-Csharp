namespace senasistencia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("perfil")]
    public partial class perfil
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public perfil()
        {
            cliente = new HashSet<cliente>();
        }

        [Key]
        public long ID_Perfil { get; set; }

        [Column("Perfil")]
        [Required]
        [StringLength(60)]
        public string Perfil1 { get; set; }

        public bool Estado_Perfil { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaDeCreacion_Perfil { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaDeInactivacion_Perfil { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cliente> cliente { get; set; }
    }
}
