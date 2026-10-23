using Credisis.Estudos.Domain.Models.Cliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Credisis.Estudos.Infra.Data.Mapping
{
    internal class ClientesMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(100);
        }
    }
}
