
using Homework.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Homework.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {
        }

        //public DbSet<Domain name> Table Name { get; set; } <= เพื่อใช้คำสั่ง migration สร้างตารางในฐานข้อมูล

        public DbSet<Register> Registers { get; set; } 
        public DbSet<Adduser> AddUsers { get; set; } 
        public DbSet<Role> Roles { get; set; } 
        public DbSet<Permission> Permissions { get; set; } 
        
    }
}
