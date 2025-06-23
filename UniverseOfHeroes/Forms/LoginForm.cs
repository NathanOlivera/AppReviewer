using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniverseOfHeroes.Entidade;
using UniverseOfHeroes.Repositório;
using UniverseOfHeroes.Util;

namespace UniverseOfHeroes.Forms
{
    internal partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string senha = txtSenha.Text;

            UsuarioRepository repo = new UsuarioRepository(DbUtil.ConnectionString);
            Usuario usuario = repo.ObterPorEmailESenha(email, senha);

            if (usuario != null)
            {
                MainForm main = new MainForm(usuario);
                this.Hide();
                main.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Credenciais inválidas.");
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            SignInForm signIn = new SignInForm();
            signIn.ShowDialog();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
