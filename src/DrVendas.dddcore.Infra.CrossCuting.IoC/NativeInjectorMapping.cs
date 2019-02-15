using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using DrVendas.dddcore.Application.AppVendas.Interfaces;
using DrVendas.dddcore.Application.AppVendas.Interfaces.AgregracaoPedidos;
using Projeto.Curso.Core.Application.Pedido.Services;
using Projeto.Curso.Core.Application.Pedido.Services.AgregacaoPedidos;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Repository;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Repository.AgregacaoPedidos;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Services;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Services.AgregacaoPedidos;
using Projeto.Curso.Core.Domain.Pedido.Services;
using Projeto.Curso.Core.Domain.Pedido.Services.AgregacaoPedidos;
using Projeto.Curso.Core.Infra.Data.Context;
using Projeto.Curso.Core.Infra.Data.Repository;
using Projeto.Curso.Core.Infra.Data.Repository.AgregacaoPedidos;

namespace DrVendas.dddcore.Infra.CrossCuting.IoC
{
    public class NativeInjectorMapping
    {

        public static void RegisterServices(IServiceCollection service)
        {
            service.AddSingleton(Mapper.Configuration);
            service.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            service.AddScoped<IApplicationCliente, ApplicationClientes>();
            service.AddScoped<IApplicationFornecedor, ApplicationFornecedores>();
            service.AddScoped<IApplicationProduto, ApplicationProdutos>();
            service.AddScoped<IApplicationItensPedido, ApplicationItensPedidos>();
            service.AddScoped<IApplicationPedido, ApplicationPedidos>();

            service.AddScoped<IServiceClientes, ServiceClientes>();
            service.AddScoped<IServiceFornecedores, ServiceFornecedores>();
            service.AddScoped<IServiceProdutos, ServiceProdutos>();
            service.AddScoped<IServiceItensPedidos, ServiceItensPedidos>();
            service.AddScoped<IServicePedidos, ServicePedidos>();

            service.AddScoped<IRepositoryClientes, RepositoryClientes>();
            service.AddScoped<IRepositoryFornecedores, RepositoryFornecedores>();
            service.AddScoped<IRepositoryProdutos, RepositoryProdutos>();
            service.AddScoped<IRepositoryPedidos, RepositoryPedidos>();
            service.AddScoped<IServicePedidos, ServicePedidos>();

            service.AddScoped<ContextEFPedidos>();


        }

    }
}