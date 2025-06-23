namespace UniverseOfHeroes.Forms
{
    partial class LoginForm
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
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblSenha = new Label();
            txtSenha = new TextBox();
            btnEntrar = new Button();
            btnCadastrar = new Button();
            btnSair = new Button();
            SuspendLayout();
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(50, 53);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(41, 19);
            lblEmail.TabIndex = 0;
            lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(40, 40, 40);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.ForeColor = Color.White;
            txtEmail.Location = new Point(120, 51);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(220, 25);
            txtEmail.TabIndex = 1;
            txtEmail.TextChanged += txtEmail_TextChanged;
            // 
            // lblSenha
            // 
            lblSenha.AutoSize = true;
            lblSenha.Location = new Point(50, 98);
            lblSenha.Name = "lblSenha";
            lblSenha.Size = new Size(46, 19);
            lblSenha.TabIndex = 2;
            lblSenha.Text = "Senha";
            // 
            // txtSenha
            // 
            txtSenha.BackColor = Color.FromArgb(40, 40, 40);
            txtSenha.BorderStyle = BorderStyle.FixedSingle;
            txtSenha.ForeColor = Color.White;
            txtSenha.Location = new Point(120, 96);
            txtSenha.Name = "txtSenha";
            txtSenha.PasswordChar = '*';
            txtSenha.Size = new Size(220, 25);
            txtSenha.TabIndex = 3;
            // 
            // btnEntrar
            // 
            btnEntrar.BackColor = Color.FromArgb(77, 0, 79);
            btnEntrar.FlatAppearance.BorderSize = 0;
            btnEntrar.FlatStyle = FlatStyle.Flat;
            btnEntrar.ForeColor = Color.White;
            btnEntrar.Location = new Point(50, 165);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(100, 35);
            btnEntrar.TabIndex = 4;
            btnEntrar.Text = "Entrar";
            btnEntrar.UseVisualStyleBackColor = false;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // btnCadastrar
            // 
            btnCadastrar.BackColor = Color.Gray;
            btnCadastrar.FlatAppearance.BorderSize = 0;
            btnCadastrar.FlatStyle = FlatStyle.Flat;
            btnCadastrar.ForeColor = Color.White;
            btnCadastrar.Location = new Point(160, 165);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(100, 35);
            btnCadastrar.TabIndex = 5;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = false;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // btnSair
            // 
            btnSair.BackColor = Color.DimGray;
            btnSair.FlatAppearance.BorderSize = 0;
            btnSair.FlatStyle = FlatStyle.Flat;
            btnSair.ForeColor = Color.White;
            btnSair.Location = new Point(270, 165);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(100, 35);
            btnSair.TabIndex = 6;
            btnSair.Text = "Sair";
            btnSair.UseVisualStyleBackColor = false;
            btnSair.Click += btnSair_Click;
            // 
            // LoginForm
            // 
            BackColor = Color.FromArgb(15, 15, 15);
            ClientSize = new Size(400, 250);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblSenha);
            Controls.Add(txtSenha);
            Controls.Add(btnEntrar);
            Controls.Add(btnCadastrar);
            Controls.Add(btnSair);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblSenha;
        private TextBox txtSenha;
        private Button btnEntrar;
        private Button btnCadastrar;
        private Button btnSair;
    }
}