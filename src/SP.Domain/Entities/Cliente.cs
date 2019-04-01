using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Domain.Entities
{
    public class Cliente
    {
        public Cliente()
        {
            ClienteId = Guid.NewGuid();
        }

        public Guid ClienteId { get; set; }
        public Guid FornecedorId { get; set; }
        public string Nome { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public virtual ICollection<Servico> Servicos { get; set; }
    }
}
