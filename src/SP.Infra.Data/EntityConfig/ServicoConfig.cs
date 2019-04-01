using SP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Infra.Data.EntityConfig
{
    public class ServicoConfig : EntityTypeConfiguration<Servico>
    {
        public ServicoConfig()
        {
            HasKey(s => s.ServicoId);

            Property(s => s.Descricao)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(200);

            Property(s => s.Data)
                .IsRequired()
                .HasColumnType("date");

            Property(s => s.Valor)
                .IsRequired()
                .HasColumnType("numeric")
                .HasPrecision(15,2);

            Property(s => s.Tipo)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(150);

            HasRequired(s => s.Cliente)
                .WithMany(c => c.Servicos)
                .HasForeignKey(s => s.ClienteId);

            HasRequired(s => s.Fornecedor)
                .WithMany(f => f.Servicos)
                .HasForeignKey(s => s.FornecedorId);

            ToTable("Servicos");
        }
    }
}
