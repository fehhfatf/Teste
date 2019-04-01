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
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Preencha o campo Valor")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:F2}")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Preencha o campo Tipo")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Tipo { get; set; }

        public FornecedorViewModel Fornecedor { get; set; }
        public ClienteViewModel Cliente { get; set; }        
    }
}
