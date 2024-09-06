using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
namespace WebApplication3.model
{
    public class Mydbcontext:DbContext
    {
        public Mydbcontext(DbContextOptions option) : base(option)
        {

        }
        public DbSet<RegTable> RegTables { get; set; }
    }
}
