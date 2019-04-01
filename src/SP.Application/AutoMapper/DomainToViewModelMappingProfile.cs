using AutoMapper;
using SP.Application.ViewModels;
using SP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Fornecedor, FornecedorViewModel>();
            CreateMap<Servico, ServicoViewModel>();
        }
    }
}
