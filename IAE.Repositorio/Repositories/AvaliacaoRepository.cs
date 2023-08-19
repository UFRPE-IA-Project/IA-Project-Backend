using IAE.Entidades.Entidades;
using IAE.Entities.Entities;
using IAE.Repository.Interfaces;
using IAE.Services.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Collections;

namespace IAE.Repository.Repositories
{
    public class AvaliacaoRepository : BaseRepository<Avaliacao>, IAvaliacaoRepository
    {
        public AvaliacaoRepository(IConfiguration config) :
            base(config)
        {
                
        }

		public override Avaliacao Insert(Avaliacao item)
		{
            using (IDbConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Avaliacao (TipoAvaliacao, IdTurma, IdProfessor) VALUES (@TipoAvaliacao, @IdTurma, @IdProfessor);";
                connection.Execute(query, item);
                return item;
            }
        }

		public int Insert(IList<Avaliacao> items)
		{
            using (IDbConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Avaliacao (TipoAvaliacao, IdTurma, IdProfessor) VALUES (@TipoAvaliacao, @IdTurma, @IdProfessor);";
                return connection.Execute(query, items);
            }
        }

		public override Avaliacao Update(Avaliacao item)
		{
            using (IDbConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "UPDATE Avaliacao SET TipoAvaliacao = @TipoAvaliacao, IdTurma = @IdTurma, IdProfessor = @IdProfessor WHERE Id = @Id;";
                connection.Execute(query, item);
                return item;
            }
		}

		public List<Avaliacao> GetAvaliacoesPorIdTurma(int idTurma)
		{
			using (IDbConnection connection = new SQLiteConnection(_connectionString))
			{
				connection.Open();
				var insertQuery = "SELECT * FROM Avaliacao WHERE IdTurma = @IdTurma";
				var avaliacoes = connection.Query<Avaliacao>(insertQuery, new { IdTurma = idTurma }).AsList(); ;

				return avaliacoes;
			}
		}

		public List<Avaliacao> GetAvaliacoesPorIdProfessor(int idProfessor)
		{
			using (IDbConnection connection = new SQLiteConnection(_connectionString))
			{
				connection.Open();
				var insertQuery = "SELECT * FROM Avaliacao WHERE IdProfessor = @IdProfessor";
				var avaliacoes = connection.Query<Avaliacao>(insertQuery, new { IdProfessor = idProfessor }).AsList(); ;

				return avaliacoes;
			}
		}
	}
}
