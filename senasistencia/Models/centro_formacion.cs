namespace senasistencia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class centro_formacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public centro_formacion()
        {
            sede = new HashSet<sede>();
        }

        [Key]
        public long ID_Centro { get; set; }

        [Required]
        [StringLength(60)]
        public string Nombre_Centro { get; set; }

        [StringLength(60)]
        public string Direccion_Centro { get; set; }

        public long? Telefono_Centro { get; set; }

        public bool Estado_Centro { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaDeCreacion_Centro { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaDeInactivacion_Centro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sede> sede { get; set; }
    }
}
