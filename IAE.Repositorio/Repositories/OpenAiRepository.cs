using IAE.Entities.Entities;
using IAE.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Transactions;

namespace IAE.Repository.Repositories
{
	public class OpenAiRepository : BaseRepository<ChaveOpenAI>, IOpenAiRepository
	{
		public OpenAiRepository(IConfiguration config) : base(config)
		{
		}

		public override ChaveOpenAI Insert(ChaveOpenAI chave)
		{
			using (IDbConnection connection = new SQLiteConnection(_connectionString))
			{
				connection.Open();
				using (var transaction = connection.BeginTransaction())
				{
					try
					{
						var insertQuery = "INSERT INTO ChaveOpenAi (Chave, CriadaEm, ModificadaEm) " +
								 "VALUES (@Chave, @CriadaEm, @ModificadaEm); " +
								 "SELECT last_insert_rowid();";

						var idChave = connection.ExecuteScalar<int>(insertQuery, chave, transaction);

						transaction.Commit();

						var novaChave = FindById(idChave);

						return novaChave;
					}
					catch (Exception ex)
					{
						transaction.Rollback();
						throw new ArgumentException($"Houve algum problema ao inserir a chave de acesso. Erro: {ex.Message}");
					}
				}
			}
		}

		public override ChaveOpenAI Update(ChaveOpenAI chave)
		{
			using (IDbConnection connection = new SQLiteConnection(_connectionString))
			{
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					try
					{
						string insertQuery =
							"UPDATE ChaveOpenAi " +
							"SET Chave = @Chave, CriadaEm = @CriadaEm, ModificadaEm = @ModificadaEm " +
							"WHERE Id = @Id";

						connection.Execute(insertQuery, chave);

						transaction.Commit();

						var chaveAtualizada = FindById(chave.Id!.Value);

						return chaveAtualizada;
					}
					catch (Exception ex)
					{
						transaction.Rollback();
						throw new ArgumentException($"Houve algum problema atualizar a chave de acesso. Erro: {ex.Message}");
					}

				}
			}
		}

		public string GetLastChave()
		{
			using (IDbConnection connection = new SQLiteConnection(_connectionString))
			{
				connection.Open();

				try
				{
					var insertQuery = "SELECT MAX(Id) FROM ChaveOpenAi;";

					var idChave = connection.ExecuteScalar<int>(insertQuery);

					var chaveDb = FindById(idChave);

					if (chaveDb is null || string.IsNullOrEmpty(chaveDb.Chave))
					{
						throw new ArgumentException("ChaveDb é nula, ou chave é nula ou vazia.");
					}
					
					return chaveDb.Chave!;
				}
				catch (Exception ex)
				{
					throw new ArgumentException($"Houve algum problema atualizar a chave de acesso. Erro: {ex.Message}");
				}
			}
		}
	}
}
