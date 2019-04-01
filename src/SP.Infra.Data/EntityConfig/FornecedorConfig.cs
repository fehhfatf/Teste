using SP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Infra.Data.EntityConfig
{
    public class FornecedorConfig : EntityTypeConfiguration<Fornecedor>
    {
        public FornecedorConfig()
        {
            HasKey(f => f.FornecedorId);

            Property(f => f.Nome)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(150);

            ToTable("Fornecedores");
        }
    }
}
