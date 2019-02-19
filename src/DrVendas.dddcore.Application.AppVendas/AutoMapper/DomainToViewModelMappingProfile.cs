using AutoMapper;
using DrVendas.dddcore.Application.AppVendas.ViewModels;
using DrVendas.dddcore.Application.AppVendas.ViewModels.AgregracaoPedidos;
using DrVendas.dddcore.Domain.Entidades;
using DrVendas.dddcore.Domain.Entidades.AgregacaoPedido;
using DrVendas.dddcore.Infra.CrossCutting.Extensions;
using Projeto.Curso.Core.Infra.CrossCutting.Extensions;

namespace DrVendas.dddcore.Application.AppVendas.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            /* Fazendo a passagem de um objeto Domain para ViewModel, como existem objetos complexos(ValueObject) o 
             * ForMember  não   funciona.
             Só funciona com  ConvertUsing*/
            CreateMap<Cliente, ClienteViewModel>()
                 .ConvertUsing((src, dst) =>
                 {
                     return new ClienteViewModel
                     {
                         Id = src.Id,
                         Apelido = src.Apelido,
                         Nome = src.Nome,
                         CpfCnpj = src.CPFCNPJ.Numero.FormatoCpfCnpj(),
                         Email = src.Email.Endereco,
                         Endereco = src.Endereco.Logradouro,
                         Bairro = src.Endereco.Bairro,
                         Cidade = src.Endereco.Cidade,
                         UF = src.Endereco.UF.UF,
                         CEP = src.Endereco.CEP.Codigo
                     };
                 });


            CreateMap<Fornecedor, FornecedorViewModel>()
                 .ConvertUsing((src, dst) =>
                 {
                     return new FornecedorViewModel
                     {
                         Id = src.Id,
                         Apelido = src.Apelido,
                         Nome = src.Nome,
                         CpfCnpj = src.CPFCNPJ.Numero.FormatoCpfCnpj(),
                         Email = src.Email.Endereco,
                         Endereco = src.Endereco.Logradouro,
                         Bairro = src.Endereco.Bairro,
                         Cidade = src.Endereco.Cidade,
                         UF = src.Endereco.UF.UF,
                         CEP = src.Endereco.CEP.Codigo
                     };
                 });

            CreateMap<Produto, ProdutoViewModel>()
                              .ConvertUsing((src, dst) =>
                              {
                                  return new ProdutoViewModel
                                  {
                                      Id = src.Id,
                                      Apelido = src.Apelido,
                                      Nome = src.Nome,
                                      Valor = src.Valor.Formatado("{0:#,###,##0.00}"),
                                      Unidade = src.Unidade,
                                      IdFornecedor = src.FornecedorId,
                                      NomeFornecedor = src.Fornecedor.Nome
                                  };
                              });


            CreateMap<Pedido, PedidoViewModel>()
                    .ForMember(to => to.DataPedido, opt => opt.MapFrom(from => from.DataPedido.Formatado("{0:dd/MM/yyyy}")))
                    .ForMember(to => to.DataEntrega, opt => opt.MapFrom(from => from.DataEntrega.Formatado("{0:dd/MM/yyyy}")));

            CreateMap<ItemPedido, ItemPedidoViewModel>();

        }
    }
}
