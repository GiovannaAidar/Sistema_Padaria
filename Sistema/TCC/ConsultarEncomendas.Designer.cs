namespace TCC
{
    partial class ConsultarEncomendas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultarEncomendas));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtOcasioes = new System.Windows.Forms.TextBox();
            this.mskNascimento = new System.Windows.Forms.DateTimePicker();
            this.btnEmail = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnData = new System.Windows.Forms.Button();
            this.btnID = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.btnOcasioes = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvEncomendas = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEncomendas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtOcasioes);
            this.groupBox1.Controls.Add(this.mskNascimento);
            this.groupBox1.Controls.Add(this.btnEmail);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.btnData);
            this.groupBox1.Controls.Add(this.btnID);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.btnOcasioes);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dgvEncomendas);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(873, 509);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consultar Encomendas";
            // 
            // txtOcasioes
            // 
            this.txtOcasioes.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOcasioes.Location = new System.Drawing.Point(207, 66);
            this.txtOcasioes.Name = "txtOcasioes";
            this.txtOcasioes.Size = new System.Drawing.Size(273, 33);
            this.txtOcasioes.TabIndex = 4;
            this.txtOcasioes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOcasioes_KeyDown);
            // 
            // mskNascimento
            // 
            this.mskNascimento.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskNascimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskNascimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.mskNascimento.Location = new System.Drawing.Point(296, 112);
            this.mskNascimento.Name = "mskNascimento";
            this.mskNascimento.Size = new System.Drawing.Size(148, 31);
            this.mskNascimento.TabIndex = 10;
            this.mskNascimento.ValueChanged += new System.EventHandler(this.mskNascimento_ValueChanged);
            this.mskNascimento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mskNascimento_KeyDown);
            // 
            // btnEmail
            // 
            this.btnEmail.BackgroundImage = global::TCC.Properties.Resources.search_circular_symbol_icon_icons_com_53800;
            this.btnEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmail.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnEmail.Location = new System.Drawing.Point(688, 21);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(46, 41);
            this.btnEmail.TabIndex = 2;
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(97, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "E-mail:";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(207, 24);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(475, 33);
            this.txtEmail.TabIndex = 1;
            this.txtEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmail_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(553, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "ID:";
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(605, 69);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(77, 33);
            this.txtID.TabIndex = 6;
            this.txtID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtID_KeyDown);
            // 
            // btnData
            // 
            this.btnData.BackgroundImage = global::TCC.Properties.Resources.search_circular_symbol_icon_icons_com_53800;
            this.btnData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnData.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnData.Location = new System.Drawing.Point(450, 107);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(46, 41);
            this.btnData.TabIndex = 11;
            this.btnData.UseVisualStyleBackColor = true;
            this.btnData.Click += new System.EventHandler(this.btnData_Click);
            // 
            // btnID
            // 
            this.btnID.BackgroundImage = global::TCC.Properties.Resources.search_circular_symbol_icon_icons_com_53800;
            this.btnID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnID.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnID.Location = new System.Drawing.Point(688, 64);
            this.btnID.Name = "btnID";
            this.btnID.Size = new System.Drawing.Size(46, 41);
            this.btnID.TabIndex = 7;
            this.btnID.UseVisualStyleBackColor = true;
            this.btnID.Click += new System.EventHandler(this.btnID_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(97, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "Ocasiões:";
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::TCC.Properties.Resources._666481;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(817, 105);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 48);
            this.button4.TabIndex = 12;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnOcasioes
            // 
            this.btnOcasioes.BackgroundImage = global::TCC.Properties.Resources.search_circular_symbol_icon_icons_com_53800;
            this.btnOcasioes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOcasioes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOcasioes.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnOcasioes.Location = new System.Drawing.Point(486, 64);
            this.btnOcasioes.Name = "btnOcasioes";
            this.btnOcasioes.Size = new System.Drawing.Size(46, 41);
            this.btnOcasioes.TabIndex = 5;
            this.btnOcasioes.UseVisualStyleBackColor = true;
            this.btnOcasioes.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(97, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Data de Entrega:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dgvEncomendas
            // 
            this.dgvEncomendas.AllowUserToAddRows = false;
            this.dgvEncomendas.AllowUserToDeleteRows = false;
            this.dgvEncomendas.AllowUserToOrderColumns = true;
            this.dgvEncomendas.ColumnHeadersHeight = 35;
            this.dgvEncomendas.Location = new System.Drawing.Point(6, 156);
            this.dgvEncomendas.Name = "dgvEncomendas";
            this.dgvEncomendas.ReadOnly = true;
            this.dgvEncomendas.RowHeadersWidth = 50;
            this.dgvEncomendas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEncomendas.Size = new System.Drawing.Size(861, 344);
            this.dgvEncomendas.TabIndex = 13;
            this.dgvEncomendas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEncomendas_CellContentClick);
            this.dgvEncomendas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEncomendas_CellDoubleClick);
            // 
            // ConsultarEncomendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(897, 520);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConsultarEncomendas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PADARIA ALAMEDA";
            this.Load += new System.EventHandler(this.ConsultarEncomendas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEncomendas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnData;
        private System.Windows.Forms.Button btnID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnOcasioes;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DataGridView dgvEncomendas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.DateTimePicker mskNascimento;
        private System.Windows.Forms.TextBox txtOcasioes;
    }
}