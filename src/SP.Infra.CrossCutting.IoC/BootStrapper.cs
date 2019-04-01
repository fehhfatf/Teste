using SimpleInjector;
using SP.Application.Interfaces;
using SP.Application.Services;
using SP.Domain.Interfaces.Repository;
using SP.Domain.Interfaces.Service;
using SP.Domain.Services;
using SP.Infra.Data.Context;
using SP.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            container.Register<IClienteAppService, ClienteAppService>(Lifestyle.Scoped);
            container.Register<IFornecedorAppService, FornecedorAppService>(Lifestyle.Scoped);
            container.Register<IServicoAppService, ServicoAppService>(Lifestyle.Scoped);

            container.Register<IClienteService, ClienteService>(Lifestyle.Scoped);
            container.Register<IFornecedorService, FornecedorService>(Lifestyle.Scoped);
            container.Register<IServicoService, ServicoService>(Lifestyle.Scoped);

            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
            container.Register<IFornecedorRepository, FornecedorRepository>(Lifestyle.Scoped);
            container.Register<IServicoRepository, ServicoRepository>(Lifestyle.Scoped);

            container.Register<SPContext>(Lifestyle.Scoped);
        }
    }
}
