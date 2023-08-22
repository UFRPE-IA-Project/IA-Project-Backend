using Dapper;
using IAE.Entities.Entities;
using IAE.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Repository.Repositories
{
	public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
	{
		public UsuarioRepository(IConfiguration config) : base(config)
		{
		}

		public override Usuario Insert(Usuario item)
		{
			using (IDbConnection connection = new SQLiteConnection(_connectionString))
			{
				connection.Open();
				using (var transaction = connection.BeginTransaction())
				{
					try
					{
						var insertQuery = "INSERT INTO Usuario (Nome, Sobrenome, Telefone, TipoUsuario, Email) " +
								 "VALUES (@Nome, @Sobrenome, @Telefone, @TipoUsuario, @Email); " +
								 "SELECT last_insert_rowid();";

						var idUsuario = connection.ExecuteScalar<int>(insertQuery, item, transaction);

						transaction.Commit();

						var novoUsuario = FindById(idUsuario);

						return novoUsuario;
					}
					catch (Exception ex)
					{
						transaction.Rollback();
						throw new ArgumentException($"Houve algum problema ao inserir os dados do usuário. Erro: {ex.Message}");
					}
				}
			}
		}

		public int Insert(IList<Usuario> items)
		{
			int linhasAfetadas = 0;
			using (IDbConnection connection = new SQLiteConnection(_connectionString))
			{
				connection.Open();
				using (var transaction = connection.BeginTransaction())
				{
					try
					{
						string insertQuery = "INSERT INTO Usuario (Nome, Sobrenome, Telefone, TipoUsuario, Email) " +
								 "VALUES (@Nome, @Sobrenome, @Telefone, @TipoUsuario, @Email)";

						linhasAfetadas = connection.Execute(insertQuery, items);
						transaction.Commit();
					}
					catch (Exception ex)
					{
						transaction.Rollback();
						throw new ArgumentException($"Houve algum problema ao inserir os dados dos usuários. Erro: {ex.Message}");
					}

				}

				return linhasAfetadas;
			}
		}

		public override Usuario Update(Usuario usuario)
		{
			using (IDbConnection connection = new SQLiteConnection(_connectionString))
			{
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					try
					{
						string insertQuery =
							"UPDATE Usuario " +
							"SET Nome = @Nome, Sobrenome = @Sobrenome, Telefone = @Telefone, TipoUsuario = @TipoUsuario, Email = @Email " +
							"WHERE Id = @Id";

						connection.Execute(insertQuery, usuario);

						transaction.Commit();

						var usuarioAtualizado = FindById(usuario.Id!.Value);

						return usuarioAtualizado;
					}
					catch (Exception ex)
					{
						transaction.Rollback();
						throw new ArgumentException($"Houve algum problema atualizar os dados do usuário. Erro: {ex.Message}");
					}

				}
			}
		}
	}
}
