using AutoMapper;
using DrVendas.dddcore.Application.AppVendas.ViewModels;
using DrVendas.dddcore.Application.AppVendas.ViewModels.AgregracaoPedidos;
using DrVendas.dddcore.Domain.Entidades;
using DrVendas.dddcore.Domain.Entidades.AgregacaoPedido;
using DrVendas.dddcore.Domain.Shared.ValueObjects;
using DrVendas.dddcore.Infra.CrossCutting.Extensions;
using System;

namespace DrVendas.dddcore.Application.AppVendas.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClienteViewModel, Cliente>()
                 .ConvertUsing((src, dst) =>
                 {
                     return new Cliente
                     {
                         Id = src.Id,
                         Apelido = src.Apelido,
                         Nome = src.Nome,
                         CPFCNPJ = new CpfCnpjVO
                         {
                             Numero = src.CpfCnpj.SomenteNumeros()
                         },
                         Email = new EmailVO
                         {
                             Endereco = src.Email
                         },
                         Endereco = new EnderecoVO
                         {
                             Logradouro = src.Endereco,
                             Bairro = src.Bairro,
                             Cidade = src.Cidade,
                             UF = new UfVO
                             {
                                 UF = src.UF
                             },
                             CEP = new CepVO
                             {
                                 Codigo = src.CEP
                             }
                         }

                     };
                 });

            CreateMap<FornecedorViewModel, Fornecedor>()
                 .ConvertUsing((src, dst) =>
                 {
                     return new Fornecedor
                     {
                         Id = src.Id,
                         Apelido = src.Apelido,
                         Nome = src.Nome,
                         CPFCNPJ = new CpfCnpjVO
                         {
                             Numero = src.CpfCnpj.SomenteNumeros()
                         },
                         Email = new EmailVO
                         {
                             Endereco = src.Email
                         },
                         Endereco = new EnderecoVO
                         {
                             Logradouro = src.Endereco,
                             Bairro = src.Bairro,
                             Cidade = src.Cidade,
                             UF = new UfVO
                             {
                                 UF = src.UF
                             },
                             CEP = new CepVO
                             {
                                 Codigo = src.CEP
                             }
                         }
                     };
                 });

            CreateMap<ProdutoViewModel, Produto>()
                    .ForMember(to => to.Valor, opt => opt.MapFrom(from => from.Valor.ConvertDecimal("{0:#,###,##0.00}")));

            CreateMap<PedidoViewModel, Pedido>()
                    .ForMember(to => to.DataPedido, opt => opt.MapFrom(from => Convert.ToDateTime(from.DataPedido)))
                    .ForMember(to => to.DataEntrega, opt => opt.MapFrom(from => Convert.ToDateTime(from.DataEntrega)));

            CreateMap<ItemPedidoViewModel, ItemPedido>();
        }

    }
}
