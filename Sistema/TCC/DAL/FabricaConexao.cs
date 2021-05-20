using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
     public class FabricaConexao
    {   //Atributos
        private static SqlConnection con;


        private static string caminho = "server = localhost; database=Projeto; user id = sa; password=123456";//"server=P3L2M16; database=Projeto; user id = sa; password=123456";

        //Método
        public static SqlConnection getConexao()
        {
            try
            {
                con = new SqlConnection(caminho);
                return con;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
