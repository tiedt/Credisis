using Credisis.Estudos.Domain.Models.Cliente;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Credisis.Estudos.Infra.Data
{
    public sealed class CredisisEstudosDbContext(DbContextOptions<CredisisEstudosDbContext> options) : DbContext(options)
    {
        public DbSet<Cliente> Clientes => Set<Cliente>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(new Mapping.ClientesMapping().Configure);
        }
    }
}
