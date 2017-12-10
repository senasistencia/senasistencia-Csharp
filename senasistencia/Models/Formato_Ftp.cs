namespace senasistencia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Formato_Ftp
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Formato_Ftp()
        {
            notificacion = new HashSet<notificacion>();
        }

        [Key]
        public long ID_formato { get; set; }

        [StringLength(60)]
        public string Nombre_Formato { get; set; }

        [StringLength(500)]
        public string Url_Ftp { get; set; }

        public long ID_Asistencia { get; set; }

        public bool Estado_Formato { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaDeCreacion_Formato { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaDeInactivacion_Formato { get; set; }

        public virtual asistencia asistencia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<notificacion> notificacion { get; set; }
    }
}
