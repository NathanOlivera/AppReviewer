using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Org.BouncyCastle.Asn1;
using UniverseOfHeroes.Entidade;
using UniverseOfHeroes.Repositório;
using UniverseOfHeroes.Util;
using Timer = System.Windows.Forms.Timer;


namespace UniverseOfHeroes.Forms
{
    internal partial class MainForm : Form
    {
        private Usuario usuarioLogado;
        private List<Filme> filmes;
        private int indiceAtual = 0;
        private int indiceComment = 0;
        bool lampadaLigada = false;

        private Timer timer;
        private Image spriteSheet;
        private int frameWidth = 128;
        private int frameHeight = 128;
        private int currentFrame = 0;
        private int totalFrames = 4;
        private int xPosition = 0;
        private int yPosition = 0;

        public MainForm(Usuario usuario)
        {
            usuarioLogado = usuario;
            InitializeComponent();

            spriteSheet = Image.FromFile("C:\\Users\\GATEWAY\\Documents\\Programação\\LP4\\SideWalk_Orange.png");
            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();
            yPosition = this.ClientSize.Height - frameHeight;
            this.DoubleBuffered = true;
            this.Paint += Form1_Paint;
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms["LoginForm"]?.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FilmeRepository repo = new FilmeRepository(DbUtil.ConnectionString);
            filmes = repo.ObterTodosFilmes();
            ExibirFilme();

            List<PictureBox> pictureBoxes = new List<PictureBox> { l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13 };
            for (int i = 0; i<13; i++)
            {
                pictureBoxes[i].Image = Properties.Resources.luzapagada;
            }
            piscar.Start();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (indiceAtual > 0)
            {
                indiceAtual--;
                ExibirFilme();
            }
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            if (indiceAtual < filmes.Count - 1)
            {
                indiceAtual++;
                ExibirFilme();
            }
        }
        private void BtnAvaliar_Click(object sender, EventArgs e)
        {
            if (filmes == null || filmes.Count == 0) return;

            int nota = Convert.ToInt32(cmbNota.SelectedItem.ToString());
            int idFilme = filmes[indiceAtual].Id;
            string email = usuarioLogado.Email;
            string text = textRev.Text;

            AvaliacaoRepository repo = new AvaliacaoRepository(DbUtil.ConnectionString);
            bool sucesso = repo.SalvarAvaliacao(email, idFilme, nota, text);

            lblMensagem.ForeColor = sucesso ? Color.LightGreen : Color.OrangeRed;
            lblMensagem.Text = sucesso ? "Avaliação registrada." : "Erro ao registrar avaliação.";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExibirComments(true);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ExibirComments(false);
        }

        private void ExibirFilme()
        {
            if (filmes == null || filmes.Count == 0) return;

            Filme filme = filmes[indiceAtual];

            lblNome.Text = filme.Nome;
            lblData.Text = $"Lançamento: {filme.DataLancamento:dd/MM/yyyy}";
            lblDescricao.Text = filme.Descricao;
            pictureFilme.Image = ImageUtil.ConverterBytesParaImagem(filme.Imagem);

            btnAnterior.Enabled = indiceAtual > 0;
            btnProximo.Enabled = indiceAtual < filmes.Count - 1;

            // Buscar e exibir nota do usuário
            AvaliacaoRepository repo = new AvaliacaoRepository(DbUtil.ConnectionString);
            int? nota = repo.ObterNotaDoUsuario(usuarioLogado.Email, filme.Id);
            ExibirComments(true);

            if (nota.HasValue)
            {
                cmbNota.SelectedItem = nota.Value.ToString();
                lblMensagem.ForeColor = Color.LightGray;
                lblMensagem.Text = "Sua nota anterior: " + nota.Value;
            }
            else
            {
                cmbNota.SelectedItem = "5"; // Valor padrão
                lblMensagem.Text = "";
            }

        }

        private void ExibirComments(bool direction)
        {
            Filme filme = filmes[indiceAtual];
            AvaliacaoRepository repo = new AvaliacaoRepository(DbUtil.ConnectionString);
            List<Avaliacao> avaliacoes = repo.ObterAvaliacoes(filme.Id);

            List<Label> nicks = new List<Label> { nick1, nick2, nick3 };
            List<TextBox> comments = new List<TextBox> { comment1, comment2, comment3 };

            if (direction)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (indiceComment < avaliacoes.Count)
                    {
                        nicks[i].Text = avaliacoes[indiceComment].Username;
                        comments[i].Text = avaliacoes[indiceComment].Text;
                        Exibirnota(i, avaliacoes[indiceComment].Nota);
                        indiceComment++;
                    }
                }
            }
            else
            {
                for (int f = 2; f >= 0; f--)
                {
                    if (indiceComment > 0)
                    {
                        indiceComment--;
                        nicks[f].Text = avaliacoes[indiceComment].Username;
                        comments[f].Text = avaliacoes[indiceComment].Text;
                        Exibirnota(f, avaliacoes[indiceComment].Nota);
                    }
                }
            }
        }

        private void Exibirnota(int pos, int nota)
        {
            List<List<PictureBox>> notas = new List<List<PictureBox>> {
                new List<PictureBox> { p1, p2, p3, p4, p5 },
                new List<PictureBox> { s1, s2, s3, s4, s5 },
                new List<PictureBox> { t1, t2, t3, t4, t5 }
            };

            for (int a = 0; a < 5; a++)
            {
                notas[pos][a].Visible = false;
            }

            for (int i = 0; i < nota; i++)
            {
                notas[pos][i].Visible = true;
            }
        }

        private void piscar_Tick(object sender, EventArgs e)
        {
            List<PictureBox> pictureBoxes = new List<PictureBox> { l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13 };
            if (lampadaLigada)
            {
                for (int i = 0; i < 13; i++)
                {
                    pictureBoxes[i].Image = Properties.Resources.luzapagada;
                }
                lampadaLigada = false;
            }
            else
            {
                for (int i = 0; i < 13; i++)
                {
                    pictureBoxes[i].Image = Properties.Resources.Luzacesa;
                }
                lampadaLigada = true;
            }

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            currentFrame++;
            if (currentFrame >= totalFrames)
                currentFrame = 0;
            xPosition += 5;
            if (xPosition > this.ClientSize.Width)
                xPosition = -frameWidth;

            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle sourceRect = new Rectangle(currentFrame * frameWidth, 0, frameWidth, frameHeight);
            Rectangle destRect = new Rectangle(xPosition, yPosition, frameWidth, frameHeight);
            e.Graphics.DrawImage(spriteSheet, destRect, sourceRect, GraphicsUnit.Pixel);
        }
    }
}
