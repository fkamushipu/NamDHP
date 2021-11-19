namespace Namdhp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class namdhp : DbContext
    {
        public namdhp()
            : base("name=namdhp")
        {
        }

        public virtual DbSet<appointment> appointments { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<admin> admins { get; set; }
        public virtual DbSet<Vaccine> Vaccines { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<appointment>()
                .Property(e => e.reason)
                .IsUnicode(false);

            modelBuilder.Entity<appointment>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.gender)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.cellphone)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.marital_status)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.guardian_name)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.guardian_contact)
                .IsUnicode(false);
            

            modelBuilder.Entity<user>()
                .Property(e => e.known_allergies)
                .IsUnicode(false);

            modelBuilder.Entity<admin>()
           .Property(e => e.admin_name)
           .IsUnicode(false);

            modelBuilder.Entity<admin>()
                .Property(e => e.admin_lastname)
                .IsUnicode(false);

            modelBuilder.Entity<admin>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<admin>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<admin>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<admin>()
                .Property(e => e.password)
                .IsUnicode(false);


            modelBuilder.Entity<Vaccine>()
               .Property(e => e.vaccine_name)
               .IsUnicode(false);

            modelBuilder.Entity<Vaccine>()
                .Property(e => e.manufacture)
                .IsUnicode(false);

            modelBuilder.Entity<Vaccine>()
                .Property(e => e.side_effects)
                .IsUnicode(false);

            modelBuilder.Entity<Vaccine>()
                .Property(e => e.general_information)
                .IsUnicode(false);

        }
    }
}
