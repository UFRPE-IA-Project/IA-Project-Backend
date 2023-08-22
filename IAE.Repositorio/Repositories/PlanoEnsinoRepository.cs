using IAE.Entities.Entities;
using IAE.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using Dapper;

namespace IAE.Repository.Repositories
{
	public class PlanoEnsinoRepository : BaseRepository<PlanoEnsino>, IPlanoEnsinoRepository
	{
		public PlanoEnsinoRepository(IConfiguration config) : base(config)
		{
		}

		public override PlanoEnsino Insert(PlanoEnsino planoEnsino)
		{
			using (IDbConnection connection = new SQLiteConnection(_connectionString))
			{
				connection.Open();
				using (var transaction = connection.BeginTransaction())
				{
					try
					{
						string insertQuery = "INSERT INTO PlanoEnsino (Nome, NomeDisciplina, Escolaridade, CargaHoraria) " +
								 "VALUES (@Nome, @NomeDisciplina, @Escolaridade, @CargaHoraria); " +
								 "SELECT last_insert_rowid();";

						var idPlanoEnsino = connection.ExecuteScalar<int>(insertQuery, planoEnsino, transaction);

						transaction.Commit();

						var novoPlanoEnsino = FindById(idPlanoEnsino);

						return novoPlanoEnsino;
					}
					catch (Exception ex)
					{
						transaction.Rollback();
						throw new ArgumentException($"Houve algum problema ao inserir os dados do Plano de Ensino. Erro: {ex.Message}");
					}

				}
			}
		}

		public int Insert(IList<PlanoEnsino> items)
		{
			int linhasAfetadas = 0;
			using (IDbConnection connection = new SQLiteConnection(_connectionString))
			{
				connection.Open();
				using (var transaction = connection.BeginTransaction())
				{
					try
					{
						string insertQuery = "INSERT INTO PlanoEnsino (Nome, NomeDisciplina, Escolaridade, CargaHoraria) " +
								 "VALUES (@Nome, @NomeDisciplina, @Escolaridade, @CargaHoraria)";

						linhasAfetadas = connection.Execute(insertQuery, items);
						transaction.Commit();
					}
					catch (Exception ex)
					{
						transaction.Rollback();
						throw new ArgumentException($"Houve algum problema ao inserir os dados dos Planos de Ensino. Erro: {ex.Message}");
					}

				}

				return linhasAfetadas;
			}
		}

		public override PlanoEnsino Update(PlanoEnsino planoEnsino)
		{
			using (IDbConnection connection = new SQLiteConnection(_connectionString))
			{
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					try
					{
						string insertQuery =
							"UPDATE PlanoEnsino " +
							"SET Nome = @Nome, NomeDisciplina = @NomeDisciplina, Escolaridade = @Escolaridade, CargaHoraria = @CargaHoraria " +
							"WHERE Id = @Id";

						connection.Execute(insertQuery, planoEnsino);

						transaction.Commit();

						var novoPlanoEnsino = FindById(planoEnsino.Id!.Value);

						return novoPlanoEnsino;
					}
					catch (Exception ex)
					{
						transaction.Rollback();
						throw new ArgumentException($"Houve algum problema atualizar os dados do Plano de Ensino. Erro: {ex.Message}");
					}

				}
			}
		}
	}
}
