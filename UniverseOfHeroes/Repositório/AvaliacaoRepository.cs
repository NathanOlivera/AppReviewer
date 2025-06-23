using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverseOfHeroes.Entidade;

namespace UniverseOfHeroes.Repositório
{
    internal class AvaliacaoRepository
    {
        private readonly string _connectionString;

        public AvaliacaoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool SalvarAvaliacao(string email, int idFilme, int nota, string text)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
                INSERT INTO avaliacao (email_usuario, id_filme, nota, text)
                VALUES (@Email, @IdFilme, @Nota, @text)
                ON DUPLICATE KEY UPDATE nota = @Nota";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@IdFilme", idFilme);
                    cmd.Parameters.AddWithValue("@Nota", nota);
                    cmd.Parameters.AddWithValue("@text", text);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public int? ObterNotaDoUsuario(string email, int idFilme)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT nota FROM avaliacao WHERE email_usuario = @Email AND id_filme = @IdFilme";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@IdFilme", idFilme);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                }
            }
            return null; // Nenhuma avaliação encontrada
        }
        public List<Avaliacao> ObterAvaliacoes(int idFilme)
        {

            List<Avaliacao> avaliacoes = new List<Avaliacao>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT (SELECT username FROM usuario WHERE usuario.email=avaliacao.email_usuario )AS username, nota, text FROM avaliacao where id_filme=@Id;";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", idFilme);

                    using (var reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            avaliacoes.Add(new Avaliacao
                            {
                                Nota = reader.GetInt32("nota"),
                                Username = reader.GetString("username"),
                                Text = reader.GetString("text")
                            });
                        }
                        
                    }
                }
            }
            return avaliacoes;
        }
    }

}
