using System;
using System.ComponentModel.DataAnnotations;

namespace SP.Application.ViewModels
{
    public class ServicoViewModel
    {
        public ServicoViewModel()
        {
            ServicoId = Guid.NewGuid();
        }

        [Key]
        public Guid ServicoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Fornecedor")]
        public Guid FornecedorId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Cliente")]
        public Guid ClienteId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(200, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preencha o campo Data de Atendimento")]
        [Display(Name="Data do Atendimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Preencha o campo Valor")]
        [RegularExpression(@"^\d+\,\d{0,2}$", ErrorMessage="Máximo de duas casas decimais, utilizando vírgula para separar")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Preencha o campo Tipo")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Tipo { get; set; }

        public FornecedorViewModel Fornecedor { get; set; }
        public ClienteViewModel Cliente { get; set; }        
    }
}
