namespace Storage
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Shipper")]
    public partial class Shipper
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shipper()
        {
            Buy = new HashSet<Buy>();
        }

        [Key]
        public int ID_Shipper { get; set; }

        [Required]
        [StringLength(100)]
        public string Name_Shipper { get; set; }

        [Required]
        [StringLength(100)]
        public string Address_Shipper { get; set; }

        [Required]
        [StringLength(100)]
        public string Phone_Shipper { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Buy> Buy { get; set; }
    }
}
