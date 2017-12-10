namespace senasistencia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ficha")]
    public partial class ficha
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ficha()
        {
            aprendiz = new HashSet<aprendiz>();
        }

        [Key]
        public long ID_Ficha { get; set; }

        public long Num_Ficha { get; set; }

        public long ID_Ambiente { get; set; }

        public long ID_Trimestre { get; set; }

        public long ID_Programa { get; set; }

        public long ID_Jornada { get; set; }

        public bool Estado { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaDeCreacion_Ficha { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaDeInactivacion_Ficha { get; set; }

        public virtual ambiente_formacion ambiente_formacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<aprendiz> aprendiz { get; set; }

        public virtual jornada jornada { get; set; }

        public virtual programa_formacion programa_formacion { get; set; }

        public virtual trimestre trimestre { get; set; }
    }
}
