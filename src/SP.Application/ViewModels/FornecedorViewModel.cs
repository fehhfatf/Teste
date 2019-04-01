using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SP.Application.ViewModels
{
    public class FornecedorViewModel
    {
        public FornecedorViewModel()
        {
            FornecedorId = Guid.NewGuid();
            Servicos = new List<ServicoViewModel>();
        }

        [Key]
        public Guid FornecedorId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }
        
        [ScaffoldColumn(false)]
        public Guid UserId { get; set; }

        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "Máximo de 100 e mínimo de 2 caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [Compare("Password", ErrorMessage = "As senhas não correspondem.")]
        public string ConfirmPassword { get; set; }

        public ICollection<ClienteViewModel> Clientes { get; set; }
        public ICollection<ServicoViewModel> Servicos { get; set; }
    }
}
