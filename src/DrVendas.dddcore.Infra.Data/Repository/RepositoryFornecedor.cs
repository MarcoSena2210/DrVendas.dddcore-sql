using DrVendas.dddcore.Domain.Entidades;
using DrVendas.dddcore.Domain.Interfaces.Repository;
using DrVendas.dddcore.Infra.Data.Context;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DrVendas.dddcore.Infra.Data.Repository
{
    public class RepositoryFornecedor : Repository<Fornecedor>, IRepositoryFornecedor
    {
        //Usando o ADO  nso metodos de leitura
        public RepositoryFornecedor(ContextEFSQLServer MeuContexto)
            : base(MeuContexto)
        {

        }
        public override IEnumerable<Fornecedor> ObterTodos()
        {
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM fornecedor ORDER BY id DESC");
            return ExecutarDataReader(null, query.ToString());  //nao estou passando parametro
        }

        public override Fornecedor ObterPorId(int id)
        {
            SqlParameter[] param = {
                                     new SqlParameter("@uID", id )
                                   };

            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM fornecedor WHERE id=@uID");
            return ExecutarDataReader(param, query.ToString()).FirstOrDefault();
        }

        public Fornecedor ObterPorApelido(string apelido)
        {
            SqlParameter[] param = {
                                     new SqlParameter("@uApelido", apelido )
                                   };
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM fornecedor WHERE apelido=@uAPELIDO");
            return ExecutarDataReader(param, query.ToString()).FirstOrDefault();
        }

        public Fornecedor ObterPorCpfCnpj(string cpfcnpj)
        {
            SqlParameter[] param = {
                                     new SqlParameter("@uCPFCNPJ", cpfcnpj )
                                   };

            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM fornecedor WHERE CpfCnpj=@uCPFCNPJ");
            return ExecutarDataReader(param, query.ToString()).FirstOrDefault();
        }


        private Fornecedor AtribuirFornecedor(Fornecedor fornecedor, SqlDataReader reader)
        {
            fornecedor.Id = reader.GetInt32(0);
            fornecedor.Apelido = reader.GetString(1);
            fornecedor.Nome = reader.GetString(2);
            fornecedor.CPFCNPJ.Numero = reader.GetString(3);
            fornecedor.Email.Endereco = reader.GetString(4);
            fornecedor.Endereco.Logradouro = reader.GetString(5);
            fornecedor.Endereco.Bairro = reader.GetString(6);
            fornecedor.Endereco.Cidade = reader.GetString(7);
            fornecedor.Endereco.UF.UF = reader.GetString(8);
            fornecedor.Endereco.CEP.Codigo = reader.GetString(9);
            return fornecedor;
        }

        private IEnumerable<Fornecedor> ExecutarDataReader(SqlParameter[] param, string sql)
        {
            string cn = ObterStringConexao();
            List<Fornecedor> fornecedores = new List<Fornecedor>();
            using (SqlConnection con = new SqlConnection(cn))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Clear();
                if (param != null)
                {
                    cmd.Parameters.AddRange(param);
                }
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Fornecedor fornecedor = new Fornecedor();
                        fornecedor = AtribuirFornecedor(fornecedor, reader);
                        fornecedores.Add(fornecedor);
                    }
                }
                return fornecedores;
            }
        }
     }

}
