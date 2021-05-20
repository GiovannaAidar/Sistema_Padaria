using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace TCC
{
    public partial class addFale : Form
    {
        public addFale()
        {
            InitializeComponent();
            carregar();
            Coluna();

            txtEmail.MaxLength=50;



        }


        //SqlConnection sqlCon = null;
        //private string strCon = "server = localhost; database=Projeto; user id = sa; password=123456";
        private string strSql = string.Empty;




  





        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            try
            {


                SqlConnection conexao = FabricaConexao.getConexao();
                ClientesDAL ClieDAL = new ClientesDAL();


                if (mskData.Text.Trim() == string.Empty || mskData.Text.Equals(""))
                {
                    MessageBox.Show("DATA INVALIDA!", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ClieDAL.abrirConexao(conexao);
                    string sqlSelect = " select id,idcliente,nome,email,telefone,DataDeEnvio,respondido,assunto,mensagem from Faleconosco where DataDeEnvio ='" + mskData.Text + "'";
                    dgvFale.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);
                    ClieDAL.fecharConexao(conexao);

                    CheckBox1.Checked = false;
                    CheckBox2.Checked = false;
                    cboAssunto.Text = " ";
                    txtEmail.Clear();
                }

            }

            catch (Exception)
            {

            }


        
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {

        }

        private void addFale_Load(object sender, EventArgs e)
        {



            
        }


    



        private void carregar()
        {
            SqlConnection conexao = FabricaConexao.getConexao();
            ClientesDAL ClieDAL = new ClientesDAL();
            ClieDAL.abrirConexao(conexao);


            

            string sqlSelect = "select Faleconosco.id, Faleconosco.idcliente, Faleconosco.nome, Faleconosco.email, Faleconosco.telefone, Faleconosco.DataDeEnvio, Faleconosco.respondido, assuntos.assunto, Faleconosco.mensagem from Faleconosco inner join assuntos on assuntos.id_assunto = Faleconosco.assunto ";
            dgvFale.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);
           
        }

        private void Coluna()
        {
            dgvFale.Columns[6].Width = 300;
            dgvFale.Columns[0].Width = 50;
            dgvFale.Columns[1].Width = 90;
            dgvFale.Columns[2].Width = 200;
            dgvFale.Columns[3].Width = 200;
            dgvFale.Columns[4].Width = 120;
            dgvFale.Columns[5].Width = 130;
            dgvFale.Columns[6].Width = 100;
            dgvFale.Columns[7].Width = 130;
            dgvFale.Columns[8].Width = 200;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                SqlConnection conexao = FabricaConexao.getConexao();
                ClientesDAL ClieDAL = new ClientesDAL();


                if (txtEmail.Text.Trim() == string.Empty || txtEmail.Text.Equals(""))
                {
                    MessageBox.Show("DIGÍTE UM E-MAIL!", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ClieDAL.abrirConexao(conexao);
                    string sqlSelect = " select id,idcliente,nome,email,telefone,DataDeEnvio,respondido,assunto,mensagem from Faleconosco where email ='" + txtEmail.Text + "'";
                    dgvFale.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);
                    ClieDAL.fecharConexao(conexao);

                    VefiricarEmail();
                    CheckBox1.Checked = false;
                    CheckBox2.Checked = false;
                    cboAssunto.Text = " ";
                    mskData.Text = DateTime.Now.ToString();

                    txtEmail.Clear();
                }



            }
            catch (Exception)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {


                SqlConnection conexao = FabricaConexao.getConexao();
                ClientesDAL ClieDAL = new ClientesDAL();


                if (cboAssunto.Text.Trim() == string.Empty || cboAssunto.Text.Equals(""))
                {
                    MessageBox.Show("ESCOLHA UM ASSUNTO!", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ClieDAL.abrirConexao(conexao);
                    string sqlSelect = " select Faleconosco.id, Faleconosco.idcliente, Faleconosco.nome, Faleconosco.email, Faleconosco.telefone, Faleconosco.DataDeEnvio, Faleconosco.respondido, assuntos.assunto, Faleconosco.mensagem from Faleconosco inner join assuntos on assuntos.id_assunto = Faleconosco.assunto where assuntos.assunto = '" + cboAssunto.Text + "'";

                    dgvFale.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);
                    ClieDAL.fecharConexao(conexao);

                    CheckBox1.Checked = false;
                    CheckBox2.Checked = false;
                    mskData.Text = DateTime.Now.ToString();
                    txtEmail.Clear();

                }



            }
            catch (Exception)
            {

            }


        }

        private void cboAssunto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      

        private void btnResponder_Click(object sender, EventArgs e)
        {
            // dgvFale_CellDoubleClick();
        }

        
        private void button4_Click(object sender, EventArgs e)
        {
            carregar();
            CheckBox1.Checked = false;
            CheckBox2.Checked = false;
            cboAssunto.Text = " ";
            txtEmail.Clear();
            mskData.Text = DateTime.Now.ToString();


        }

        public void VefiricarEmail()
        {
            string email = txtEmail.Text;

            Regex rg = new regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            if (rg.IsMatch(email))
            {
                //  MessageBox.Show("Email Valido!");
            }
            else
            {
                MessageBox.Show("DIGITE UM EMAIL VALIDO!", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Clear();
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtEmail.Text.Trim().Length != 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    try
                    {


                        SqlConnection conexao = FabricaConexao.getConexao();
                        ClientesDAL ClieDAL = new ClientesDAL();


                        if (txtEmail.Text.Trim() == string.Empty || txtEmail.Text.Equals(""))
                        {
                            MessageBox.Show("DIGITE UM E-MAIL!", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            ClieDAL.abrirConexao(conexao);
                            string sqlSelect = " select id,idcliente,nome,email,telefone,DataDeEnvio,respondido,assunto,mensagem from Faleconosco where email ='" + txtEmail.Text + "'";
                            dgvFale.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);
                            ClieDAL.fecharConexao(conexao);

                            VefiricarEmail();
                            CheckBox1.Checked = false;
                            CheckBox2.Checked = false;
                            cboAssunto.Text = " ";
                            mskData.Text = DateTime.Now.ToString();

                        }



                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        private void dgvFale_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFale.CurrentRow == null)
            {
                MessageBox.Show("NÃO HÁ MENSAGENS A SEREM LIDAS!", "AVISO!",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Responder f2 = new Responder();
                f2.txtID.Text = this.dgvFale.CurrentRow.Cells[0].Value.ToString();
                f2.txtIDcliente.Text = this.dgvFale.CurrentRow.Cells[1].Value.ToString();
                f2.txtNome.Text = this.dgvFale.CurrentRow.Cells[2].Value.ToString();
                f2.txtEmail.Text = this.dgvFale.CurrentRow.Cells[3].Value.ToString();
                f2.cboRespondido.Text = this.dgvFale.CurrentRow.Cells[6].Value.ToString();
                f2.txtAssunto.Text = this.dgvFale.CurrentRow.Cells[7].Value.ToString();
                f2.mskData.Text = this.dgvFale.CurrentRow.Cells[5].Value.ToString();
                f2.txtMensagem.Text = this.dgvFale.CurrentRow.Cells[8].Value.ToString();
                f2.mskTelefone.Text = this.dgvFale.CurrentRow.Cells[4].Value.ToString();


                f2.ShowDialog();
            }
          

        }



        protected void CheckBoxPrimeiro(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true)
            {
                CheckBox2.Checked = false;

                try
                {


                    SqlConnection conexao = FabricaConexao.getConexao();
                    ClientesDAL ClieDAL = new ClientesDAL();


                    if (CheckBox1.Checked)
                    {
                        ClieDAL.abrirConexao(conexao);
                        string sqlSelect = " select id,idcliente,nome,email,telefone,DataDeEnvio,respondido,assunto,mensagem from Faleconosco where respondido ='" + CheckBox1.Text + "'";
                        dgvFale.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);
                        ClieDAL.fecharConexao(conexao);






                    }
                }
                catch (Exception)
                {

                }



            }
        }

        protected void CheckBoxSegundo(object sender, EventArgs e)
        {
            if (CheckBox2.Checked == true)
            {
                CheckBox1.Checked = false;
            }
            try
            {


                SqlConnection conexao = FabricaConexao.getConexao();
                ClientesDAL ClieDAL = new ClientesDAL();


                if (CheckBox2.Checked)
                {
                    ClieDAL.abrirConexao(conexao);
                    string sqlSelect = " select id,idcliente,nome,email,telefone,DataDeEnvio,respondido,assunto,mensagem from Faleconosco where respondido ='" + CheckBox2.Text + "'";
                    dgvFale.DataSource = ClieDAL.retornaDataTable(sqlSelect, conexao);
                    ClieDAL.fecharConexao(conexao);






                }
            }
            catch (Exception)
            {

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void mskData_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }
    }
}
