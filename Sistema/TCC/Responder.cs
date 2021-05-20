using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;
using DAL;

namespace TCC
{
    public partial class Responder : Form
    {
        public Responder(/*int res*/)
        {
            InitializeComponent();
            //MessageBox.Show(res.ToString());
        }


        SqlConnection sqlCon = null;
        private string strCon = "server = localhost; database=Projeto; user id = sa; password=123456";
        private string strSql = string.Empty;


        private void Responder_Load(object sender, EventArgs e)
        {

        }




        private void button4_Click(object sender, EventArgs e)
        {


            if (txtID.Text == string.Empty)
            {
                MessageBox.Show("CAMPOS VAZIOS!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {

                strSql = "delete from Faleconosco where id=@id";

                sqlCon = new SqlConnection(strCon);

                SqlCommand comando = new SqlCommand(strSql, sqlCon);

                comando.Parameters.Add("@id", SqlDbType.VarChar).Value = txtID.Text;

                try

                {
                    sqlCon.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("MENSAGEM EXCLUIDA COM SUCESSO!.", "SUCESSO!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    // throw;
                }
                finally
                {

                    txtAssunto.Clear();
                    txtEmail.Clear();
                    txtID.Clear();
                    txtIDcliente.Clear();
                    txtMensagem.Clear();
                    txtNome.Clear();
                    mskData.Text = DateTime.Now.ToString();
                    cboRespondido.Text = " ";


                    sqlCon.Close();

                }

            }



        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process pStart = new System.Diagnostics.Process();
            pStart.StartInfo = new System.Diagnostics.ProcessStartInfo(@"https://mail.google.com/mail/u/0/#inbox?compose=new");
            pStart.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          

            strSql = "update Faleconosco set respondido=@respondido where id=@id";

            sqlCon = new SqlConnection(strCon);

            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@id", SqlDbType.VarChar).Value = txtID.Text;

            comando.Parameters.Add("@respondido", SqlDbType.VarChar).Value = cboRespondido.Text;

            try
            {
                
                if (cboRespondido.Text == string.Empty)
                {
                    MessageBox.Show("ESCOLHA UMA OPÇÃO", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    sqlCon.Open();

                    comando.ExecuteNonQuery();

                    MessageBox.Show("SALVO COM SUCESSO!", "SUCESSO!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    this.Close();

                   

                }

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                // throw;
            }
            finally
            {
                sqlCon.Close();
            }

        }

        private void mskTelefone_Click(object sender, EventArgs e)
        {
            mskTelefone.SelectionStart = 0;
        }
    }
}
