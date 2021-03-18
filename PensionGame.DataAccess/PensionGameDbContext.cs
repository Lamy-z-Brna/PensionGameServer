using Microsoft.EntityFrameworkCore;
using PensionGame.DataAccess.Data_Objects.ClientData;
using PensionGame.DataAccess.Data_Objects.GameData;
using PensionGame.DataAccess.Data_Objects.Holdings;
using PensionGame.DataAccess.Data_Objects.Session;

namespace PensionGame.DataAccess
{
    public class PensionGameDbContext : DbContext
    {
        public PensionGameDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Session>? Sessions { get; set; }
        public DbSet<GameState>? GameStates { get; set; }
        public DbSet<ClientData>? ClientData { get; set; }
        public DbSet<ExpenseData>? ExpenseData { get; set; }
        public DbSet<IncomeData>? IncomeData { get; set; }
        public DbSet<BondHolding>? BondHoldings { get; set; }
        public DbSet<ClientHoldings>? ClientHoldings { get; set; }
        public DbSet<LoanHolding>? LoanHoldings { get; set; }
        public DbSet<SavingsAccountHolding>? SavingsAccountHoldings { get; set; }
        public DbSet<StockHolding>? StocksHoldings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Session>().HasIndex(s => s.Id).IsUnique();
            //modelBuilder.Entity<GameState>().HasIndex()
        }
    }
}
