using IAE.Entidades.Entidades;
using IAE.Repositorio.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Repositorio.Repositories
{
	public class QuestaoRepository : BaseRepository<Questao>, IQuestaoRepository
	{
		public QuestaoRepository(IConfiguration config) : base(config)
		{
		}

		public override Questao Insert(Questao item)
		{
			using (var connection = new SQLiteConnection(_connectionString))
			{
				connection.Open();
                var query = "INSERT INTO Questao (Enunciado, AvaliacaoId) VALUES (@Enunciado, @AvaliacaoId);";
                var command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@Enunciado", item.Enunciado);
                command.Parameters.AddWithValue("@AvaliacaoId", item.AvaliacaoId);
                command.ExecuteNonQuery();
                return item;
			}
		}

		public override int Insert(IList<Questao> items)
		{
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                foreach (var item in items)
                {
                    var query = "INSERT INTO Questao (Enunciado, AvaliacaoId) VALUES (@Enunciado, @AvaliacaoId);";
                    var command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("@Enunciado", item.Enunciado);
                    command.Parameters.AddWithValue("@AvaliacaoId", item.AvaliacaoId);
                    command.ExecuteNonQuery();
                }
                return items.Count;
            }
        }

		public override Questao Update(Questao item)
		{
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var query = "UPDATE Questao SET Enunciado = @Enunciado, AvaliacaoId = @AvaliacaoId WHERE Id = @Id;";
                var command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@Id", item.Id);
                command.Parameters.AddWithValue("@Enunciado", item.Enunciado);
                command.Parameters.AddWithValue("@AvaliacaoId", item.AvaliacaoId);
                command.ExecuteNonQuery();
                return item;
            }
        }
	}
}