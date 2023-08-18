using IAE.Entities.Entities;
using IAE.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data.SQLite;
using System.Data;
using Dapper;

namespace IAE.Repository.Repositories
{
    public class TurmaRepository : BaseRepository<Turma>, ITurmaRepository
    {
		public TurmaRepository(IConfiguration config) : base(config)
		{
		}

		public List<Turma> BuscarTurmasPorUsuario(Usuario usuario)
        {
            using (IDbConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Turma WHERE IdProfessor = @IdProfessor;";
                return connection.Query<Turma>(query, new { IdProfessor = usuario.Id }).AsList();
            }
        }

		public override Turma Insert(Turma item)
		{
            using (IDbConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Turma (Nome, IdProfessor) VALUES (@Nome, @IdProfessor);";
                connection.Execute(query, item);
                return item;
            }
        }

		public override int Insert(IList<Turma> items)
		{
            using (IDbConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Turma (Nome, IdProfessor) VALUES (@Nome, @IdProfessor);";
                return connection.Execute(query, items);
            }
        }

		public override Turma Update(Turma item)
		{
            using (IDbConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "UPDATE Turma SET Nome = @Nome, IdProfessor = @IdProfessor WHERE Id = @Id;";
                connection.Execute(query, item);
                return item;
            }
        }
	}
}
