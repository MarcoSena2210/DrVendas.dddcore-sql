using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using DrVendas.dddcore.Application.AppVendas.Interfaces;
using DrVendas.dddcore.Application.AppVendas.Interfaces.AgregracaoPedidos;
using DrVendas.dddcore.Application.AppVendas.Services;
using DrVendas.dddcore.Application.AppVendas.Services.AgregacaoPedidos;
using DrVendas.dddcore.Domain.Interfaces.Repository;
using DrVendas.dddcore.Domain.Interfaces.Repository.AgregacaoPedido;
using DrVendas.dddcore.Domain.Interfaces.Services;
using DrVendas.dddcore.Domain.Interfaces.Services.AgregacaoPedidos;
using DrVendas.dddcore.Domain.Services;
using DrVendas.dddcore.Domain.Services.AgregacaoPedidos ;
using DrVendas.dddcore.Infra.Data.Context;
using DrVendas.dddcore.Infra.Data.Repository;
using DrVendas.dddcore.Infra.Data.Repository.AgregacaoPedido;

namespace DrVendas.dddcore.Infra.CrossCuting.IoC
{
    public class NativeInjectorMapping
    {

        public static void RegistersServices(IServiceCollection service)
        {
            service.AddSingleton(Mapper.Configuration);
            service.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            service.AddScoped<IApplicationCliente, ApplicationClientes>();
            service.AddScoped<IApplicationFornecedor, ApplicationFornecedores>();
            service.AddScoped<IApplicationProduto, ApplicationProdutos>();
            service.AddScoped<IApplicationItemPedido, ApplicationItensPedidos>();
            service.AddScoped<IApplicationPedido, ApplicationPedidos>();

            service.AddScoped<IServiceCliente, ServiceClientes>();
            service.AddScoped<IServiceFornecedor, ServiceFornecedor>();
            service.AddScoped<IServiceProduto, ServiceProduto>();
            service.AddScoped<IServiceItemPedido, ServiceItemPedido>();
            service.AddScoped<IServicePedido, ServicePedido>();

            service.AddScoped<IRepositoryCliente, RepositoryCliente>();
            service.AddScoped<IRepositoryFornecedor, RepositoryFornecedor>();
            service.AddScoped<IRepositoryProduto, RepositoryProduto>();
            service.AddScoped<IRepositoryPedido, RepositoryPedido>();
            service.AddScoped<IServicePedido, ServicePedido>();

            service.AddScoped<ContextEFSQLServer>();


        }

    }
}