namespace Storage
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Buy")]
    public partial class Buy
    {
        [Key]
        public int ID_Buy { get; set; }

        public int ID_Storage { get; set; }

        public int ID_Shipper { get; set; }

        [Required]
        [StringLength(100)]
        public string Name_Buy { get; set; }

        [Required]
        [StringLength(100)]
        public string Maker_Buy { get; set; }

        [Required]
        [StringLength(100)]
        public string Type_Buy { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Price_Buy { get; set; }

        [Required]
        [StringLength(100)]
        public string Amount_Buy { get; set; }

        [Column(TypeName = "date")]
        public DateTime Data_Buy { get; set; }

        public virtual Shipper Shipper { get; set; }

        public virtual Storage Storage { get; set; }
    }
}
