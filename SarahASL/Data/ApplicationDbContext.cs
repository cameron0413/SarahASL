using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SarahASL.Models;

namespace SarahASL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ASLUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SarahASL.Models.ASLTerm> ASLTerm { get; set; }
        public DbSet<SarahASL.Models.Tag> Tag { get; set; }
    }
}