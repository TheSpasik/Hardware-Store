namespace Storage
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Admil_Panel
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Client { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Sell { get; set; }

        [Required]
        [StringLength(50)]
        public string Confirmed { get; set; }

        [Required]
        [StringLength(300)]
        public string Info { get; set; }

        public virtual Client Client { get; set; }

        public virtual Sell Sell { get; set; }
    }
}
