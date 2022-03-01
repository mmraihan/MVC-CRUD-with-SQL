using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRUDwithSQL.Models;

namespace CRUDwithSQL.Data
{
    public class CRUDwithSQLContext : DbContext
    {
        public CRUDwithSQLContext (DbContextOptions<CRUDwithSQLContext> options)
            : base(options)
        {
        }

        public DbSet<CRUDwithSQL.Models.BookViewModel> BookViewModel { get; set; }
    }
}
