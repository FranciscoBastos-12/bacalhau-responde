using Domain.Entities;
using Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class DataContext : DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
        }
    }
}
