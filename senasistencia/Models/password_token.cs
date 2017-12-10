namespace senasistencia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class password_token
    {
        [Key]
        public long ID_Token { get; set; }

        [Required]
        [StringLength(60)]
        public string Token_Hash { get; set; }

        public long ID_Usuario { get; set; }

        public bool Estado_Token { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaDeCreacion_Token { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaDeInactivacion_Token { get; set; }

        public virtual usuario usuario { get; set; }
    }
}
