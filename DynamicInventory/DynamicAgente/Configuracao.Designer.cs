namespace DynamicAgente
{
    partial class Configuracao
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuracao));
            this.gbConfiguracoes = new System.Windows.Forms.GroupBox();
            this.lbMinutos = new System.Windows.Forms.Label();
            this.lbTimer = new System.Windows.Forms.Label();
            this.nudTimer = new System.Windows.Forms.NumericUpDown();
            this.tbEndereco = new System.Windows.Forms.TextBox();
            this.lbNomeBanco = new System.Windows.Forms.Label();
            this.tbNomeBanco = new System.Windows.Forms.TextBox();
            this.lbEndereco = new System.Windows.Forms.Label();
            this.tbSenha = new System.Windows.Forms.TextBox();
            this.lbSenha = new System.Windows.Forms.Label();
            this.tbUsuario = new System.Windows.Forms.TextBox();
            this.lbUsuario = new System.Windows.Forms.Label();
            this.gbServico = new System.Windows.Forms.GroupBox();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lbStatus = new System.Windows.Forms.Label();
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbConfiguracoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimer)).BeginInit();
            this.gbServico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbConfiguracoes
            // 
            this.gbConfiguracoes.BackColor = System.Drawing.SystemColors.Window;
            this.gbConfiguracoes.Controls.Add(this.lbMinutos);
            this.gbConfiguracoes.Controls.Add(this.lbTimer);
            this.gbConfiguracoes.Controls.Add(this.nudTimer);
            this.gbConfiguracoes.Controls.Add(this.tbEndereco);
            this.gbConfiguracoes.Controls.Add(this.lbNomeBanco);
            this.gbConfiguracoes.Controls.Add(this.tbNomeBanco);
            this.gbConfiguracoes.Controls.Add(this.lbEndereco);
            this.gbConfiguracoes.Controls.Add(this.tbSenha);
            this.gbConfiguracoes.Controls.Add(this.lbSenha);
            this.gbConfiguracoes.Controls.Add(this.tbUsuario);
            this.gbConfiguracoes.Controls.Add(this.lbUsuario);
            this.gbConfiguracoes.Location = new System.Drawing.Point(12, 12);
            this.gbConfiguracoes.Name = "gbConfiguracoes";
            this.gbConfiguracoes.Size = new System.Drawing.Size(378, 154);
            this.gbConfiguracoes.TabIndex = 7;
            this.gbConfiguracoes.TabStop = false;
            this.gbConfiguracoes.Text = "Configurações";
            // 
            // lbMinutos
            // 
            this.lbMinutos.AutoSize = true;
            this.lbMinutos.Location = new System.Drawing.Point(242, 125);
            this.lbMinutos.Name = "lbMinutos";
            this.lbMinutos.Size = new System.Drawing.Size(44, 13);
            this.lbMinutos.TabIndex = 18;
            this.lbMinutos.Text = "Minutos";
            // 
            // lbTimer
            // 
            this.lbTimer.AutoSize = true;
            this.lbTimer.Location = new System.Drawing.Point(68, 125);
            this.lbTimer.Name = "lbTimer";
            this.lbTimer.Size = new System.Drawing.Size(66, 13);
            this.lbTimer.TabIndex = 17;
            this.lbTimer.Text = "Timer Envio:";
            // 
            // nudTimer
            // 
            this.nudTimer.Location = new System.Drawing.Point(140, 123);
            this.nudTimer.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudTimer.Name = "nudTimer";
            this.nudTimer.Size = new System.Drawing.Size(96, 20);
            this.nudTimer.TabIndex = 4;
            this.nudTimer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudTimer_KeyPress);
            // 
            // tbEndereco
            // 
            this.tbEndereco.Location = new System.Drawing.Point(140, 19);
            this.tbEndereco.Name = "tbEndereco";
            this.tbEndereco.Size = new System.Drawing.Size(229, 20);
            this.tbEndereco.TabIndex = 0;
            // 
            // lbNomeBanco
            // 
            this.lbNomeBanco.AutoSize = true;
            this.lbNomeBanco.Location = new System.Drawing.Point(15, 48);
            this.lbNomeBanco.Name = "lbNomeBanco";
            this.lbNomeBanco.Size = new System.Drawing.Size(119, 13);
            this.lbNomeBanco.TabIndex = 14;
            this.lbNomeBanco.Text = "Nome Banco de dados:";
            // 
            // tbNomeBanco
            // 
            this.tbNomeBanco.Location = new System.Drawing.Point(140, 45);
            this.tbNomeBanco.Name = "tbNomeBanco";
            this.tbNomeBanco.Size = new System.Drawing.Size(229, 20);
            this.tbNomeBanco.TabIndex = 1;
            // 
            // lbEndereco
            // 
            this.lbEndereco.AutoSize = true;
            this.lbEndereco.Location = new System.Drawing.Point(33, 22);
            this.lbEndereco.Name = "lbEndereco";
            this.lbEndereco.Size = new System.Drawing.Size(101, 13);
            this.lbEndereco.TabIndex = 12;
            this.lbEndereco.Text = "Endereço Conexão:";
            // 
            // tbSenha
            // 
            this.tbSenha.Location = new System.Drawing.Point(140, 97);
            this.tbSenha.Name = "tbSenha";
            this.tbSenha.PasswordChar = '*';
            this.tbSenha.Size = new System.Drawing.Size(141, 20);
            this.tbSenha.TabIndex = 3;
            // 
            // lbSenha
            // 
            this.lbSenha.AutoSize = true;
            this.lbSenha.Location = new System.Drawing.Point(48, 100);
            this.lbSenha.Name = "lbSenha";
            this.lbSenha.Size = new System.Drawing.Size(86, 13);
            this.lbSenha.TabIndex = 10;
            this.lbSenha.Text = "Senha Conexão:";
            // 
            // tbUsuario
            // 
            this.tbUsuario.Location = new System.Drawing.Point(140, 71);
            this.tbUsuario.Name = "tbUsuario";
            this.tbUsuario.Size = new System.Drawing.Size(141, 20);
            this.tbUsuario.TabIndex = 2;
            // 
            // lbUsuario
            // 
            this.lbUsuario.AutoSize = true;
            this.lbUsuario.Location = new System.Drawing.Point(43, 74);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(91, 13);
            this.lbUsuario.TabIndex = 8;
            this.lbUsuario.Text = "Usuario Conexão:";
            // 
            // gbServico
            // 
            this.gbServico.BackColor = System.Drawing.SystemColors.Window;
            this.gbServico.Controls.Add(this.btnReiniciar);
            this.gbServico.Controls.Add(this.btnStop);
            this.gbServico.Controls.Add(this.btnStart);
            this.gbServico.Location = new System.Drawing.Point(12, 172);
            this.gbServico.Name = "gbServico";
            this.gbServico.Size = new System.Drawing.Size(378, 56);
            this.gbServico.TabIndex = 8;
            this.gbServico.TabStop = false;
            this.gbServico.Text = "Serviço";
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.FlatAppearance.BorderSize = 0;
            this.btnReiniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReiniciar.Image = global::DynamicAgente.Properties.Resources.refresh_update;
            this.btnReiniciar.Location = new System.Drawing.Point(233, 18);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(75, 28);
            this.btnReiniciar.TabIndex = 2;
            this.btnReiniciar.UseVisualStyleBackColor = true;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            // 
            // btnStop
            // 
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Image = global::DynamicAgente.Properties.Resources.action_stop;
            this.btnStop.Location = new System.Drawing.Point(152, 17);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 29);
            this.btnStop.TabIndex = 1;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Image = global::DynamicAgente.Properties.Resources.action_play;
            this.btnStart.Location = new System.Drawing.Point(71, 18);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 28);
            this.btnStart.TabIndex = 0;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.BackColor = System.Drawing.SystemColors.Window;
            this.lbStatus.Location = new System.Drawing.Point(12, 231);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(137, 13);
            this.lbStatus.TabIndex = 9;
            this.lbStatus.Text = "Status DynamicService: {0}";
            // 
            // timerStatus
            // 
            this.timerStatus.Enabled = true;
            this.timerStatus.Tick += new System.EventHandler(this.timerStatus_Tick);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnCancelar.Image = global::DynamicAgente.Properties.Resources.cancel;
            this.btnCancelar.Location = new System.Drawing.Point(204, 247);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(99, 27);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnSalvar.Image = global::DynamicAgente.Properties.Resources.save;
            this.btnSalvar.Location = new System.Drawing.Point(99, 247);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(99, 27);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(402, 302);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Configuracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 298);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.gbServico);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.gbConfiguracoes);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Configuracao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuracao";
            this.Load += new System.EventHandler(this.Configuracao_Load);
            this.gbConfiguracoes.ResumeLayout(false);
            this.gbConfiguracoes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimer)).EndInit();
            this.gbServico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox gbConfiguracoes;
        private System.Windows.Forms.TextBox tbEndereco;
        private System.Windows.Forms.Label lbNomeBanco;
        private System.Windows.Forms.TextBox tbNomeBanco;
        private System.Windows.Forms.Label lbEndereco;
        private System.Windows.Forms.TextBox tbSenha;
        private System.Windows.Forms.Label lbSenha;
        private System.Windows.Forms.TextBox tbUsuario;
        private System.Windows.Forms.Label lbUsuario;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label lbTimer;
        private System.Windows.Forms.NumericUpDown nudTimer;
        private System.Windows.Forms.GroupBox gbServico;
        private System.Windows.Forms.Button btnReiniciar;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Timer timerStatus;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lbMinutos;
    }
}