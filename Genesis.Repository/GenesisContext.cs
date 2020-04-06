namespace Genesis.Repository
{
    using Genesis.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class GenesisContext: DbContext
    {
        public GenesisContext()
            : base("name=GenesisModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        //public DbSet<Employee> Employees { get; set; }
        //public DbSet<Freelancer> Freelancers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Contact>()
            //    .HasMany(c => c.CompanyList)
            //    .WithMany(c => c.ContactList)
            //    .Map(x =>
            //    {
            //        x.MapLeftKey("ContactId");
            //        x.MapRightKey("CompanyId");
            //        x.ToTable("ContactCompanies");
            //    });

            base.OnModelCreating(modelBuilder);
        }
    }
}