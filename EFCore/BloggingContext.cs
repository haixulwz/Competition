using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore
{
    public class BloggingContext:DbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> options):base(options)
        {

        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          //  optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=WebBloggingDB; User=root;Password=123456;");
          //  base.OnConfiguring(optionsBuilder); 
        }
    }
}
