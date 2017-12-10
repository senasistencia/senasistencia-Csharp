namespace senasistencia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sede")]
    public partial class sede
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sede()
        {
            ambiente_formacion = new HashSet<ambiente_formacion>();
        }

        [Key]
        public long ID_Sede { get; set; }

        [Required]
        [StringLength(60)]
        public string Nombre_Sede { get; set; }

        [StringLength(60)]
        public string Direccion_Sede { get; set; }

        public long? Telefono { get; set; }

        public long ID_Centro { get; set; }

        public bool Estado_sede { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaDeCreacion_Sede { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaDeInactivacion_Sede { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ambiente_formacion> ambiente_formacion { get; set; }

        public virtual centro_formacion centro_formacion { get; set; }
    }
}
