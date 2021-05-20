using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.DAL
{
    class LoginDaoComandos
    {
        public bool tem;
        public String mensagem;
        SqlCommand cmd = new SqlCommand();
        Conexao con = new Conexao();
        SqlDataReader dr;

        public bool verificarLogin(String email, String senha)
        {
            //comandos sql verificação
            cmd.CommandText = "select * from logins where email = @email and senha = @senha and StatusFunc = 'ativo'";
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@senha", senha);
            try
            {
                cmd.Connection = con.conectar();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    tem = true;
                }
            }
            catch (SqlException)
            {
                this.mensagem = "Erro com Banco de Dados!";
            }

            return tem;
        }

        public String cadastrar(String usuario, String senha, String confSenha)
        {
            //comandos para inserir
            return mensagem;
        }

    }
}
