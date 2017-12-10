namespace senasistencia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("asistencia")]
    public partial class asistencia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public asistencia()
        {
            Formato_Ftp = new HashSet<Formato_Ftp>();
        }

        [Key]
        public long ID_Asistencia { get; set; }

        public long ID_DocumentoAprendiz { get; set; }

        public bool Descripcion_Asistencia { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fecha_Asistencia { get; set; }

        public bool Estado_Asistencia { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaDeCreacion_Asistencia { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaDeInactivacion_Asistencia { get; set; }

        public virtual aprendiz aprendiz { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Formato_Ftp> Formato_Ftp { get; set; }
    }
}
