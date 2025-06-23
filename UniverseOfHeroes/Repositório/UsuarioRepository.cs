using MySql.Data.MySqlClient;
using UniverseOfHeroes.Entidade;

namespace UniverseOfHeroes.Repositório
{
    internal class UsuarioRepository
    {
        private readonly string _connectionString;

        public UsuarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Usuario ObterPorEmailESenha(string email, string senha)
        {
            Usuario usuario = null;
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT email, username, senha FROM usuario WHERE email = @Email AND senha = @Senha";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Senha", senha);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = new Usuario
                            {
                                Email = reader.GetString("email"),
                                Username = reader.GetString("username"),
                                Senha = reader.GetString("senha")
                            };
                        }
                    }
                }
            }
            return usuario;
        }

        public int InserirUsuario(Usuario usuario)
        {
            int linhasAfetadas = -1;
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO usuario (email, username, senha) VALUES (@Email, @Username, @Senha)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", usuario.Email);
                    command.Parameters.AddWithValue("@Username", usuario.Username);
                    command.Parameters.AddWithValue("@Senha", usuario.Senha);
                    linhasAfetadas = command.ExecuteNonQuery();
                }
            }
            return linhasAfetadas;
        }
    }

}
