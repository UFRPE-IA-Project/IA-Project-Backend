using Dapper;
using IAE.Entidades.Entities;
using IAE.Repositorio.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Repositorio.Repositories
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

				string insertQuery = "INSERT INTO Usuario (Nome, Sobrenome, Telefone, TipoUsuario, Email) " +
								 "VALUES (@Nome, @Sobrenome, @Telefone, @TipoUsuario, @Email)";

				connection.Execute(insertQuery, item);
				return item;
			}
		}

		public override int Insert(IList<Usuario> items)
		{
			using (IDbConnection connection = new SQLiteConnection(_connectionString))
			{
				connection.Open();

				string insertQuery = "INSERT INTO Usuario (Nome, Sobrenome, Telefone, TipoUsuario, Email) " +
								 "VALUES (@Nome, @Sobrenome, @Telefone, @TipoUsuario, @Email)";

				var affectedColumns = connection.Execute(insertQuery, items);

				return affectedColumns;
			}
		}

		public override Usuario Update(Usuario item)
		{
			using (IDbConnection connection = new SQLiteConnection(_connectionString))
			{
				connection.Open();
				string insertQuery = 
					"UPDATE Usuario " +
					"SET Nome = @Nome, Sobrenome = @Sobrenome, Telefone = @Telefone, TipoUsuario = @TipoUsuario, Email = @Email " +
					"WHERE Id = @Id";

				connection.Execute(insertQuery, item);

				return item;
			}
		}
	}
}
