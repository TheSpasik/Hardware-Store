using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Storage
{
    public partial class StorageContext : DbContext
    {
        public StorageContext()
            : base("name=StorageContext")
        {
        }

        public virtual DbSet<Admil_Panel> Admil_Panel { get; set; }
        public virtual DbSet<Buy> Buy { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Sell> Sell { get; set; }
        public virtual DbSet<Shipper> Shipper { get; set; }
        public virtual DbSet<Storage> Storage { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admil_Panel>()
                .Property(e => e.Confirmed)
                .IsUnicode(false);

            modelBuilder.Entity<Admil_Panel>()
                .Property(e => e.Info)
                .IsUnicode(false);

            modelBuilder.Entity<Buy>()
                .Property(e => e.Name_Buy)
                .IsUnicode(false);

            modelBuilder.Entity<Buy>()
                .Property(e => e.Maker_Buy)
                .IsUnicode(false);

            modelBuilder.Entity<Buy>()
                .Property(e => e.Type_Buy)
                .IsUnicode(false);

            modelBuilder.Entity<Buy>()
                .Property(e => e.Price_Buy)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Buy>()
                .Property(e => e.Amount_Buy)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Name_Client)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Address_Client)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Phone_Client)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Admil_Panel)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sell>()
                .Property(e => e.Name_Sell)
                .IsUnicode(false);

            modelBuilder.Entity<Sell>()
                .Property(e => e.Maker_Sell)
                .IsUnicode(false);

            modelBuilder.Entity<Sell>()
                .Property(e => e.Type_Sell)
                .IsUnicode(false);

            modelBuilder.Entity<Sell>()
                .Property(e => e.Price_Sell)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Sell>()
                .Property(e => e.Amount_Sell)
                .IsUnicode(false);

            modelBuilder.Entity<Sell>()
                .HasMany(e => e.Admil_Panel)
                .WithRequired(e => e.Sell)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shipper>()
                .Property(e => e.Name_Shipper)
                .IsUnicode(false);

            modelBuilder.Entity<Shipper>()
                .Property(e => e.Address_Shipper)
                .IsUnicode(false);

            modelBuilder.Entity<Shipper>()
                .Property(e => e.Phone_Shipper)
                .IsUnicode(false);

            modelBuilder.Entity<Storage>()
                .Property(e => e.Name_Storage)
                .IsUnicode(false);

            modelBuilder.Entity<Storage>()
                .Property(e => e.Maker_Storage)
                .IsUnicode(false);

            modelBuilder.Entity<Storage>()
                .Property(e => e.Type_Storage)
                .IsUnicode(false);

            modelBuilder.Entity<Storage>()
                .Property(e => e.Price_Storage)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Storage>()
                .Property(e => e.Amount_Storage)
                .IsUnicode(false);
        }
    }
}
