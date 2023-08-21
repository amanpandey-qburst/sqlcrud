using Microsoft.EntityFrameworkCore;
using sqlcrud.Model;
using System.Collections.Generic;

namespace sqlcrud.Data
{
    public class CompanyDbContext : DbContext
    {

        public CompanyDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }


        public DbSet<CompanyList> CompanyData { get; set; }
    }
}
