using Lam_Demo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lam_Demo.Data
{
    public class DataContext: IdentityDbContext<NhanVien>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<NguyenLieu> NguyenLieus { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
