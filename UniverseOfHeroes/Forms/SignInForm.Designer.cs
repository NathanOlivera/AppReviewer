namespace UniverseOfHeroes.Forms
{
    partial class SignInForm
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
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblSenha = new Label();
            txtSenha = new TextBox();
            lblConfirmarSenha = new Label();
            txtConfirmarSenha = new TextBox();
            lblMensagem = new Label();
            btnCadastrar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(30, 30);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(44, 19);
            lblEmail.TabIndex = 0;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(40, 40, 40);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.ForeColor = Color.White;
            txtEmail.Location = new Point(189, 28);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(171, 25);
            txtEmail.TabIndex = 1;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(30, 70);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(117, 19);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Nome de usuário:";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(40, 40, 40);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.ForeColor = Color.White;
            txtUsername.Location = new Point(189, 68);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(171, 25);
            txtUsername.TabIndex = 3;
            // 
            // lblSenha
            // 
            lblSenha.AutoSize = true;
            lblSenha.Location = new Point(30, 110);
            lblSenha.Name = "lblSenha";
            lblSenha.Size = new Size(49, 19);
            lblSenha.TabIndex = 4;
            lblSenha.Text = "Senha:";
            // 
            // txtSenha
            // 
            txtSenha.BackColor = Color.FromArgb(40, 40, 40);
            txtSenha.BorderStyle = BorderStyle.FixedSingle;
            txtSenha.ForeColor = Color.White;
            txtSenha.Location = new Point(189, 108);
            txtSenha.Name = "txtSenha";
            txtSenha.PasswordChar = '*';
            txtSenha.Size = new Size(171, 25);
            txtSenha.TabIndex = 5;
            // 
            // lblConfirmarSenha
            // 
            lblConfirmarSenha.AutoSize = true;
            lblConfirmarSenha.Location = new Point(30, 150);
            lblConfirmarSenha.Name = "lblConfirmarSenha";
            lblConfirmarSenha.Size = new Size(113, 19);
            lblConfirmarSenha.TabIndex = 6;
            lblConfirmarSenha.Text = "Confirmar senha:";
            // 
            // txtConfirmarSenha
            // 
            txtConfirmarSenha.BackColor = Color.FromArgb(40, 40, 40);
            txtConfirmarSenha.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmarSenha.ForeColor = Color.White;
            txtConfirmarSenha.Location = new Point(189, 148);
            txtConfirmarSenha.Name = "txtConfirmarSenha";
            txtConfirmarSenha.PasswordChar = '*';
            txtConfirmarSenha.Size = new Size(171, 25);
            txtConfirmarSenha.TabIndex = 7;
            // 
            // lblMensagem
            // 
            lblMensagem.ForeColor = Color.Red;
            lblMensagem.Location = new Point(30, 185);
            lblMensagem.Name = "lblMensagem";
            lblMensagem.Size = new Size(330, 30);
            lblMensagem.TabIndex = 8;
            // 
            // btnCadastrar
            // 
            btnCadastrar.BackColor = Color.FromArgb(77, 0, 79);
            btnCadastrar.FlatAppearance.BorderSize = 0;
            btnCadastrar.FlatStyle = FlatStyle.Flat;
            btnCadastrar.ForeColor = Color.White;
            btnCadastrar.Location = new Point(50, 230);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(120, 35);
            btnCadastrar.TabIndex = 9;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = false;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.DimGray;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(200, 230);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(120, 35);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // SignInForm
            // 
            BackColor = Color.FromArgb(15, 15, 15);
            ClientSize = new Size(400, 320);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblUsername);
            Controls.Add(txtUsername);
            Controls.Add(lblSenha);
            Controls.Add(txtSenha);
            Controls.Add(lblConfirmarSenha);
            Controls.Add(txtConfirmarSenha);
            Controls.Add(lblMensagem);
            Controls.Add(btnCadastrar);
            Controls.Add(btnCancelar);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "SignInForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Usuário";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblEmail, lblUsername, lblSenha, lblConfirmarSenha, lblMensagem;
        private TextBox txtEmail, txtUsername, txtSenha, txtConfirmarSenha;
        private Button btnCadastrar, btnCancelar;

        #endregion
    }
}