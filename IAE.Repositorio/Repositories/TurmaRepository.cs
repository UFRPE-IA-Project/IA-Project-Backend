using IAE.Entities.Entities;
using IAE.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data.SQLite;
using System.Data;
using Dapper;
using System.Transactions;
using System;

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
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query = "INSERT INTO Turma (CodigoTurma, IdProfessor, IdPlanoEnsino) VALUES (@CodigoTurma, @IdProfessor, @IdPlanoEnsino); " +
                                        "SELECT last_insert_rowid();";

                        var id = connection.ExecuteScalar<int>(query, item, transaction);

                        transaction.Commit();

                        var turma = FindById(id);

                        return turma;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new ArgumentException($"Houve algum problema ao inserir a turma. Erro: {ex.Message}");
                    }
                }
            }
        }

		public int Insert(IList<Turma> items)
		{
            using (IDbConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Turma (CodigoTurma, IdProfessor, IdPlanoEnsino) VALUES (@CodigoTurma, @IdProfessor, @IdPlanoEnsino);";
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
