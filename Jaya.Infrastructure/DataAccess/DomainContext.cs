using Jaya.Domain.Issues.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Jaya.Infrastructure.DataAccess
{
    public class DomainContext : DbContext
    {
        public DomainContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Issue> Issues { get; set; }

    }
}
