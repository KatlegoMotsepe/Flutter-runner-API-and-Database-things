
using Microsoft.EntityFrameworkCore;


namespace Flutter_runnner
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<SessionsDetails> SessionsD { get; set; }

        public DbSet<SessionStatscs> SessionS { get; set; }


        public DbSet<Entries> Entries { get; set; }

        public static readonly DbContextOptions<DataContext> options ;
        static DataContext()
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile("appsettings.json")
               .Build();
            options = new DbContextOptionsBuilder<DataContext>()
               .UseSqlServer(config.GetConnectionString("db"))
               .Options;
        }
       
        public DataContext(): base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
            options
                .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Flutter_runner;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating (ModelBuilder dbModelBuilder)
        {
            base.OnModelCreating(dbModelBuilder);
            

            dbModelBuilder.Entity<User>().ToTable("Users_tbl");

            dbModelBuilder.Entity<SessionsDetails>().ToTable("SessionsDetails_tbl");

            dbModelBuilder.Entity<SessionStatscs>().ToTable("SessionStatscs_tbl");

            dbModelBuilder.Entity<Entries>().ToTable("Entries_tbl");


            dbModelBuilder.Entity<Entries>()
       .HasOne(e => e.User)
       .WithMany()
       .HasForeignKey(e => e.user_id)
       .IsRequired();

            dbModelBuilder.Entity<Entries>()
                .HasOne(e => e.SessionStatscs)
                .WithMany()
                .HasForeignKey(e => e.stats_id);

            dbModelBuilder.Entity<Entries>()
                .HasOne(e => e.SessionsDetails)
                .WithMany()
                .HasForeignKey(e => e.details_id);
        }
        static public void init()
        {
            using var db = new DataContext();   
        }

    }
}

