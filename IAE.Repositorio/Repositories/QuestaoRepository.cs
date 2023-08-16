using IAE.Entidades.Entidades;
using IAE.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SQLite;
using System.Data;

namespace IAE.Repository.Repositories
{
    public class QuestaoRepository : BaseRepository<Questao>, IQuestaoRepository
    {
        public QuestaoRepository(IConfiguration config) : base(config)
        {
        }

        public override Questao Insert(Questao item)
        {
            using (IDbConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Questao (Enunciado, AvaliacaoId) VALUES (@Enunciado, @AvaliacaoId);";
                connection.Execute(query, item);
                return item;
            }
        }

        public override int Insert(IList<Questao> items)
        {
            using (IDbConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Questao (Enunciado, AvaliacaoId) VALUES (@Enunciado, @AvaliacaoId);";
                return connection.Execute(query, items);
            }
        }

        public override Questao Update(Questao item)
        {
            using (IDbConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "UPDATE Questao SET Enunciado = @Enunciado, AvaliacaoId = @AvaliacaoId WHERE Id = @Id;";
                connection.Execute(query, item);
                return item;
            }
        }
    }
}
