using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.DAL
{
    public class Produto
    {
        public static string SQL;

        BLL.ClasseParaManipularBancoDeDados c = new BLL.ClasseParaManipularBancoDeDados();

        private Decimal _CodigoDeBarras;
        private int _CategoriaId;
        private int _FornecedorId;
        private string _NomeProduto;
        private int _QuantidadeProduto;
        private int _StatusProduto;
        private decimal _PrecoProduto;
        private string _FotoDoProduto;
        private string _Descricao;
        private DateTime _DataEntrada;
        private int _QuantProd;
        private DateTime _DataValidade;

       
        public int FornecedorId { get => _FornecedorId; set => _FornecedorId = value; }
        public string NomeProduto { get => _NomeProduto; set => _NomeProduto = value; }
        public int QuantidadeProduto { get => _QuantidadeProduto; set => _QuantidadeProduto = value; }
        public int StatusProduto { get => _StatusProduto; set => _StatusProduto = value; }
        public decimal PrecoProduto { get => _PrecoProduto; set => _PrecoProduto = value; }
        public string FotoDoProduto { get => _FotoDoProduto; set => _FotoDoProduto = value; }
        public string Descricao { get => _Descricao; set => _Descricao = value; }
        public int CategoriaId { get => _CategoriaId; set => _CategoriaId = value; }
        public DateTime DataEntrada { get => _DataEntrada; set => _DataEntrada = value; }
        public int QuantProd { get => _QuantProd; set => _QuantProd = value; }
        public DateTime DataValidade { get => _DataValidade; set => _DataValidade = value; }
        public Decimal CodigoDeBarras { get => _CodigoDeBarras; set => _CodigoDeBarras = value; }

        public System.Data.SqlClient.SqlDataReader ConsultarProd()
        {
            BLL.ClasseParaManipularBancoDeDados c = new BLL.ClasseParaManipularBancoDeDados();
            String SQL;
            try
            {
                SQL = "SELECT * FROM tbProduto WHERE CodigoProduto = " + _CodigoDeBarras;
                return c.RetornarDataReader(SQL);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet ListarTodos(string pesquisa)
        {
            try
            {
                string instrucao = "SELECT tbProduto.CodigoProduto, tbCategoria.Descricao, tbFornecedor.Nome, tbProduto.NomeProduto, tbProduto.StatusProduto, tbProduto.PrecoProduto, tbProduto.FotoDoProduto, tbProduto.Descricao, tbProduto.DataEntrada, tbProduto.QuantProd, tbProduto.DataValidade FROM  tbProduto inner join tbCategoria on tbProduto.CategoriaID = tbCategoria.CategoriaID inner join tbFornecedor on tbProduto.FornecedorID = tbFornecedor.FornecedorId ORDER BY DataEntrada";
                if (pesquisa.Length != 0)
                {
                    instrucao = "SELECT  CodigoProduto, CategoriaID, FornecedorID, NomeProduto, StatusProduto, PrecoProduto, FotoDoProduto, Descricao, DataEntrada, QuantProd, DataValidade FROM tbProduto WHERE Nome LIKE '%" + pesquisa + "%' ORDER BY Nome";
                }
                return c.RetornarDataSet(instrucao);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Incluir()
        {
            try
            {
                BLL.ClasseParaManipularBancoDeDados c = new BLL.ClasseParaManipularBancoDeDados();
                SQL = "Insert into tbProduto(NomeProduto, CategoriaId, FornecedorId, StatusProduto, PrecoProduto, FotoDoProduto, Descricao, DataEntrada, QuantProd, DataValidade) values " +
                    "( '" + _NomeProduto + "', '" + _CategoriaId + "', '" + _FornecedorId + "', '" + _StatusProduto + "'," +
                   "'" + _PrecoProduto.ToString().Replace(",", ".") + "', '" + _FotoDoProduto + "', '" + _Descricao + "', '" + _DataEntrada + "', '" + _QuantProd + "', '" + _DataValidade + "')";
                c.ExecutarComando(SQL);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void Alterar()
        {
            try
            {
                BLL.ClasseParaManipularBancoDeDados c = new BLL.ClasseParaManipularBancoDeDados();
                SQL = "Update tbProduto set CategoriaID = '" + _CategoriaId + "', FornecedorID = '" + _FornecedorId + "', NomeProduto = '" + _NomeProduto + "',  StatusProduto = '" + _StatusProduto + "',  PrecoProduto = '" + _PrecoProduto + "',  FotoDoProduto = '" + _FotoDoProduto + "',  Descricao = '" + _Descricao + "',  DataEntrada = '" + _DataEntrada + "',  QuantProd = '" + _QuantProd + "', DataValidade = '" + _DataValidade + "' ";
                c.ExecutarComando(SQL);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public void Desativar()
        {
            try
            {
                SQL = "UPDATE TBPRODUTO SET StatusProduto = 0  WHERE CodigoProduto=" + CodigoDeBarras;
                c.ExecutarComando(SQL);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Ativar()
        {
            try
            {
                SQL = "UPDATE TBPRODUTO SET StatusProduto =1   WHERE CodigoProduto=" + CodigoDeBarras;
                c.ExecutarComando(SQL);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Excluir()
        {
            try
            {
                SQL = "DELETE FROM TBPRODUTO WHERE CodigoProduto = " + _CodigoDeBarras + " ";
                c.ExecutarComando(SQL);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader Consultar()
        {
            try
            {
                SQL = "SELECT * FROM Produtos WHERE CodigoDeBarras = " + CodigoDeBarras + " ";
                return c.RetornarDataReader(SQL);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Listar(string parteNome)
        {
            try
            {
                SQL = "SELECT IDproduto, CodigoDeBarras,Marca,Nome,ValorUnitario,Quantidade,Categoria,Fornecedor,DataEntrada,DataVencimento,Descricao,Foto FROM Produtos";

                if (parteNome.Length != 0)
                {
                    if (DAL.FuncoesGerais.IsNumeric(parteNome))
                    {
                        CodigoDeBarras = Convert.ToDecimal(parteNome);
                        SQL = "SELECT CodigoDeBarras,Nome,Categoria,ValorUnitario FROM Produtos WHERE Quantidade > 0 and CodigoDeBarras =" + CodigoDeBarras;
                    }
                    else
                    {
                        SQL = SQL + " WHERE Nome LIKE '%" + parteNome + "%'"; //avisado sobre comportamento
                    }
                }

                return c.RetornarDataSet(SQL);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet ListarAtivos()
        {
            try
            {
                SQL = "SELECT CodigoProduto, NomeProduto, StatusProduto FROM tbProduto WHERE StatusProduto= 1 ORDER BY NomeProduto";
                return c.RetornarDataSet(SQL);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet ListarInativos()
        {
            try
            {
                SQL = "SELECT CodigoProduto, NomeProduto, StatusProduto FROM tbProduto WHERE StatusProduto= 0 ORDER BY NomeProduto";
                return c.RetornarDataSet(SQL);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet ObterSituacaoEstoque()
        {
            try
            {

                SQL = "SELECT CodigoProduto, NomeProduto, QuantEstoque, FROM tbProduto";

                return c.RetornarDataSet(SQL);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



    }
}
