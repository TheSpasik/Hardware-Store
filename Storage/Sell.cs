namespace Storage
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sell")]
    public partial class Sell
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sell()
        {
            Admil_Panel = new HashSet<Admil_Panel>();
        }

        [Key]
        public int ID_Sell { get; set; }

        public int ID_Storage { get; set; }

        public int ID_Client { get; set; }

        [Required]
        [StringLength(100)]
        public string Name_Sell { get; set; }

        [Required]
        [StringLength(100)]
        public string Maker_Sell { get; set; }

        [Required]
        [StringLength(100)]
        public string Type_Sell { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Price_Sell { get; set; }

        [Required]
        [StringLength(100)]
        public string Amount_Sell { get; set; }

        [Column(TypeName = "date")]
        public DateTime Data_Sell { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Admil_Panel> Admil_Panel { get; set; }

        public virtual Client Client { get; set; }

        public virtual Storage Storage { get; set; }
    }
}
