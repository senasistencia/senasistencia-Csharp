namespace senasistencia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("notificacion")]
    public partial class notificacion
    {
        [Key]
        public long ID_Notificacion { get; set; }

        [Required]
        [StringLength(500)]
        public string Mensaje_Notificacion { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }

        public long ID_formato { get; set; }

        public long ID_DocumentoAprendiz { get; set; }

        public long ID_DocumentoCliente { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaDeCreacion_Notificacion { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaDeInactivacion_Notificacion { get; set; }

        public virtual aprendiz aprendiz { get; set; }

        public virtual cliente cliente { get; set; }

        public virtual Formato_Ftp Formato_Ftp { get; set; }
    }
}
