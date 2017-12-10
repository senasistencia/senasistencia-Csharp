namespace senasistencia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("excusa")]
    public partial class excusa
    {
        [Key]
        public long ID_Excusa { get; set; }

        public long ID_DocumentoAprendiz { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fecha_Excusa { get; set; }

        [Column(TypeName = "date")]
        public DateTime Periodo_Excusa { get; set; }

        public bool Estado_Excusa { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaDeCreacion_Excusa { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaDeInactivacion_Excusa { get; set; }

        public virtual aprendiz aprendiz { get; set; }
    }
}
