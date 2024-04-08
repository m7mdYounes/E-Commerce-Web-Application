namespace E_Commerce.Models
{
    public class StoreContext:IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Products { get; set; } 
        //public DbSet<Customer> Customers { get; set; }
        public DbSet<Catalogue> Catalogs { get; set; }
       // public DbSet<Order> Orders { get; set; }
        public DbSet<Cart>  Carts { get; set; }
      //  public DbSet<Admin> Admins { get; set; }
        public DbSet<ApplicationUser> applicationUsers { get; set; }
        public StoreContext():base()
        {
            
        }
        public StoreContext(DbContextOptions<StoreContext> options):base(options){}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=Store;Trusted_Connection=True;TrustServerCertificate=True");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>()
                .HasOne(c => c.product)
                .WithMany(p => p.carts)
                .HasForeignKey(c => c.productID);
            base.OnModelCreating(modelBuilder);
        }

    }
}
