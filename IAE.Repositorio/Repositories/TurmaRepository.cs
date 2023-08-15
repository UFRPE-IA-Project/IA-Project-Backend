using IAE.Entidades.Entities;
using IAE.Repositorio.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SQLite;

namespace IAE.Repositorio.Repositories
{
    public class TurmaRepository : BaseRepository<Turma>, ITurmaRepository
    {
		public TurmaRepository(IConfiguration config) : base(config)
		{
		}

		public List<Turma> BuscarTurmasPorUsuario(Usuario usuario)
        {
            var turmas = new List<Turma>();
            using var conexao = new SQLiteConnection(_config.GetConnectionString("IAEDataBase"));
            conexao.Open();
            using var comando = new SQLiteCommand(conexao);
            comando.CommandText = "SELECT * FROM Turma WHERE ProfessorId = @ProfessorId;";
            comando.Parameters.AddWithValue("@ProfessorId", usuario.Id);
            using var leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                turmas.Add(new Turma { Id = leitor.GetInt32(0), CodigoTurma = leitor.GetString(1), ProfessorId = leitor.GetInt32(2), PlanoEnsinoId = leitor.GetInt32(3) });
            }
            return turmas;
        }

        public override Turma Insert(Turma item)
        {
            using var conexao = new SQLiteConnection(_config.GetConnectionString("IAEDataBase"));
            conexao.Open();
            using var comando = new SQLiteCommand(conexao);
            comando.CommandText = "INSERT INTO Turma (CodigoTurma, ProfessorId, PlanoEnsinoId) VALUES (@CodigoTurma, @ProfessorId, @PlanoEnsinoId);";
            comando.Parameters.AddWithValue("@CodigoTurma", item.CodigoTurma);
            comando.Parameters.AddWithValue("@ProfessorId", item.ProfessorId);
            comando.Parameters.AddWithValue("@PlanoEnsinoId", item.PlanoEnsinoId);
            comando.ExecuteNonQuery();
            return item;
        }
        
        public override int Insert(IList<Turma> items)
        {
            using var conexao = new SQLiteConnection(_config.GetConnectionString("IAEDataBase"));
            conexao.Open();
            using var transacao = conexao.BeginTransaction();
            using var comando = new SQLiteCommand(conexao);
            comando.CommandText = "INSERT INTO Turma (CodigoTurma, ProfessorId, PlanoEnsinoId) VALUES (@CodigoTurma, @ProfessorId, @PlanoEnsinoId);";
            foreach (var item in items)
            {
                comando.Parameters.AddWithValue("@CodigoTurma", item.CodigoTurma);
                comando.Parameters.AddWithValue("@ProfessorId", item.ProfessorId);
                comando.Parameters.AddWithValue("@PlanoEnsinoId", item.PlanoEnsinoId);
                comando.ExecuteNonQuery();
            }
            transacao.Commit();
            return items.Count;
        }
        
        public override Turma Update(Turma item)
        {
            using var conexao = new SQLiteConnection(_config.GetConnectionString("IAEDataBase"));
            conexao.Open();
            using var comando = new SQLiteCommand(conexao);
            comando.CommandText = "UPDATE Turma SET CodigoTurma = @CodigoTurma, ProfessorId = @ProfessorId, PlanoEnsinoId = @PlanoEnsinoId WHERE Id = @Id;";
            comando.Parameters.AddWithValue("@Id", item.Id);
            comando.Parameters.AddWithValue("@CodigoTurma", item.CodigoTurma);
            comando.Parameters.AddWithValue("@ProfessorId", item.ProfessorId);
            comando.Parameters.AddWithValue("@PlanoEnsinoId", item.PlanoEnsinoId);
            comando.ExecuteNonQuery();
            return item;
        }

        public override Turma Insert(Turma turma)
		{
            using var conexao = new SQLiteConnection(_config.GetConnectionString("IAEDataBase"));
            conexao.Open();
            using var comando = new SQLiteCommand(conexao);
            comando.CommandText = "INSERT INTO Turma (CodigoTurma, ProfessorId, PlanoEnsinoId) VALUES (@CodigoTurma, @ProfessorId, @PlanoEnsinoId);";
            comando.Parameters.AddWithValue("@CodigoTurma", turma.CodigoTurma);
            comando.Parameters.AddWithValue("@ProfessorId", turma.ProfessorId);
            comando.Parameters.AddWithValue("@PlanoEnsinoId", turma.PlanoEnsinoId);
            comando.ExecuteNonQuery();
            return turma;
        }

        public override void Update(Turma turma)
        {
            using var conexao = new SQLiteConnection(_config.GetConnectionString("IAEDataBase"));
            conexao.Open();
            using var comando = new SQLiteCommand(conexao);
            comando.CommandText = "UPDATE Turma SET CodigoTurma = @CodigoTurma, ProfessorId = @ProfessorId, PlanoEnsinoId = @PlanoEnsinoId WHERE Id = @Id;";
            comando.Parameters.AddWithValue("@Id", turma.Id);
            comando.Parameters.AddWithValue("@CodigoTurma", turma.CodigoTurma);
            comando.Parameters.AddWithValue("@ProfessorId", turma.ProfessorId);
            comando.Parameters.AddWithValue("@PlanoEnsinoId", turma.PlanoEnsinoId);
            comando.ExecuteNonQuery();
        }

        public override Turma GetById(int id)
        {
            using var conexao = new SQLiteConnection(_config.GetConnectionString("IAEDataBase"));
            conexao.Open();
            using var comando = new SQLiteCommand(conexao);
            comando.CommandText = "SELECT * FROM Turma WHERE Id = @Id;";
            comando.Parameters.AddWithValue("@Id", id);
            using var leitor = comando.ExecuteReader();
            if (leitor.Read())
            {
                return new Turma { Id = leitor.GetInt32(0), CodigoTurma = leitor.GetString(1), ProfessorId = leitor.GetInt32(2), PlanoEnsinoId = leitor.GetInt32(3) };
            }
            return null; // Retorna nulo se a turma não foi encontrada
        }

        public override void Delete(int id)
        {
            using var conexao = new SQLiteConnection(_config.GetConnectionString("IAEDataBase"));
            conexao.Open();
            using var comando = new SQLiteCommand(conexao);
            comando.CommandText = "DELETE FROM Turma WHERE Id = @Id;";
            comando.Parameters.AddWithValue("@Id", id);
            comando.ExecuteNonQuery();
        }
    }
}