using BankAccounManager.Model;
using Microsoft.EntityFrameworkCore;

namespace BankAccounManager.Database
{
    public class BankAccountDbContext : DbContext
    {
        public BankAccountDbContext(DbContextOptions options) : base(options)
        {
        }

        //DbSet
        public DbSet<BankAccount> bankAccounts { get; set; }
    }
}
