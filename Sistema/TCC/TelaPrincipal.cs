using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCC
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();
           

        }

        private void TelaPrincipal_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToLongDateString();
            

        }



        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DesejaSair frm = new DesejaSair();
            frm.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToLongTimeString();
        }

        public void AbrirCliente(object o, EventArgs e)
        {

        }
        public void AbrirEstoque(object o, EventArgs e)
        {
            addproduto add = new addproduto();
            add.ShowDialog();
        }
        public void AbrirFornecedor(object o, EventArgs e)
        {
            addfornecedor add = new addfornecedor();
            add.ShowDialog();
        }
        public void Abrirfuncionario(object o, EventArgs e)
        {
            addfuncionario add = new addfuncionario();
            add.ShowDialog();
        }
        public void AbrirProduto(object o, EventArgs e)
        {
            addproduto add = new addproduto();
            add.ShowDialog();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lançarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addlancarcontas add = new addlancarcontas();
            add.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void gerenciarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addestoque add = new addestoque();
            add.ShowDialog();
        }

        private void cadastroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addcliente add = new addcliente();
            add.ShowDialog();
        }

        private void gerenciarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ResponderEmails add = new ResponderEmails();
            add.ShowDialog();
        }

        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    
       


        private void btnSair_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DesejaSair frm = new DesejaSair();
                frm.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelD.Visible = true;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void consultarToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void consultarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ConsultarVendas frm = new ConsultarVendas();
            frm.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void consultarToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            addFale frm = new addFale();
            frm.ShowDialog();
        }

        private void consultarToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            ConsultarFuncionario frm = new ConsultarFuncionario();
            frm.ShowDialog();
        }

        private void consultarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ConsultarCliente frm = new ConsultarCliente();
            frm.ShowDialog();
        }

        private void consultarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ConsultarFornecedor frm = new ConsultarFornecedor();
            frm.ShowDialog();
        }

        private void consultarToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            ConsultarEncomendas form = new ConsultarEncomendas();
            form.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelD.Visible = false;
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
