using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Domain.Entities
{
    public class Servico
    {
        public Servico()
        {
            ServicoId = Guid.NewGuid();
        }

        public Guid ServicoId { get; set; }
        public Guid FornecedorId { get; set; }
        public Guid ClienteId { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public string Tipo { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
