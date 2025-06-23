using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverseOfHeroes.Entidade;

namespace UniverseOfHeroes.Repositório
{
    internal class FilmeRepository
    {
        private readonly string _connectionString;

        public FilmeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Filme> ObterTodosFilmes()
        {
            List<Filme> filmes = new List<Filme>();

            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT id, nome, data_lancamento, descricao, imagem FROM filme";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        filmes.Add(new Filme
                        {
                            Id = reader.GetInt32("id"),
                            Nome = reader.GetString("nome"),
                            DataLancamento = reader.GetDateTime("data_lancamento"),
                            Descricao = reader.GetString("descricao"),
                            Imagem = reader["imagem"] as byte[]
                        });
                    }
                }
            }

            return filmes;
        }
    }
}
