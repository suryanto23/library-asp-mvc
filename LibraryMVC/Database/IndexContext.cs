using LibraryMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryMVC.Database
{
    public class IndexContext : DbContext
    {
        public DbSet<BookModel> Books { get; set; }
        public DbSet<TransactionModel> Transactions { get; set; }

        private readonly IConfiguration _configuration;
        public IndexContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(_configuration.GetConnectionString("defaultDbConfig"));
        }
    }
}
