using Microsoft.EntityFrameworkCore;

namespace MonkeyFinder.Data;

public class MonkeyContext : DbContext
{
    public DbSet<Monkey> Monkeys
    {
        get; set;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlite("DataSource=Monkeys.db");
    }
}