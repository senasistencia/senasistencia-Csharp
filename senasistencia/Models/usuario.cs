namespace senasistencia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("usuario")]
    public partial class usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usuario()
        {
            password_token = new HashSet<password_token>();
        }

        [Key]
        public long ID_Usuario { get; set; }

        public long ID_DocumentoCliente { get; set; }

        [Required]
        [StringLength(100)]
        public string Password_Hash { get; set; }

        [Column(TypeName = "date")]
        public DateTime Caducidad_Password { get; set; }

        public bool Estado_Usuario { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaDeCreacion_Usuario { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaDeInactivacion_Usuario { get; set; }

        public virtual cliente cliente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<password_token> password_token { get; set; }
    }
}
