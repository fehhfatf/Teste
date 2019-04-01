using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Application.ViewModels
{
    public class ClienteViewModel
    {
        public ClienteViewModel()
        {
            ClienteId = Guid.NewGuid();
            Servicos = new List<ServicoViewModel>();
        }

        [Key]
        public Guid ClienteId { get; set; }

        public Guid FornecedorId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Bairro")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Preencha o campo Cidade")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Preencha o campo Estado")]       
        public string Estado { get; set; }

        public ICollection<ServicoViewModel> Servicos { get; set; }
    }
}
