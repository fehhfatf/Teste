using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Domain.Entities
{
    public class Fornecedor
    {
        public Fornecedor()
        {
            FornecedorId = Guid.NewGuid();
        }

        public Guid FornecedorId { get; set; }
        public Guid UserId { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Servico> Servicos { get; set; }
    }
}
