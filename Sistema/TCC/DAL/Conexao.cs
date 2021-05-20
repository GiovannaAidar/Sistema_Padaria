using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.DAL
{
     public class Conexao
    {
        SqlConnection con = new SqlConnection();
        public Conexao()
        {
            //con.ConnectionString = "server=P3L2M16; database=Projeto; user id = sa; password=123456";
            con.ConnectionString = "server = localhost; database=Projeto; user id = sa; password=123456";
        }

        public SqlConnection conectar()
        {
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

    
        public void desconectar()
        {
            if( con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            
        }

        internal SqlConnection Conectar()
        {
            throw new NotImplementedException();
        }
    }
}
