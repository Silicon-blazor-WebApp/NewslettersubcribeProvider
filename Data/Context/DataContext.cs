using Data.Entites;
using Microsoft.EntityFrameworkCore;


namespace Data.Context
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<SubscribeEntity> NewsSubscribers { get; set; }
    }
}
