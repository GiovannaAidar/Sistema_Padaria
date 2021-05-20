using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCC
{
    public partial class Encomendas : Form
    {
        public Encomendas()
        {
            InitializeComponent();


        }


        SqlConnection sqlCon = null;
        private string strCon = "server = localhost; database=Projeto; user id = sa; password=123456";
        private string strSql = string.Empty;

        private void button4_Click(object sender, EventArgs e)
        {

            if (txtID2.Text == string.Empty)
            {
                MessageBox.Show("CAMPOS VAZIOS!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {

                strSql = "delete from Encomendas where idPedido=@idPedido";

                sqlCon = new SqlConnection(strCon);

                SqlCommand comando = new SqlCommand(strSql, sqlCon);

                comando.Parameters.Add("@idPedido", SqlDbType.VarChar).Value = txtID2.Text;

                try

                {
                    sqlCon.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("ENCOMENDA EXCLUIDA COM SUCESSO!.", "SUCESSO!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    // throw;
                }
                finally
                {

                

                    txtID2.Clear();
                    txtIDcliente2.Clear();
                    mskData2.Text = DateTime.Now.ToString();
                    txtOcasiao2.Clear();
                    mskTelefone2.Clear();
                    txtEmail2.Clear();
                    txtDescricao.Clear();


                    sqlCon.Close();

                }

            }

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Encomendas_Load(object sender, EventArgs e)
        {

        }

        private void mskTelefone2_Click(object sender, EventArgs e)
        {
            mskTelefone2.SelectionStart = 0;
        }
    }
}
