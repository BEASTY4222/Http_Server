using Microsoft.EntityFrameworkCore;
using Utilities;

namespace Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // This represents your table
    public DbSet<MyJsonUser> Users => Set<MyJsonUser>();
}