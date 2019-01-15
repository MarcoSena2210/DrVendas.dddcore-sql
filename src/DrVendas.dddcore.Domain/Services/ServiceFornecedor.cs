using DrVendas.dddcore.Domain.Entidades;
using DrVendas.dddcore.Domain.Interfaces.Repository;
using DrVendas.dddcore.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DrVendas.dddcore.Domain.Services
{
    public class ServiceFornecedor : IServiceFornecedor
    {
        private readonly IRepositoryFornecedor repofornecedor;
        private readonly IServiceProduto serviceproduto;

        public ServiceFornecedor(IRepositoryFornecedor _repofornecedor,
                                   IServiceProduto _serviceproduto)
        {
            repofornecedor = _repofornecedor;
            serviceproduto = _serviceproduto;
        }

        #region Adicionar fornecedores
        public Fornecedor Adicionar(Fornecedor fornecedor)
        {
            fornecedor = AptoParaAdicionarFornecedor(fornecedor);
            if (fornecedor.ListaErros.Any()) return fornecedor;
            repofornecedor.Adicionar(fornecedor);
            return fornecedor;
        }

        private Fornecedor AptoParaAdicionarFornecedor(Fornecedor fornecedor)
        {
            if (!fornecedor.EstaConsistente()) return fornecedor;
            fornecedor = VerificarSeApelidoExisteEmInclusao(fornecedor);
            fornecedor = VerificarSeCPFCNPJExisteEmInclusao(fornecedor);
            return fornecedor;
        }


        private Fornecedor VerificarSeApelidoExisteEmInclusao(Fornecedor fornecedor)
        {
            if (ObterPorApelido(fornecedor.Apelido) != null) fornecedor.ListaErros.Add("O Apelido " + fornecedor.Apelido + " já existe em outro fornecedor!");
            return fornecedor;
        }

        private Fornecedor VerificarSeCPFCNPJExisteEmInclusao(Fornecedor fornecedor)
        {
            if (ObterPorCpfCnpj(fornecedor.CPFCNPJ.Numero) != null) fornecedor.ListaErros.Add("O CPF ou CNPJ " + fornecedor.CPFCNPJ.Numero + " já existe em outro fornecedor!");
            return fornecedor;
        }
        #endregion Adicionar fornecedores

        #region Atualizar fornecedores
        public Fornecedor Atualizar(Fornecedor fornecedor)
        {
            fornecedor = AptoParaAlterarFornecedor(fornecedor);
            if (fornecedor.ListaErros.Any()) return fornecedor;
            repofornecedor.Atualizar(fornecedor);
            return fornecedor;
        }

        private Fornecedor AptoParaAlterarFornecedor(Fornecedor fornecedor)
        {
            if (!fornecedor.EstaConsistente()) return fornecedor;
            fornecedor = VerificarSeApelidoExisteEmAlteracao(fornecedor);
            fornecedor = VerificarSeCPFCNPJExisteEmAlteracao(fornecedor);
            return fornecedor;
        }


        private Fornecedor VerificarSeApelidoExisteEmAlteracao(Fornecedor fornecedor)
        {
            var result = ObterPorApelido(fornecedor.Apelido);
            if (result != null && result.Id != fornecedor.Id) fornecedor.ListaErros.Add("O Apelido " + fornecedor.Apelido + " já existe em outro fornecedor!");
            return fornecedor;
        }

        private Fornecedor VerificarSeCPFCNPJExisteEmAlteracao(Fornecedor fornecedor)
        {
            var result = ObterPorCpfCnpj(fornecedor.CPFCNPJ.Numero);
            if (result != null && result.Id != fornecedor.Id) fornecedor.ListaErros.Add("O CPF ou CNPJ " + fornecedor.CPFCNPJ.Numero + " já existe em outro fornecedor!");
            return fornecedor;
        }
        
        #endregion Atualizar fornecedores

        #region Remover fornecedores


        public Fornecedor Remover(Fornecedor fornecedor)
        {
            fornecedor = VerificarSeExiteProdutoAssociadoAoFornecedor(fornecedor);
            if (fornecedor.ListaErros.Any()) return fornecedor;
            repofornecedor.Remover(fornecedor);
            return fornecedor;
        }

        private Fornecedor VerificarSeExiteProdutoAssociadoAoFornecedor(Fornecedor fornecedor)
        {
            var result = serviceproduto.ObterTodos().FirstOrDefault(p => p.FornecedorId == fornecedor.Id);
            if (result != null) fornecedor.ListaErros.Add("Existe(m) produto(s) associados a este fornecedor, exclusão não permtida!");
            return fornecedor;
        }

        #endregion Remover fornecedores

        #region consulta fornecedores
        public IEnumerable<Fornecedor> ObterTodos()
        {
            return repofornecedor.ObterTodos();
        }

        public Fornecedor ObterPorId(int id)
        {
            return repofornecedor.ObterPorId(id);
        }

        public Fornecedor ObterPorApelido(string apelido)
        {
            return repofornecedor.ObterPorApelido(apelido);
        }

        public Fornecedor ObterPorCpfCnpj(string cpfcnpj)
        {
            return ObterPorCpfCnpj(cpfcnpj);
        }

        #endregion consulta fornecedores

        public void Dispose()
        {
            repofornecedor.Dispose();
            serviceproduto.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
