using SP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Infra.Data.EntityConfig
{
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            HasKey(f => f.ClienteId);

            Property(f => f.Nome)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(150);

            Property(f => f.Bairro)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100);

            Property(f => f.Cidade)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100);

            Property(f => f.Estado)
                .IsRequired()
                .HasColumnType("char")
                .HasMaxLength(2);

            ToTable("Clientes");   
        }
    }
}
