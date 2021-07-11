using System;
using Microsoft.EntityFrameworkCore;
using webapp.Models;

namespace webapp.DBContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            
        }
        public DbSet<BookingDetails> BookingDetails { get; set; }
    }
}
