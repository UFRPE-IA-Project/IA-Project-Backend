using Dapper;
using IAE.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Repository.Repositories
{
	public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
	{
		protected readonly IConfiguration _config;
		protected readonly string _connectionString;
		protected readonly string _connectionName = "DEV";


		public BaseRepository(IConfiguration config)
		{
			_config = config;
			_connectionString = LoadConnectionString();
		}

		public IList<T> FindAll()
		{
			using (IDbConnection connection = new SQLiteConnection(_connectionString))
			{
				connection.Open();
				return connection.Query<T>("SELECT * FROM " + typeof(T).Name, new DynamicParameters()).ToList();
			}
		}

		public T FindById(int key)
		{
			using (IDbConnection connection = new SQLiteConnection(_connectionString))
			{
				connection.Open();
				return connection.QueryFirstOrDefault<T>("SELECT * FROM " + typeof(T).Name + " WHERE Id = @Id", new { Id = key });
			}
		}

		public IList<T> FindByIds(IEnumerable<int> keys)
		{
			using (IDbConnection connection = new SQLiteConnection(_connectionString))
			{
				connection.Open();
				return connection.Query<T>("SELECT * FROM " + typeof(T).Name + " WHERE Id IN @Ids", new { Ids = keys }).ToList();
			}
		}

		public int Delete(int id)
		{
			using (IDbConnection connection = new SQLiteConnection(_connectionString))
			{
				connection.Open();
				return connection.Execute("DELETE FROM " + typeof(T).Name + " WHERE Id = @Id", new { Id = id });
			}
		}

		public int DeleteItens(IEnumerable<int> ids)
		{
			using (IDbConnection connection = new SQLiteConnection(_connectionString))
			{
				connection.Open();
				return connection.Execute("DELETE FROM " + typeof(T).Name + " WHERE Id IN @Ids", new { Ids = ids });
			}
		}

		public abstract T Insert(T item);
		//EXEMPLO DE COMO IMPLEMENTAR: ver UsuarioService

		public abstract int Insert(IList<T> items);
		//EXEMPLO DE COMO IMPLEMENTAR: ver UsuarioService


		public abstract T Update(T item);
		//EXEMPLO DE COMO IMPLEMENTAR: ver UsuarioService

		protected string LoadConnectionString()
		{
			var connectionString = _config.GetConnectionString(_connectionName);

			if (string.IsNullOrEmpty(connectionString))
			{
				throw new Exception("Não foi possível encontrar a connection string apropriada.");
			}

			return connectionString;
		}
	}
}
