using IAE.Entidades.Entidades;
using IAE.Entities.Entities;
using IAE.Repository.Interfaces;
using IAE.Services.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            using (var conexao = new SQLiteConnection(_config.GetConnectionString("DefaultConnection")))
            {
                conexao.Open();
                using (var transacao = conexao.BeginTransaction())
                {
                    var comando = conexao.CreateCommand();
                    comando.CommandText = @"
                        INSERT INTO Avaliacao (TurmaId, ProfessorId, TipoAvaliacao)
                        VALUES (@TurmaId, @ProfessorId, @TipoAvaliacao);
                        SELECT last_insert_rowid();";
                    comando.Parameters.AddWithValue("@TurmaId", item.TurmaId);
                    comando.Parameters.AddWithValue("@ProfessorId", item.ProfessorId);
                    comando.Parameters.AddWithValue("@TipoAvaliacao", item.TipoAvaliacao);

                    item.Id = (int)(long)comando.ExecuteScalar();
                    transacao.Commit();
                }
            }
            return item;
        }

        public override int Insert(IList<Avaliacao> items)
        {
            int count = 0;
            using (var conexao = new SQLiteConnection(_config.GetConnectionString("DefaultConnection")))
            {
                conexao.Open();
                using (var transacao = conexao.BeginTransaction())
                {
                    foreach (var item in items)
                    {
                        var comando = conexao.CreateCommand();
                        comando.CommandText = @"
                            INSERT INTO Avaliacao (TurmaId, ProfessorId, TipoAvaliacao)
                            VALUES (@TurmaId, @ProfessorId, @TipoAvaliacao);";
                        comando.Parameters.AddWithValue("@TurmaId", item.TurmaId);
                        comando.Parameters.AddWithValue("@ProfessorId", item.ProfessorId);
                        comando.Parameters.AddWithValue("@TipoAvaliacao", item.TipoAvaliacao);

                        comando.ExecuteNonQuery();
                        count++;
                    }
                    transacao.Commit();
                }
            }
            return count;
        }

        public override Avaliacao Update(Avaliacao item)
        {
            using (var conexao = new SQLiteConnection(_config.GetConnectionString("DefaultConnection")))
            {
                conexao.Open();
                var comando = conexao.CreateCommand();
                comando.CommandText = @"
                    UPDATE Avaliacao
                    SET TurmaId = @TurmaId, ProfessorId = @ProfessorId, TipoAvaliacao = @TipoAvaliacao
                    WHERE Id = @Id;";
                comando.Parameters.AddWithValue("@TurmaId", item.TurmaId);
                comando.Parameters.AddWithValue("@ProfessorId", item.ProfessorId);
                comando.Parameters.AddWithValue("@TipoAvaliacao", item.TipoAvaliacao);
                comando.Parameters.AddWithValue("@Id", item.Id);

                comando.ExecuteNonQuery();
            }
            return item;
        }

        public override void Delete(int id)
        {
            using (var conexao = new SQLiteConnection(_config.GetConnectionString("DefaultConnection")))
            {
                conexao.Open();
                var comando = conexao.CreateCommand();
                comando.CommandText = "DELETE FROM Avaliacao WHERE Id = @Id;";
                comando.Parameters.AddWithValue("@Id", id);

                comando.ExecuteNonQuery();
            }
        }

        public override Avaliacao GetById(int id)
        {
            using (var conexao = new SQLiteConnection(_config.GetConnectionString("DefaultConnection")))
            {
                conexao.Open();
                var comando = conexao.CreateCommand();
                comando.CommandText = "SELECT * FROM Avaliacao WHERE Id = @Id;";
                comando.Parameters.AddWithValue("@Id", id);

                using (var reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Avaliacao
                        {
                            Id = reader.GetInt32(0),
                            TurmaId = reader.GetInt32(1),
                            ProfessorId = reader.GetInt32(2),
                            TipoAvaliacao = reader.GetString(3)
                        };
                    }
                }
            }
            return null;
        }

        public override IList<Avaliacao> GetAll()
        {
            var avaliacoes = new List<Avaliacao>();
            using (var conexao = new SQLiteConnection(_config.GetConnectionString("DefaultConnection")))
            {
                conexao.Open();
                var comando = conexao.CreateCommand();
                comando.CommandText = "SELECT * FROM Avaliacao;";

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        avaliacoes.Add(new Avaliacao
                        {
                            Id = reader.GetInt32(0),
                            TurmaId = reader.GetInt32(1),
                            ProfessorId = reader.GetInt32(2),
                            TipoAvaliacao = reader.GetString(3)
                        });
                    }
                }
            }
            return avaliacoes;
        }
    }
}