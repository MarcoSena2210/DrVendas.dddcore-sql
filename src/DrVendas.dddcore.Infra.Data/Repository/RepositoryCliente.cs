//using Dapper;
using DrVendas.dddcore.Domain.Entidades;
using DrVendas.dddcore.Domain.Interfaces.Repository;
using DrVendas.dddcore.Infra.Data.Context;
//using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DrVendas.dddcore.Infra.Data.Repository
{
    public class RepositoryCliente : Repository<Cliente>, IRepositoryCliente
    {
        //No construtor precisamos injetar o contexto , repassamos para o "pai"... :base(MeuContexto) 
        public RepositoryCliente(ContextEFSQLServer MeuContexto)
            :base(MeuContexto) 
        {

        }

        //Foi substituido o uso do Dapper por ADO por causa dos values objects que nao poder ser mapeados pelo dapper

        public override IEnumerable<Cliente> ObterTodos()
        {
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM cliente ORDER BY id DESC");
            // foi substituido pelo Ado por causa dos value objects que dificultaria fazer o mapeamento
            //return Db.Database.GetDbConnection().Query<Cliente>(query.ToString());

            return ExecutarDataReader(null, query.ToString()); //usa ado
        }

        public override Cliente ObterPorId(int id)
        {
            //StringBuilder query = new StringBuilder();
            //query.Append(@"SELECT * FROM cliente WHERE id=@uID");
            //var retorno = Db.Database.GetDbConnection().Query<Cliente>(query.ToString(), new { uID = id }).FirstOrDefault();
            //return retorno;
            SqlParameter[] param = {
                                     new SqlParameter("@uID", id )
                                   };

            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM cliente WHERE id=@uID");
            return ExecutarDataReader(param, query.ToString()).FirstOrDefault();

        }

        public Cliente ObterPorApelido(string apelido)
        {
            // return Db.Clientes.AsNoTracking().FirstOrDefault(c => c.Apelido == apelido);
            // FOI susbstuido as consultas pelo dapper pq a performace é melhor
            //StringBuilder query = new StringBuilder();
            //query.Append(@"SELECT * FROM cliente WHERE apelido=@uAPELIDO");
            //var retorno = Db.Database.GetDbConnection().Query<Cliente>(query.ToString(), new { uAPELIDO = apelido }).FirstOrDefault();
            //return retorno;
            SqlParameter[] param = {
                                     new SqlParameter("@uApelido", apelido )
                                   };

            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM cliente WHERE apelido=@uAPELIDO");
            return ExecutarDataReader(param, query.ToString()).FirstOrDefault();
        }

        public Cliente ObterPorCpfCnpj(string cpfcnpj)
        {
            // return Db.Clientes.AsNoTracking().FirstOrDefault(c => c.CPFCNPJ.Numero == cpfcnpj);
            //StringBuilder query = new StringBuilder();
            //query.Append(@"SELECT * FROM cliente WHERE CpfCnpj=@uCPFCNPJ");
            //var retorno = Db.Database.GetDbConnection().Query<Cliente>(query.ToString(), new { uCPFCNPJ = cpfcnpj }).FirstOrDefault();
            //return retorno;
            SqlParameter[] param = {
                                     new SqlParameter("@uCPFCNPJ", cpfcnpj )
                                   };
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM cliente WHERE CpfCnpj=@uCPFCNPJ");
            return ExecutarDataReader(param, query.ToString()).FirstOrDefault();
        }

        private Cliente AtribuirCliente(Cliente cliente, SqlDataReader reader)
        {
            cliente.Id = reader.GetInt32(0);
            cliente.Apelido = reader.SafeGetString(1);
            cliente.Nome = reader.SafeGetString(2);
            cliente.CPFCNPJ.Numero = reader.SafeGetString(3);
            cliente.Email.Endereco = reader.SafeGetString(4);
            cliente.Endereco.Logradouro = reader.SafeGetString(5);
            cliente.Endereco.Bairro = reader.SafeGetString(6);
            cliente.Endereco.Cidade = reader.SafeGetString(7);
            cliente.Endereco.UF.UF = reader.SafeGetString(8);
            cliente.Endereco.CEP.Codigo = reader.SafeGetString(9);
            return cliente;
        }

        //retorna uma lista de clientes
        private IEnumerable<Cliente> ExecutarDataReader(SqlParameter[] param, string sql)
        {
            string cn = ObterStringConexao();
            List<Cliente> clientes = new List<Cliente>();  //inicializa cliente
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
                        Cliente cliente = new Cliente();
                        cliente = AtribuirCliente(cliente, reader);
                        clientes.Add(cliente);
                    }
                }
                return clientes;
            }
        }


    }
}