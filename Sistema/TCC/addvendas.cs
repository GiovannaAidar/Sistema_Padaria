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
    public partial class ResponderEmails : Form
    {

        public ResponderEmails()
        {
            InitializeComponent();

            txtCodBarras.MaxLength = 13;
            txtPago.MaxLength = 7;

  

            txtCartao1PCredito.MaxLength = 7;



            // txtCartao1PCredito.Enabled = false;
            // txtCartao2PCredito.Enabled = false;
            //  txtValor1PCredito.Enabled = false;
            //  txtValor2PCredito.Enabled = false;
            // cboParcela1PCredito.Enabled = false;
            // cboParcela2PCredito.Enabled = false;

            txtValor1PDebito.Enabled = false;
            txtValor2PDebito.Enabled = false;
            panelCredito.Visible = false;
            //a vista
            txtPagoVistaPPersonalizar.Enabled = false;
            //credito
            cboQuantCreditoPPersonalizar.Enabled = false;
            txtPagoCredito1PPersonalizar.Enabled = false;
            txtPagoCredito2PPersonalizar.Enabled = false;
           // cboParcela1PPersonalizar.Enabled = false;
        //    cboParcela2PPersonalizar.Enabled = false;
         //   txtValorParcela1PPersonalizar.Enabled = false;
          //  txtValorParcela2PPersonalizar.Enabled = false;
            //debito
            cboQuantDebitoPPersonalizar.Enabled = false;
            txtPagoDebito1PPersonalizar.Enabled = false;
            txtPagoDebito2PPersonalizar.Enabled = false;

            txtPago.Enabled = false;
            radioButton5.Checked = true;

            DesejaCPF frm = new DesejaCPF();
            frm.ShowDialog();

            int respostaCPF = DesejaCPF.RESPOSTA_CPF;

            //CPF Balcão
            if (respostaCPF == 1)
            {
                txtPesquisaCliente.Clear();
            }
            else
            {
                txtPesquisaCliente.Text = "12345678909";
                txtNome.Text = "Balcão";
                txtPesquisaCliente.Enabled = false;
                txtNome.Enabled = false;
            }
            
        }


        SqlConnection sqlCon = null;
        private string strCon = "server = localhost; database=Projeto; user id = sa; password=123456";
        //private SqlConnection sqlConn;
        private string strSql = string.Empty;


        //private void btnBuscar_Click(object sender, EventArgs e)
        //{
        //    txtCodBarras.Enabled = true;
        //    txtValorUn.Enabled = false;


        //    toolTip1.Show("Buscar", btnPesquisa);

        //    strSql = "select*from produtos where CodigoDeBarras=@pesquisa ";

        //    sqlCon = new SqlConnection(strCon);

        //    SqlCommand comando = new SqlCommand(strSql, sqlCon);

        //    comando.Parameters.Add("@pesquisa", SqlDbType.VarChar).Value = txtCodBarras.Text;

        //    try
        //    {
        //        if (txtCodBarras.Text.Trim() == string.Empty || txtCodBarras.Text.Equals(""))
        //        {
        //            MessageBox.Show("VOCÊ NÃO DIGITOU UM CÓDIGO DE BARRAS.");
        //        }
        //        else
        //        {
        //            sqlCon.Open();
        //            SqlDataReader dr = comando.ExecuteReader();
        //            if (dr.HasRows == false)
        //            {
        //                throw new Exception("ESTE COÓDIGO DE BARRAS NÃO ESTÁ CADASTRADO");
        //            }

        //            dr.Read();

        //            txtNomeProduto.Text = Convert.ToString(dr["Nome"]);
        //            txtValorUn.Text = Convert.ToString(dr["ValorUnitario"]);
        //            pictureBox.ImageLocation = Convert.ToString(dr["Foto"]);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //    finally
        //    {
        //        sqlCon.Close();
        //    }
        //    txtCodBarras.Clear();
        //}

        private void addvendas_Load(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        public static bool verificarCPF(string CPF)
        {
            int[] mt1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mt2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string TempCPF;
            string Digito;
            int soma;
            int resto;

            CPF = CPF.Trim();
            CPF = CPF.Replace(".", "").Replace("-", "");

            if (CPF.Length != 11)
                return false;

            TempCPF = CPF.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(TempCPF[i].ToString()) * mt1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            Digito = resto.ToString();
            TempCPF = TempCPF + Digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(TempCPF[i].ToString()) * mt2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            Digito = Digito + resto.ToString();

            return CPF.EndsWith(Digito);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            toolTip1.Show("Buscar", btnPesquisarCliente);

            strSql = "select*from cliente where CPF=@pesquisa ";

            sqlCon = new SqlConnection(strCon);

            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@pesquisa", SqlDbType.VarChar).Value = txtPesquisaCliente.Text.Replace(",", "").Replace("-", "").Trim();

            try
            {
                if (txtPesquisaCliente.Text == string.Empty)
                {
                    MessageBox.Show("VOCÊ NÃO DIGITOU UM CPF.", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


                sqlCon.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.HasRows == false)
                {
                    MessageBox.Show("ESTE CPF NÃO ESTÁ CADASTRADO", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                dr.Read();

                txtNome.Text = Convert.ToString(dr["Nome"]);

            }

            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }

            finally
            {
                sqlCon.Close();
            }
            
        }

        //private void txtValorUn_Leave(object sender, EventArgs e)
        //{
        //    txtQuant.Focus();
        //}

        //private void txtQuant_Leave(object sender, EventArgs e)
        //{
        //    if (txtQuant.Text.Trim().Length != 0)
        //    {

        //        double valorUnit = Convert.ToDouble(txtValorUn.Text.Replace(",", "."));
        //        double qtde = Convert.ToDouble(txtQuant.Text);
        //        double valorSubTotal = qtde * valorUnit / 100;

        //        txtSbTotal.Text = Convert.ToString(valorSubTotal).Replace(".", ",");
        //        txtSbTotal.Focus();


        //    }

        //}

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Quant_TextChanged(object sender, EventArgs e)
        {

        }

        //private void Quant_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        if (txtQuant.Text.Trim().Length != 0)
        //        {
        //            double valorUnit = Convert.ToDouble(txtValorUn.Text.Replace(",", "."));
        //            double qtde = Convert.ToDouble(txtQuant.Text);
        //            double valorSubTotal = qtde * valorUnit;

        //            txtSbTotal.Text = Convert.ToString(valorSubTotal / 100).Replace(".", ",");
        //            txtSbTotal.Focus();

        //        }


        //    }

        //}

        //private void btnAdicionar_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtQuant.Text.Length == 0)
        //        {
        //            MessageBox.Show("DIGITE A QUANTIDADE!");
        //        }
        //        else
        //        {


        //            dataGridView1.Rows.Add(txtNomeProduto.Text, txtValorUn.Text, txtQuant.Text, txtSbTotal.Text);
        //            txtQuant.Clear();
        //            txtNomeProduto.Clear();
        //            txtValorUn.Clear();
        //            txtSbTotal.Clear();
        //            pictureBox.Image = null;

        //            // if(txtQuant.Text != string.Empty && txtValorUn.Text != string.Empty)

        //            double total = 0;
        //            foreach (DataGridViewRow row in dataGridView1.Rows)
        //            {
        //                total += Convert.ToDouble(row.Cells["SubTotal"].Value);

        //            }

        //            txtTotal.Text = Convert.ToString(total);
        //            txtSbTotal.Focus();



        //        }
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("A");
        //        throw;
        //    }
          


        //}

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            double total1 = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                total1 += Convert.ToDouble(row.Cells["SubTotal"].Value);

            }
            txtTotal.Text = Convert.ToString(total1);


            //double cinco = Convert.ToDouble(radioButton1.Text);
            double total = Convert.ToDouble(txtTotal.Text);

            double final = total * 5 / 100;

            txtTotal.Text = Convert.ToString(total - final);

            if (txtPago.Text.Trim().Length != 0)
            {

                double pago = Convert.ToDouble(txtPago.Text);
                double total2 = Convert.ToDouble(txtTotal.Text);
                double troco = pago - total2;

                txtTroco.Text = Convert.ToString(troco);

            }

        }

        private void txtPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtPago.Text.Trim().Length != 0)
            {
                try
                {
                    if (e.KeyCode == Keys.Enter)
                    {

                        if (txtTotal.Text == "")
                        {

                        }
                        else
                        {
                            double pago = Convert.ToDouble(txtPago.Text);
                            double total = Convert.ToDouble(txtTotal.Text);
                            double troco = pago - total;

                            txtTroco.Text = Convert.ToString(troco);

                            if (Convert.ToDouble(txtTroco.Text) >= 0)
                            {
                                btnSalvar.Enabled = true;
                            }
                            if (Convert.ToDouble(txtTroco.Text) < 0)
                            {
                                btnSalvar.Enabled = false;
                                MessageBox.Show("DINHEIRO PAGO É INSUFICIENTE PARA REALIZAR A COMPRA!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                   MessageBox.Show("VALOR PAGO INVALIDO!","ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // throw;
                    txtPago.Clear();
                }
                
            }    
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                double total1 = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    total1 += Convert.ToDouble(row.Cells["SubTotal"].Value);

                }
                txtTotal.Text = Convert.ToString(total1);


                double total = Convert.ToDouble(txtTotal.Text);

                double final = total * 10 / 100;

                txtTotal.Text = Convert.ToString(total - final);

                if (txtPago.Text.Trim().Length != 0)
                {

                    double pago = Convert.ToDouble(txtPago.Text);
                    double total2 = Convert.ToDouble(txtTotal.Text);
                    double troco = pago - total2;

                    txtTroco.Text = Convert.ToString(troco);

                }
            }

            else {

                txtTroco.Text = "0";
            }
            
        

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            double total1 = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                total1 += Convert.ToDouble(row.Cells["SubTotal"].Value);

            }
            txtTotal.Text = Convert.ToString(total1);

            double total = Convert.ToDouble(txtTotal.Text);

            double final = total * 15 / 100;

            txtTotal.Text = Convert.ToString(total - final);

            if (txtPago.Text.Trim().Length != 0)
            {

                double pago = Convert.ToDouble(txtPago.Text);
                double total2 = Convert.ToDouble(txtTotal.Text);
                double troco = pago - total2;

                txtTroco.Text = Convert.ToString(troco);

            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            double total1 = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                total1 += Convert.ToDouble(row.Cells["SubTotal"].Value);

            }
            txtTotal.Text = Convert.ToString(total1);


            double total = Convert.ToDouble(txtTotal.Text);

            double final = total * 20 / 100;

            txtTotal.Text = Convert.ToString(total - final);

            if (txtPago.Text.Trim().Length != 0)
            {

                double pago = Convert.ToDouble(txtPago.Text);
                double total2 = Convert.ToDouble(txtTotal.Text);
                double troco = pago - total2;

                txtTroco.Text = Convert.ToString(troco);

            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton8_Click(object sender, EventArgs e)
        {
            //addpersonalizar add = new addpersonalizar();
            //add.Show();

            painelPersonalizar.Visible = true;

            txtTotalPPersonalizar.Text = txtTotal.Text;

        }

        //private void txtCodBarras_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {


        //        txtCodBarras.Enabled = true;
        //        txtValorUn.Enabled = false;


        //        toolTip1.Show("Buscar", btnPesquisa);

        //        strSql = "select*from produtos where CodigoDeBarras=@pesquisa ";

        //        sqlCon = new SqlConnection(strCon);

        //        SqlCommand comando = new SqlCommand(strSql, sqlCon);

        //        comando.Parameters.Add("@pesquisa", SqlDbType.VarChar).Value = txtCodBarras.Text;

        //        try
        //        {
        //            if (txtCodBarras.Text == string.Empty)
        //            {
        //                MessageBox.Show("VOCÊ NÃO DIGITOU UM CÓDIGO DE BARRAS.");
        //            }

        //            sqlCon.Open();
        //            SqlDataReader dr = comando.ExecuteReader();
        //            if (dr.HasRows == false)
        //            {
        //                throw new Exception("ESTE COÓDIGO DE BARRAS NÃO ESTÁ CADASTRADO");
        //            }

        //            dr.Read();

        //            txtNomeProduto.Text = Convert.ToString(dr["Nome"]);
        //            txtValorUn.Text = Convert.ToString(dr["ValorUnitario"]);
        //            pictureBox.ImageLocation = Convert.ToString(dr["Foto"]);


        //        }

        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }

        //        finally
        //        {
        //            sqlCon.Close();
        //            txtCodBarras.Clear();
        //        }
        //    }


        //}

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtQuant_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {

            double resultado;
            double total = 0;

              
                
            total = (Convert.ToDouble(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value));
  

             resultado = Convert.ToDouble(txtTotal.Text) - total;
             txtTotal.Text = resultado.ToString();

         

            }


        }

        private void txtCodBarras_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
            {
                btnSalvar.Enabled = true;
            }
            else
            {
                btnSalvar.Enabled = false;
            }


            txtTroco.Text = "0";
            txtTroco.Enabled = false;

            txtPago.Text = "0";
            txtPago.Enabled = false;

    
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            txtPago.Enabled = true;
            txtPago.Text = "0";
        }

        private void txtPago_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;

            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }
        }

        private void txtPago_TextChanged(object sender, EventArgs e)
        {
         
              //  txtTroco.Text = Convert.ToString(
                //              Convert.ToDouble(txtPago.Text) - Convert.ToDouble(txtTotal.Text)
                     //         );
            
                
        }

        private void radioButton7_Click(object sender, EventArgs e)
        {
            txtTroco.Text = "0";
            txtTroco.Enabled = false;

            txtPago.Text = "0";
            txtPago.Enabled = false;

   
            txtTotalPCredito.Text = txtTotal.Text;

            panelCredito.Visible = true;

            if (radioButton7.Checked == true)
            {
                panelCredito.Visible = true;
            }




        }

        private void radioButton6_Click(object sender, EventArgs e)
        {
            txtTroco.Text = "0";
            txtTroco.Enabled = false;

            txtPago.Text = "0";
            txtPago.Enabled = false;

            //adddebito add = new adddebito();

            //add.txtTotal.Text = txtTotal.Text;
            //add.Show();

            painelDebito.Visible = false;
        }

        public void LimparGrid()
        {

            dataGridView1.DataSource = null;
            //dataGridView1.Columns.Clear();

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }



        public void BaixaNoEstoque()
        {
            for (int a = 0; a < dataGridView1.Rows.Count - 1; a++)
            {
                sqlCon = new SqlConnection(strCon);
                strSql = "update Produtos set Quantidade = Quantidade - " + dataGridView1.Rows[a].Cells[3].Value.ToString() + " where CodigoDeBarras= '" + dataGridView1.Rows[a].Cells[0].Value.ToString() + "'";
                SqlCommand comando = new SqlCommand(strSql, sqlCon);
                sqlCon.Open();
                comando.ExecuteNonQuery();
            }
        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {

            toolTip1.Show("Salvar", btnSalvar);

            strSql = "insert into venda (CPFcliente, DataVenda,ValorTotal,FormaPagamento) values(@CPFcliente,SYSDATETIME(),@ValorTotal,@FormaPagamento)";


            sqlCon = new SqlConnection(strCon);

            SqlCommand comando = new SqlCommand(strSql, sqlCon);

         

            comando.Parameters.Add("@CPFcliente", SqlDbType.NVarChar).Value = txtPesquisaCliente.Text.Replace("-", "").Replace(".", "").Replace(",", "");
            comando.Parameters.Add("@ValorTotal", SqlDbType.Decimal).Value = txtTotal.Text;
            if (txtPesquisaCliente.Text == string.Empty || txtPesquisaCliente.Text == null)
            {
                MessageBox.Show("DIGITE O CPF DO CLIENTE!", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {


                if (radioButton5.Checked == true)
                {
                    comando.Parameters.Add("@FormaPagamento", SqlDbType.VarChar).Value = radioButton5.Text;

                }
                else if (radioButton7.Checked == true)
                {
                    comando.Parameters.Add("@FormaPagamento", SqlDbType.VarChar).Value = radioButton7.Text;
                }
                else if (radioButton6.Checked == true)
                {
                    comando.Parameters.Add("@FormaPagamento", SqlDbType.VarChar).Value = radioButton6.Text;
                }


                else if (radioButton8.Checked == true)
                {
                    comando.Parameters.Add("@FormaPagamento", SqlDbType.VarChar).Value = radioButton8.Text;
                }

                //separação

                if (txtPago.Text == string.Empty)
                {
                    MessageBox.Show("DIGITE O VALOR PAGO!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (txtPesquisaCliente.Text == string.Empty)
                {
                    MessageBox.Show("PREENCHA O CAMPO CPF", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    sqlCon.Open();

                    BaixaNoEstoque();

                    comando.ExecuteNonQuery();

                    MessageBox.Show("COMPRA REALIZADA COM SUCESSO!", "SUCESSO!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    //txtPesquisa.Enabled = true;

                    LimparGrid();
                    //txtNome.Clear();
                    //mskTelefone.Clear();
                    //txtEmail.Clear();
                    //txtLogradouro.Clear();
                    //txtNumero.Clear();
                    //txtBairro.Clear();
                    //mskRG.Clear();
                    //mskCPF.Clear();
                    //mskCelular.Clear();
                    //mskCEP.Clear();
                    //txtCidade.Clear();
                    //mskNascimento.Clear();
                    //cboCargo.Text = " ";
                    //cboSexo.Text = " ";
                    //cboUF.Text = " ";
                    txtTroco.Clear();
                    txtPago.Clear();
                    txtTotal.Clear();
                    txtPesquisaCliente.Clear();
                    txtNome.Clear();
                    BaixaNoEstoque();

                    sqlCon.Close();

                    btnSalvar.Enabled = false;
                }
                //throw;
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //panelCredito.Visible = false;
        }

        //private void panelCredito_Paint(object sender, PaintEventArgs e)
        //{
        //    try
        //    {
        //        if (cboQuantCartaoPCredito.Text == " ")
        //        {
        //            cboParcela1PCredito.Enabled = false;
        //            txtCartao1PCredito.Enabled = false;
        //            cboParcela2PCredito.Enabled = false;
        //            txtCartao2PCredito.Enabled = false;
        //        }
        //        if (cboQuantCartaoPCredito.Text == "1")
        //        {
        //            cboParcela1PCredito.Enabled = true;
        //            txtCartao1PCredito.Enabled = true;
        //            cboParcela2PCredito.Enabled = false;
        //            txtCartao2PCredito.Enabled = false;
        //        }
        //        if (cboQuantCartaoPCredito.Text == "2")
        //        {
        //            cboParcela2PCredito.Enabled = true;
        //            txtCartao2PCredito.Enabled = true;
        //            cboParcela1PCredito.Enabled = true;
        //            txtCartao1PCredito.Enabled = true;


        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        private void cboQuantCartaoPDebito_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboQuantCartaoPDebito.Text == " ")
                {
                    txtValor1PDebito.Enabled = false;
                    txtValor2PDebito.Enabled = false;
                }
                if (cboQuantCartaoPDebito.Text == "1")
                {
                    txtValor1PDebito.Enabled = true;
                    txtValor2PDebito.Enabled = false;
                }
                if (cboQuantCartaoPDebito.Text == "2")
                {
                    txtValor1PDebito.Enabled = true;
                    txtValor2PDebito.Enabled = true;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnFinalizarPDebito_Click(object sender, EventArgs e)
        {
            painelDebito.Visible = false;
        }

        private void cboFormas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboFormasPPersonalizar.Text == "À Vista & Crédito")
                {
                    //a vista
                    txtPagoVistaPPersonalizar.Enabled = true;
                    //credito
                    cboQuantCreditoPPersonalizar.Enabled = true;
                    txtPagoCredito1PPersonalizar.Enabled = false;
                    txtPagoCredito2PPersonalizar.Enabled = false;
                    //cboParcela1PPersonalizar.Enabled = false;
                 //   cboParcela2PPersonalizar.Enabled = false;
                    //txtValorParcela1PPersonalizar.Enabled = false;
                  //  txtValorParcela2PPersonalizar.Enabled = false;
                    //debito
                    cboQuantDebitoPPersonalizar.Enabled = false;
                    txtPagoDebito1PPersonalizar.Enabled = false;
                    txtPagoDebito2PPersonalizar.Enabled = false;

                    txtPagoVistaPPersonalizar.Clear();
                    //credito
                    cboQuantCreditoPPersonalizar.Text = " ";
                    txtPagoCredito1PPersonalizar.Clear();
                    txtPagoCredito2PPersonalizar.Clear();
                    //      cboParcela1PPersonalizar.Enabled = false;
                    //     cboParcela2PPersonalizar.Enabled = false;
                    //     txtValorParcela1PPersonalizar.Enabled = false;
                    //   txtValorParcela2PPersonalizar.Enabled = false;
                    //debito
                    cboQuantDebitoPPersonalizar.Text = " ";
                    txtPagoDebito1PPersonalizar.Clear();
                    txtPagoDebito2PPersonalizar.Clear();

                    lblValorCreditoPPersonalizar.Visible = false;
                    lblValorDebitoPPersonalizar.Visible = false;
                    txtValorCreditoPPersonalizar.Visible = false;
                    txtValorDebitoPPersonalizar.Visible = false;

                    txtValorDebitoPPersonalizar.Clear();
                    txtValorCreditoPPersonalizar.Clear();



                }
                if (cboFormasPPersonalizar.Text == "À Vista & Débito")
                {
                    //a vista
                    txtPagoVistaPPersonalizar.Enabled = true;
                    //credito
                    cboQuantCreditoPPersonalizar.Enabled = false;
                    txtPagoCredito1PPersonalizar.Enabled = false;
                    txtPagoCredito2PPersonalizar.Enabled = false;
                    //cboParcela1PPersonalizar.Enabled = false;
                 //   cboParcela2PPersonalizar.Enabled = false;
                 //   txtValorParcela1PPersonalizar.Enabled = false;
                 //   txtValorParcela2PPersonalizar.Enabled = false;
                    //debito
                    cboQuantDebitoPPersonalizar.Enabled = true;
                    txtPagoDebito1PPersonalizar.Enabled = false;
                    txtPagoDebito2PPersonalizar.Enabled = false;

                    txtPagoVistaPPersonalizar.Clear();
                    //credito
                    cboQuantCreditoPPersonalizar.Text = " ";
                    txtPagoCredito1PPersonalizar.Clear();
                    txtPagoCredito2PPersonalizar.Clear();
                    //      cboParcela1PPersonalizar.Enabled = false;
                    //     cboParcela2PPersonalizar.Enabled = false;
                    //     txtValorParcela1PPersonalizar.Enabled = false;
                    //   txtValorParcela2PPersonalizar.Enabled = false;
                    //debito
                    cboQuantDebitoPPersonalizar.Text = " ";
                    txtPagoDebito1PPersonalizar.Clear();
                    txtPagoDebito2PPersonalizar.Clear();

                    lblValorCreditoPPersonalizar.Visible = false;
                    lblValorDebitoPPersonalizar.Visible = false;
                    txtValorCreditoPPersonalizar.Visible = false;
                    txtValorDebitoPPersonalizar.Visible = false;

                    txtValorDebitoPPersonalizar.Clear();
                    txtValorCreditoPPersonalizar.Clear();


                }
                if (cboFormasPPersonalizar.Text == "Crédito & Débito")
                {

                 

                    //a vista
                    txtPagoVistaPPersonalizar.Enabled = false;
                    //credito
                    cboQuantCreditoPPersonalizar.Enabled = true;
                    txtPagoCredito1PPersonalizar.Enabled = false;
                    txtPagoCredito2PPersonalizar.Enabled = false;
                    //cboParcela1PPersonalizar.Enabled = false;
                   // cboParcela2PPersonalizar.Enabled = false;
              //      txtValorParcela1PPersonalizar.Enabled = false;
                //    txtValorParcela2PPersonalizar.Enabled = false;
                    //debito
                    cboQuantDebitoPPersonalizar.Enabled = true;
                    txtPagoDebito1PPersonalizar.Enabled = false;
                    txtPagoDebito2PPersonalizar.Enabled = false;

                    txtPagoVistaPPersonalizar.Clear();
                    //credito
                    cboQuantCreditoPPersonalizar.Text = " ";
                    txtPagoCredito1PPersonalizar.Clear();
                    txtPagoCredito2PPersonalizar.Clear();
                    //      cboParcela1PPersonalizar.Enabled = false;
                    //     cboParcela2PPersonalizar.Enabled = false;
                    //     txtValorParcela1PPersonalizar.Enabled = false;
                    //   txtValorParcela2PPersonalizar.Enabled = false;
                    //debito
                    cboQuantDebitoPPersonalizar.Text = " ";
                    txtPagoDebito1PPersonalizar.Clear();
                    txtPagoDebito2PPersonalizar.Clear();

                    lblValorCreditoPPersonalizar.Visible = true;
                    lblValorDebitoPPersonalizar.Visible = true;
                    txtValorCreditoPPersonalizar.Visible = true;
                    txtValorDebitoPPersonalizar.Visible = true;

                    txtValorDebitoPPersonalizar.Clear();
                    txtValorCreditoPPersonalizar.Clear();




                }
                if (cboFormasPPersonalizar.Text == "À Vista, Crédito & Débito")
                {
                    //a vista
                    txtPagoVistaPPersonalizar.Enabled = true;
                    //credito
                    cboQuantCreditoPPersonalizar.Enabled = true;
                    txtPagoCredito1PPersonalizar.Enabled = false;
                    txtPagoCredito2PPersonalizar.Enabled = false;
                   // cboParcela1PPersonalizar.Enabled = false;
                  //  cboParcela2PPersonalizar.Enabled = false;
                  //  txtValorParcela1PPersonalizar.Enabled = false;
                  //  txtValorParcela2PPersonalizar.Enabled = false;
                    //debito
                    cboQuantDebitoPPersonalizar.Enabled = true;
                    txtPagoDebito1PPersonalizar.Enabled = false;
                    txtPagoDebito2PPersonalizar.Enabled = false;

                    txtPagoVistaPPersonalizar.Clear();
                    //credito
                    cboQuantCreditoPPersonalizar.Text = " ";
                    txtPagoCredito1PPersonalizar.Clear();
                    txtPagoCredito2PPersonalizar.Clear();
                    //      cboParcela1PPersonalizar.Enabled = false;
                    //     cboParcela2PPersonalizar.Enabled = false;
                    //     txtValorParcela1PPersonalizar.Enabled = false;
                    //   txtValorParcela2PPersonalizar.Enabled = false;
                    //debito
                    cboQuantDebitoPPersonalizar.Text = " ";
                    txtPagoDebito1PPersonalizar.Clear();
                    txtPagoDebito2PPersonalizar.Clear();

                    lblValorCreditoPPersonalizar.Visible = true;
                    lblValorDebitoPPersonalizar.Visible = true;
                    txtValorCreditoPPersonalizar.Visible = true;
                    txtValorDebitoPPersonalizar.Visible = true;

                    txtValorDebitoPPersonalizar.Clear();
                    txtValorCreditoPPersonalizar.Clear();


                }
                if (cboFormasPPersonalizar.Text == " ")
                {
                    //a vista
                    txtPagoVistaPPersonalizar.Enabled = false;
                    //credito
                    cboQuantCreditoPPersonalizar.Enabled = false;
                    txtPagoCredito1PPersonalizar.Enabled = false;
                    txtPagoCredito2PPersonalizar.Enabled = false;
              //      cboParcela1PPersonalizar.Enabled = false;
               //     cboParcela2PPersonalizar.Enabled = false;
               //     txtValorParcela1PPersonalizar.Enabled = false;
                 //   txtValorParcela2PPersonalizar.Enabled = false;
                    //debito
                    cboQuantDebitoPPersonalizar.Enabled = false;
                    txtPagoDebito1PPersonalizar.Enabled = false;
                    txtPagoDebito2PPersonalizar.Enabled = false;

                    //a vista
                    txtPagoVistaPPersonalizar.Clear();
                    //credito
                    cboQuantCreditoPPersonalizar.Text = " ";
                    txtPagoCredito1PPersonalizar.Clear();
                    txtPagoCredito2PPersonalizar.Clear();
                    //      cboParcela1PPersonalizar.Enabled = false;
                    //     cboParcela2PPersonalizar.Enabled = false;
                    //     txtValorParcela1PPersonalizar.Enabled = false;
                    //   txtValorParcela2PPersonalizar.Enabled = false;
                    //debito
                    cboQuantDebitoPPersonalizar.Text=" ";
                    txtPagoDebito1PPersonalizar.Clear();
                    txtPagoDebito2PPersonalizar.Clear();

                    lblValorCreditoPPersonalizar.Visible = false;
                    lblValorDebitoPPersonalizar.Visible = false;
                    txtValorCreditoPPersonalizar.Visible = false;
                    txtValorDebitoPPersonalizar.Visible = false;

                    txtValorDebitoPPersonalizar.Clear();
                    txtValorCreditoPPersonalizar.Clear();

                }

            }
            catch (Exception)
            {

              //  throw;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            painelPersonalizar.Visible = false;
        }

        private void cboQuantCreditoPPersonalizar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboQuantCreditoPPersonalizar.Text == " ")
                {
                    txtPagoCredito1PPersonalizar.Enabled = false;
                //    cboParcela1PPersonalizar.Enabled = false;
                    txtPagoCredito2PPersonalizar.Enabled = false;
                  //  cboParcela2PPersonalizar.Enabled = false;
                }
                if (cboQuantCreditoPPersonalizar.Text == "1")
                {
                    txtPagoCredito1PPersonalizar.Enabled = false;
                 //   cboParcela1PPersonalizar.Enabled = true;
                    txtPagoCredito2PPersonalizar.Enabled = false;
                    //  cboParcela2PPersonalizar.Enabled = false;

               //     txtPagoCredito1PPersonalizar.Text = Convert.ToString(txtTotalPPersonalizar.Text);

                    txtPagoCredito2PPersonalizar.Clear();

                   

                    if (txtPago.Text.Trim().Length != 0)
                    {

                        double pago = Convert.ToDouble(txtPagoVistaPPersonalizar.Text);
                        double total = Convert.ToDouble(txtTotal.Text);
                        double totalnovo = total - pago;

                        //txtRestante.Text = Convert.ToString(totalnovo);

                        txtPagoCredito1PPersonalizar.Text = Convert.ToString(totalnovo);


                        if (Convert.ToDouble(txtPagoCredito1PPersonalizar.Text) >= 0)
                        {
                            btnSalvar.Enabled = true;
                        }
                        if (Convert.ToDouble(txtPagoCredito1PPersonalizar.Text) < 0)
                        {
                            btnSalvar.Enabled = false;
                            MessageBox.Show("DINHEIRO PAGO É INSUFICIENTE PARA REALIZAR A COMPRA!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }



                          
                        
                    

                }
                if (cboQuantCreditoPPersonalizar.Text == "2")
                {
                    txtPagoCredito1PPersonalizar.Enabled = true;
                  //  cboParcela1PPersonalizar.Enabled = true;
                    txtPagoCredito2PPersonalizar.Enabled = false;
                 //   cboParcela2PPersonalizar.Enabled = true;


                }
            }
            catch (Exception)
            {

               // throw;
            }
        }

        private void cboParcela1PPersonalizar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboParcela2PPersonalizar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboQuantDebitoPPersonalizar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboQuantDebitoPPersonalizar.Text == " ")
                {
                    txtPagoDebito1PPersonalizar.Enabled = false;
                    txtPagoDebito2PPersonalizar.Enabled = false;
                }
                if (cboQuantDebitoPPersonalizar.Text == "1")
                {
                    txtPagoDebito1PPersonalizar.Enabled = false;
                    txtPagoDebito2PPersonalizar.Enabled = false;
                }
                if (cboQuantDebitoPPersonalizar.Text == "2")
                {
                    txtPagoDebito1PPersonalizar.Enabled = true;
                    txtPagoDebito2PPersonalizar.Enabled = false;
                }


                txtPagoDebito2PPersonalizar.Clear();



                if (txtPago.Text.Trim().Length != 0)
                {

                    double pago = Convert.ToDouble(txtPagoVistaPPersonalizar.Text);
                    double total = Convert.ToDouble(txtTotal.Text);
                    double totalnovo = total - pago;

                    //txtRestante.Text = Convert.ToString(totalnovo);

                    txtPagoDebito1PPersonalizar.Text = Convert.ToString(totalnovo);


                    if (Convert.ToDouble(txtPagoDebito1PPersonalizar.Text) >= 0)
                    {
                        btnSalvar.Enabled = true;
                    }
                    if (Convert.ToDouble(txtPagoDebito1PPersonalizar.Text) < 0)
                    {
                        btnSalvar.Enabled = false;
                        MessageBox.Show("DINHEIRO PAGO É INSUFICIENTE PARA REALIZAR A COMPRA!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
                catch (Exception)
                {

                  //  throw;
                }
        }
        


        private void button1_Click_2(object sender, EventArgs e)
        {
          
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1PDebito_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTroco_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboQuantCartaoPCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboQuantCartaoPCredito.Text == "1")
                {
                   // cboParcela1PCredito.Enabled = true;
                    txtCartao1PCredito.Enabled = true;
                   // cboParcela2PCredito.Enabled = false;
                    txtCartao2PCredito.Enabled = false;

                    btnSalvar.Enabled = true;




                    txtCartao1PCredito.Text = Convert.ToString(txtTotal.Text);
                    txtCartao1PCredito.Enabled = false;

                    txtCartao2PCredito.Clear();

                }
                else
                {
                    txtCartao1PCredito.Enabled = true;
                }
                if (cboQuantCartaoPCredito.Text == " ")
                {

                    txtCartao1PCredito.Clear();
                    txtCartao2PCredito.Clear();

                   // cboParcela1PCredito.Enabled = false;
                    txtCartao1PCredito.Enabled = false;
                   // cboParcela2PCredito.Enabled = false;
                    txtCartao2PCredito.Enabled = false;
                }


                if (cboQuantCartaoPCredito.Text == "2")
                {
                   // cboParcela2PCredito.Enabled = true;
                    txtCartao2PCredito.Enabled = false;
                  //  cboParcela1PCredito.Enabled = true;
                    txtCartao1PCredito.Enabled = true;

                    btnFinalizar.Enabled = false;
                }



            }
            catch (Exception)
            {

                throw;
            }

            if (cboQuantCartaoPCredito.Text == "1")
            {
                btnFinalizar.Enabled = true;
            }
            else if (txtCartao2PCredito.Text == null || cboQuantCartaoPCredito.Text == " ")
            {
                btnFinalizar.Enabled = false;
            }
            

           
        }

        private void txtCartao1PCredito_KeyDown(object sender, KeyEventArgs e)
        {

            if (txtPago.Text.Trim().Length != 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    double pago = Convert.ToDouble(txtCartao1PCredito.Text);
                    double total = Convert.ToDouble(txtTotal.Text);
                    double totalnovo = total - pago;

                    if (totalnovo < 0)
                    {
                        MessageBox.Show("VALOR DIGITADO MAIOR QUE O TOTAL!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCartao1PCredito.Clear();
                        txtCartao2PCredito.Clear();
                    }
                    else
                    {
                        txtCartao2PCredito.Text = Convert.ToString(totalnovo);


                        if (Convert.ToDouble(txtCartao1PCredito.Text) >= 0)
                        {
                            btnSalvar.Enabled = true;
                        }
                        if (Convert.ToDouble(txtCartao1PCredito.Text) < 0)
                        {
                            btnSalvar.Enabled = false;
                            MessageBox.Show("DINHEIRO PAGO É INSUFIENTE PARA REALIZAR A COMPRA!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        double pago2 = Convert.ToDouble(txtCartao2PCredito.Text);
                        double totalpago = pago2 + pago;

                        txtTotalPago.Text = Convert.ToString(totalpago);

                        if (cboQuantCartaoPCredito.Text == "2")
                        {
                            if (txtTotalPago.Text.Equals(txtTotal.Text))
                            {
                                btnFinalizar.Enabled = true;
                            }

                        }
                    }
                }

                    //txtRestante.Text = Convert.ToString(totalnovo);

                    

            }





        }

        private void txtCartao1PCredito_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        //private void txtCartao2PCredito_KeyDown(object sender, KeyEventArgs e)
        //{

            


        //    if (txtPago.Text.Trim().Length != 0)
        //    {
        //        if (e.KeyCode == Keys.Enter)
        //        {
        //          //  double pago = Convert.ToDouble(txtCartao2PCredito.Text);
        //            double total = Convert.ToDouble(txtTotal.Text);
        //            double totalnovo = total - pago;

        //            txtRestante.Text = Convert.ToString(totalnovo);

        //            if (Convert.ToInt32(txtCartao2PCredito.Text) >= 0)
        //            {
        //                btnSalvar.Enabled = true;
        //            }
        //            if (Convert.ToInt32(txtCartao2PCredito.Text) < 0)
        //            {
        //                btnSalvar.Enabled = false;
        //                MessageBox.Show("FALTA PAGAR!");
        //            }

        //        }


        //    }
        //}

        private void cboParcela1PCredito_SelectedIndexChanged(object sender, EventArgs e)
        {

         


        }
        DAL.Produto prod = new DAL.Produto();


        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtCodBarras.Text.Trim().Length == 0)
                {
                    errorProvider1.SetError(txtCodBarras, "Digite um Produto válido");

                }
                else
                {

                    if (txtCodBarras.Text.Trim().Length > 0)
                    {
                     

                        prod.CodigoDeBarras = Convert.ToDecimal (txtCodBarras.Text.Replace("-", ""));
                        
                        System.Data.SqlClient.SqlDataReader dr2;
                        dr2 = prod.Consultar();
                        dr2.Read();
                        if (dr2.HasRows)
                        {
                            strSql = "SELECT Quantidade FROM Produtos WHERE CodigoDeBarras='" + txtCodBarras.Text + "'";
                            sqlCon = new SqlConnection(strCon);
                            sqlCon.Open();
                            SqlCommand comando = new SqlCommand(strSql, sqlCon);
                            SqlDataReader dr = comando.ExecuteReader();
                            dr.Read();
                            int qnt = int.Parse(dr["Quantidade"].ToString());
                            txtNumQuant.Maximum = qnt;

                            this.dataGridView2.DataSource = prod.Listar(this.txtCodBarras.Text.Trim().ToUpper()).Tables[0];
                            this.txtCodBarras.Focus();

                        }
                        dr2.Close();
                    }
                    txtCodBarras.Clear();

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("CÓDIGO INVÁLIDO", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }

        //private void btnAdicionar_Click(object sender, EventArgs e)
        //{
            
        //        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
        //        {
        //            dataGridView1.Rows.Add(dataGridView2.SelectedRows[i].Cells[0].Value.ToString(), dataGridView2.SelectedRows[i].Cells[1].Value.ToString(), txtNumQuant.Value.ToString(), dataGridView2.SelectedRows[i].Cells[3].Value.ToString(), txtValorUnitario.Text);

        //            decimal valor = decimal.Parse(txtValorUnitario.Text);
        //            decimal totalPedido = decimal.Parse(txtValorTotal.Text);
        //            decimal resultado = valor + totalPedido;
        //            txtValorTotal.Text = resultado.ToString();

        //            int qnt = int.Parse(txtNumQuant.Value.ToString());
        //            int itens = int.Parse(txtQuantItens.Text.ToString());
        //            int soma = qnt + itens;
        //            txtQuantItens.Text = soma.ToString();
        //        }
            
        //}

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

           
        }

        private void txtSbTotal_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }


        public void LimparPrimeiroGrid()
        {

            dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);


        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumQuant.Value == 0 || txtNumQuant.Value.ToString().Trim().Equals(""))
                {
                    MessageBox.Show("ESCOLHA A QUANTIDADE!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                    {
                        decimal valorUnitario = decimal.Parse(dataGridView2.SelectedRows[i].Cells[3].Value.ToString());
                        int qnt = int.Parse(txtNumQuant.Value.ToString());
                        decimal resultado = valorUnitario * qnt;
                        txtSbTotal.Text = resultado.ToString();
                    }
                    for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                        {
                        dataGridView1.Rows.Add(dataGridView2.SelectedRows[i].Cells[0].Value.ToString(), dataGridView2.SelectedRows[i].Cells[1].Value.ToString(), dataGridView2.SelectedRows[i].Cells[3].Value.ToString(), txtNumQuant.Text, txtSbTotal.Text);

                        double total = 0;
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            total += Convert.ToDouble(row.Cells["SubTotal"].Value);
                        }
                        txtTotal.Text = Convert.ToString(total);
                        txtSbTotal.Focus();

                        //decimal valor = decimal.Parse(txtSbTotal.Text);
                        //decimal totalPedido = decimal.Parse(txtTotal.Text);


                        //decimal resultado = valor + totalPedido;
                        //txtTotal.Text = resultado.ToString();

                        //int qnt = int.Parse(txtNumQuant.Value.ToString());
                        //int itens = int.Parse(txtQuantItens.Text.ToString());
                        //int soma = qnt + itens;
                        //txtQuantItens.Text = soma.ToString();

                        LimparPrimeiroGrid();
                        txtSbTotal.Clear();
                        txtNumQuant.Value = 1;
                        }
                }
               
                
                
               
            }
            catch (Exception)
            {
               
               // throw;
            }

    
        }

        private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            
          
        }

        private void txtQuant_TextChanged_1(object sender, EventArgs e)
        {


        }

        private void txtQuant_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtNumQuant_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                decimal valorUnitario = decimal.Parse(dataGridView2.SelectedRows[i].Cells[3].Value.ToString());
                int qnt = int.Parse(txtNumQuant.Value.ToString());
                decimal resultado = valorUnitario * qnt;
                txtSbTotal.Text = resultado.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelCredito.Visible = false;

           // txtvalor2PCredito.Clear();
           // txtValor1PCredito.Clear();
           // cboParcela1PCredito.Text = " ";
           // cboParcela2PCredito.Text = " ";
            txtCartao2PCredito.Clear();
            txtCartao1PCredito.Clear();
            cboQuantCartaoPCredito.Text = " ";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            for (int a = 0; a < dataGridView1.Rows.Count - 1; a++)
            {
                sqlCon = new SqlConnection(strCon);
                strSql = "update Produtos set Quantidade = Quantidade - " + dataGridView1.Rows[a].Cells[3].Value.ToString() + " where CodigoDeBarras= '" + dataGridView1.Rows[a].Cells[0].Value.ToString() + "'";
                SqlCommand comando = new SqlCommand(strSql, sqlCon);
                sqlCon.Open();
                comando.ExecuteNonQuery();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void panelCredito_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            panelCredito.Visible = false;

            //txtvalor2PCredito.Clear();
            //txtValor1PCredito.Clear();
            //cboParcela1PCredito.Text = " ";
            //cboParcela2PCredito.Text = " ";
            txtCartao2PCredito.Clear();
            txtCartao1PCredito.Clear();
            cboQuantCartaoPCredito.Text = " ";
        }

        private void txtSbTotal_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtCodBarras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {

                    if (txtCodBarras.Text.Trim().Length == 0)
                    {
                        errorProvider1.SetError(txtCodBarras, "DIGITE UM PRODUTO VÁLIDO!");
                    }
                    else
                    {

                        if (txtCodBarras.Text.Trim().Length > 0)
                        {
                            prod.CodigoDeBarras = Convert.ToDecimal(txtCodBarras.Text.Replace("-", ""));
                            System.Data.SqlClient.SqlDataReader dr2;
                            dr2 = prod.Consultar();
                            dr2.Read();
                            if (dr2.HasRows)
                            {
                                this.dataGridView2.DataSource = prod.Listar(this.txtCodBarras.Text.Trim().ToUpper()).Tables[0];
                                this.txtCodBarras.Focus();

                            }
                            dr2.Close();
                        }

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //throw;
                }
                txtCodBarras.Clear();
            }

        }

        private void txtCodBarras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }

        }

        private void txtPago_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                //troca o . pela virgula
                e.KeyChar = ',';

                //Verifica se já existe alguma vírgula na string
                if (txtPago.Text.Contains(","))
                {
                    e.Handled = true; // Caso exista, aborte 
                }
            }

            //aceita apenas números, tecla backspace.
            else if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }



        }

    private void txtNumQuant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }

        }

        private void txtTotalPCredito_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalPPersonalizar_TextChanged(object sender, EventArgs e)
        {
       
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            painelPersonalizar.Visible = false;
        }

        public void txtPagoVistaPPersonalizar_KeyDown(object sender, KeyEventArgs e)
        {
            
                if (cboFormasPPersonalizar.SelectedItem.ToString() == "À Vista & Crédito")
            {
                if (txtPago.Text.Trim().Length != 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    double pago = Convert.ToDouble(txtPagoVistaPPersonalizar.Text);
                    double total = Convert.ToDouble(txtTotal.Text);
                    double totalnovo = total - pago;

                    //txtRestante.Text = Convert.ToString(totalnovo);

                    txtPagoCredito1PPersonalizar.Text = Convert.ToString(totalnovo);


                    if (Convert.ToDouble(txtPagoCredito1PPersonalizar.Text) >= 0)
                    {
                        btnSalvar.Enabled = true;
                    }
                    if (Convert.ToDouble(txtPagoCredito1PPersonalizar.Text) < 0)
                    {
                        btnSalvar.Enabled = false;
                        MessageBox.Show("DINHEIRO PAGO É INSUFIENTE PARA REALIZAR A COMPRA!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                        txtPagoCredito2PPersonalizar.Clear();
                        txtPagoDebito2PPersonalizar.Clear();


                    }
            }
            }

            if (cboFormasPPersonalizar.SelectedItem.ToString() == "À Vista & Débito")
            {
                if (txtPago.Text.Trim().Length != 0)
                {
                    if (e.KeyCode == Keys.Enter)
                    {


                        double pago = Convert.ToDouble(txtPagoVistaPPersonalizar.Text);
                        double total = Convert.ToDouble(txtTotal.Text);
                        double totalnovo = total - pago;

                        //txtRestante.Text = Convert.ToString(totalnovo);

                        txtPagoDebito1PPersonalizar.Text = Convert.ToString(totalnovo);


                        if (Convert.ToDouble(txtPagoDebito1PPersonalizar.Text) >= 0)
                        {
                            btnSalvar.Enabled = true;
                        }
                        if (Convert.ToDouble(txtPagoDebito1PPersonalizar.Text) < 0)
                        {
                            btnSalvar.Enabled = false;
                            MessageBox.Show("DINHEIRO PAGO É INSUFICIENTE PARA REALIZAR A COMPRA!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        txtPagoDebito2PPersonalizar.Clear();
                        txtPagoCredito2PPersonalizar.Clear();

                    }
                }
            }




        }

        private void txtPagoCredito1PPersonalizar_KeyDown(object sender, KeyEventArgs e)
        {
            if (cboFormasPPersonalizar.SelectedItem.ToString() == "Crédito & Débito")
            {
                if (txtPago.Text.Trim().Length != 0)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        double pago = Convert.ToDouble(txtValorCreditoPPersonalizar.Text);
                        double total = Convert.ToDouble(txtPagoCredito1PPersonalizar.Text);
                        double totalnovo = pago - total;

                        //txtRestante.Text = Convert.ToString(totalnovo);

                        txtPagoCredito2PPersonalizar.Text = Convert.ToString(totalnovo);
                    }
                } 

            }
            else
            {
                if (txtPago.Text.Trim().Length != 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    double pago = Convert.ToDouble(txtPagoVistaPPersonalizar.Text);
                    double total = Convert.ToDouble(txtTotal.Text);
                    double totalnovo = total - pago;
                    double totalnovo1;

                    totalnovo1 = totalnovo - Convert.ToDouble(txtPagoCredito1PPersonalizar.Text);

                    txtPagoCredito2PPersonalizar.Text = Convert.ToString(totalnovo1);
                }

                
            }
            }
               

        }

        private void txtPagoVistaPPersonalizar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                //troca o . pela virgula
                e.KeyChar = ',';

                //Verifica se já existe alguma vírgula na string
                if (txtPagoVistaPPersonalizar.Text.Contains(","))
                {
                    e.Handled = true; // Caso exista, aborte 
                }
            }

            //aceita apenas números, tecla backspace.
            else if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void txtPagoCredito1PPersonalizar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                //troca o . pela virgula
                e.KeyChar = ',';

                //Verifica se já existe alguma vírgula na string
                if (txtPagoCredito1PPersonalizar.Text.Contains(","))
                {
                    e.Handled = true; // Caso exista, aborte 
                }
            }

            //aceita apenas números, tecla backspace.
            else if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void txtPagoCredito2PPersonalizar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                //troca o . pela virgula
                e.KeyChar = ',';

                //Verifica se já existe alguma vírgula na string
                if (txtPagoCredito2PPersonalizar.Text.Contains(","))
                {
                    e.Handled = true; // Caso exista, aborte 
                }
            }

            //aceita apenas números, tecla backspace.
            else if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void txtPagoDebito1PPersonalizar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                //troca o . pela virgula
                e.KeyChar = ',';

                //Verifica se já existe alguma vírgula na string
                if (txtPagoDebito1PPersonalizar.Text.Contains(","))
                {
                    e.Handled = true; // Caso exista, aborte 
                }
            }

            //aceita apenas números, tecla backspace.
            else if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void txtPagoDebito2PPersonalizar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                //troca o . pela virgula
                e.KeyChar = ',';

                //Verifica se já existe alguma vírgula na string
                if (txtPagoDebito2PPersonalizar.Text.Contains(","))
                {
                    e.Handled = true; // Caso exista, aborte 
                }
            }

            //aceita apenas números, tecla backspace.
            else if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void txtPagoDebito1PPersonalizar_KeyDown(object sender, KeyEventArgs e)
        {
            if (cboFormasPPersonalizar.SelectedItem.ToString() == "Crédito & Débito")
            {
                if (txtPago.Text.Trim().Length != 0)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        double pago = Convert.ToDouble(txtValorDebitoPPersonalizar.Text);
                        double total = Convert.ToDouble(txtPagoDebito1PPersonalizar.Text);
                        double totalnovo = pago - total;

                        //txtRestante.Text = Convert.ToString(totalnovo);

                        txtPagoDebito2PPersonalizar.Text = Convert.ToString(totalnovo);
                    }
                }

            }
            else{
                    if (txtPago.Text.Trim().Length != 0)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        double pago = Convert.ToDouble(txtPagoVistaPPersonalizar.Text);
                        double total = Convert.ToDouble(txtTotal.Text);
                        double totalnovo = total - pago;
                        double totalnovo1;

                        totalnovo1 = totalnovo - Convert.ToDouble(txtPagoDebito1PPersonalizar.Text);

                        txtPagoDebito2PPersonalizar.Text = Convert.ToString(totalnovo1);

                    }
                }
            }
          
        }

        private void painelPersonalizar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtValorCreditoPPersonalizar_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtPago.Text.Trim().Length != 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPagoCredito1PPersonalizar.Text = Convert.ToString(txtValorCreditoPPersonalizar.Text);
                    



                    double pago = Convert.ToDouble(txtTotalPPersonalizar.Text);
                    double total = Convert.ToDouble(txtValorCreditoPPersonalizar.Text);
                    double totalnovo = pago - total;

                    //txtRestante.Text = Convert.ToString(totalnovo);

                    txtValorDebitoPPersonalizar.Text = Convert.ToString(totalnovo);

                    txtPagoDebito1PPersonalizar.Text = Convert.ToString(txtValorDebitoPPersonalizar.Text);
                }

            } 
        }

        private void txtCodBarras_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            //ConsultarVendas add = new ConsultarVendas();
            //add.Show();
        }

        private void txtPesquisaCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtPesquisaCliente.Text.Trim().Length != 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (verificarCPF(txtPesquisaCliente.Text))
                    {

                    }
                    else
                    {
                        MessageBox.Show("DIGITE UM CPF VALIDO!", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPesquisaCliente.Clear();
                    }
                }
            }
        }

        private void txtPesquisaCliente_Leave(object sender, EventArgs e)
        {
            if (txtPesquisaCliente.Text.Trim().Length != 0)
            {
                if (verificarCPF(txtPesquisaCliente.Text))
                {

                }
                else
                {
                    MessageBox.Show("DIGITE UM CPF VALIDO!", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPesquisaCliente.Clear();
                }

            }



        }

        private void txtPesquisaCliente_Click(object sender, EventArgs e)
        {
            txtPesquisaCliente.SelectionStart = 0;
        }

        //private void cboQuantCartaoPCredito_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (true)
        //        {

        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //private void btnAdicionar_Click(object sender, EventArgs e)
        //{
        //    {
        //        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
        //        {
        //            dataGridView2.Rows.Add(dataGridView1.SelectedRows[i].Cells[0].Value.ToString(), dataGridView1.SelectedRows[i].Cells[1].Value.ToString(), txtNumQuant.Value.ToString(), dataGridView1.SelectedRows[i].Cells[3].Value.ToString(), txtValorUnitario.Text);

        //            decimal valor = decimal.Parse(txtValorUnitario.Text);
        //            decimal totalPedido = decimal.Parse(txtValorTotal.Text);
        //            decimal resultado = valor + totalPedido;
        //            txtValorTotal.Text = resultado.ToString();

        //            int qnt = int.Parse(txtNumQuant.Value.ToString());
        //            int itens = int.Parse(txtQuantItens.Text.ToString());
        //            int soma = qnt + itens;
        //            txtQuantItens.Text = soma.ToString();
        //        }
        //    }
        //}
    }

}

    
        

