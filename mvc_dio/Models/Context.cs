using Microsoft.EntityFrameworkCore;
using System;

namespace mvc_dio.Models
{
    public class Context : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\mssqllocaldb;Database=cursomvc;Integrated Security=True");
        }

        public virtual void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
       
    }
}
