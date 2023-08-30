using IAE.Entities.Entities;
using IAE.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SQLite;
using System.Data;

namespace IAE.Repository.Repositories
{
    public class QuestaoRepository : BaseRepository<Questao>, IQuestaoRepository
    {
        public QuestaoRepository(IConfiguration config) : base(config)
        {
        }

        public override Questao Insert(Questao item)
        {
            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();

                // Insere a questão e seus atributos
                string insertQuery = "INSERT INTO Questao (Enunciado, Alt1, Alt2, Alt3, Alt4, AlternativaCorreta, id_PlanoEnsino) VALUES (@Enunciado, @Alt1, @Alt2, @Alt3, @Alt4, @AlternativaCorreta, @id_PlanoEnsino);";
                connection.Execute(insertQuery, item);

                return item;
            }
        }

        public int Insert(IList<Questao> questoes)
        {
            int linhasAfetadas = 0;
            using (IDbConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string insertQuery = "INSERT INTO Questao (Enunciado, Alt1, Alt2, Alt3, Alt4, AlternativaCorreta, id_PlanoEnsino) " +
                                 "VALUES (@Enunciado, @Alt1, @Alt2, @Alt3, @Alt4, @AlternativaCorreta, @id_PlanoEnsino)";

                        linhasAfetadas = connection.Execute(insertQuery, questoes);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new ArgumentException($"Houve algum problema ao inserir os dados das questões. Erro: {ex.Message}");
                    }

                }

                return linhasAfetadas;
            }
        }

        public override Questao Update(Questao item)
        {
            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();

                // Atualiza a questão e seus atributos
                string updateQuery = "UPDATE Questao SET Enunciado = @Enunciado, Alt1 = @Alt1, Alt2 = @Alt2, Alt3 = @Alt3, Alt4 = @Alt4, AlternativaCorreta = @AlternativaCorreta WHERE Id = @Id;";
                connection.Execute(updateQuery, item);

                return item;
            }
        }

        private IDbConnection CreateConnection()
        {
            return new SQLiteConnection(_connectionString);
        }
    }

}
