using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniverseOfHeroes.Entidade;
using UniverseOfHeroes.Repositório;
using UniverseOfHeroes.Util;

namespace UniverseOfHeroes.Forms
{
    internal partial class SignInForm : Form
    {
        public SignInForm()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string username = txtUsername.Text.Trim();
            string senha = txtSenha.Text;
            string confirmarSenha = txtConfirmarSenha.Text;

            lblMensagem.ForeColor = Color.Red;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(senha) || string.IsNullOrWhiteSpace(confirmarSenha))
            {
                lblMensagem.Text = "Preencha todos os campos.";
                return;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                lblMensagem.Text = "Email inválido.";
                return;
            }

            if (senha.Length < 6)
            {
                lblMensagem.Text = "A senha deve ter pelo menos 6 caracteres.";
                return;
            }

            if (username.Length < 3)
            {
                lblMensagem.Text = "O nome de usuário deve ter pelo menos 3 caracteres.";
                return;
            }

            if (senha != confirmarSenha)
            {
                lblMensagem.Text = "As senhas não coincidem.";
                return;
            }

            UsuarioRepository repo = new UsuarioRepository(DbUtil.ConnectionString);
            Usuario novoUsuario = new Usuario
            {
                Email = email,
                Username = username,
                Senha = senha
            };

            try
            {
                int linhas = repo.InserirUsuario(novoUsuario);
                if (linhas > 0)
                {
                    lblMensagem.ForeColor = Color.Green;
                    lblMensagem.Text = "Usuário cadastrado com sucesso!";
                    LimparCampos();
                }
                else
                {
                    lblMensagem.Text = "Erro ao cadastrar.";
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex) 
            {
                if (ex.Number == 1062)
                    lblMensagem.Text = "Já existe um usuário com este e-mail.";
            }
            catch (Exception ex)
            {
                lblMensagem.Text = "Erro inesperado: " + ex.Message;
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimparCampos()
        {
            txtEmail.Text = "";
            txtUsername.Text = "";
            txtSenha.Text = "";
            txtConfirmarSenha.Text = "";
        }



    }
}
