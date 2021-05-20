using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.DAL;

namespace TCC.Modelo
{
    public class Controle
    {
        public bool tem;
        public String mensagem = "";

        public bool acessar(String email, String senha)
        {
            LoginDaoComandos loginDao = new LoginDaoComandos();
            tem = loginDao.verificarLogin(email, senha);
            //tirar duvida marcos
            //tirar duvida marcos 
            //tirar duvida marcos

            return tem;
        }
        

        public String cadastrar(String email, String senha, String confSenha)
        {
            return mensagem;
        }
    }
}
