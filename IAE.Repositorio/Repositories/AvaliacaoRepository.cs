using IAE.Entities.Entities;
using IAE.Services.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Dapper;
using System.Linq;

namespace IAE.Repository.Repositories
{
    public class AvaliacaoRepository : BaseRepository<Avaliacao>, IAvaliacaoRepository
    {
        public AvaliacaoRepository(IConfiguration config) : base(config) { }

        public override Avaliacao Insert(Avaliacao item)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var query = "INSERT INTO Avaliacao (Descricao, Data, Nota) VALUES (@Descricao, @Data, @Nota); SELECT last_insert_rowid();";
                item.Id = connection.ExecuteScalar<int>(query, item);
                return item;
            }
        }

        public override int Insert(IList<Avaliacao> items)
        {
            int count = 0;
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var query = "INSERT INTO Avaliacao (Descricao, Data, Nota) VALUES (@Descricao, @Data, @Nota)";
                foreach (var item in items)
                {
                    count += connection.Execute(query, item);
                }
            }
            return count;
        }

        public override Avaliacao Update(Avaliacao item)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var query = "UPDATE Avaliacao SET Descricao = @Descricao, Data = @Data, Nota = @Nota WHERE Id = @Id";
                connection.Execute(query, item);
                return item;
            }
        }

        public IList<Avaliacao> FindAll()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Avaliacao";
                return connection.Query<Avaliacao>(query).ToList();
            }
        }

        public Avaliacao FindById(int key)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Avaliacao WHERE Id = @Id";
                return connection.QueryFirstOrDefault<Avaliacao>(query, new { Id = key });
            }
        }

        public IList<Avaliacao> FindByIds(IEnumerable<int> keys)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Avaliacao WHERE Id IN @Ids";
                return connection.Query<Avaliacao>(query, new { Ids = keys }).ToList();
            }
        }

        public int Delete(int id)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var query = "DELETE FROM Avaliacao WHERE Id = @Id";
                return connection.Execute(query, new { Id = id });
            }
        }

        public int DeleteItens(IEnumerable<int> ids)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var query = "DELETE FROM Avaliacao WHERE Id IN @Ids";
                return connection.Execute(query, new { Ids = ids });
            }
        }
    }
}