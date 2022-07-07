namespace Storage
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Storage")]
    public partial class Storage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Storage()
        {
            Buy = new HashSet<Buy>();
            Sell = new HashSet<Sell>();
        }

        [Key]
        public int ID_Storage { get; set; }

        [Required]
        [StringLength(100)]
        public string Name_Storage { get; set; }

        [Required]
        [StringLength(100)]
        public string Maker_Storage { get; set; }

        [Required]
        [StringLength(100)]
        public string Type_Storage { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Price_Storage { get; set; }

        [Required]
        [StringLength(100)]
        public string Amount_Storage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Buy> Buy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sell> Sell { get; set; }
    }
}
