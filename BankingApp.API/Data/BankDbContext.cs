using Microsoft.EntityFrameworkCore;
using BankingApp.API.Models;
namespace BankingApp.API.Data;

public class BankDbContext : DbContext
{
    public BankDbContext(DbContextOptions<BankDbContext> options) : base(options)
    {
        
    }

    public DbSet<BankAccount> BankAccounts { get; set;}
}