using IAE.Entities.DTO;
using IAE.Entities.Entities;
using IAE.Entities.Enumarations;
using IAE.Repository.Interfaces;
using IAE.Services.Interfaces;
using IAE.Services.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.UnitTests
{
    public class AvaliacaoTest
    {
        private static void InstanciarRepositorioEService(out Mock<IAvaliacaoRepository> repository, out AvaliacaoService service)
        {
            repository = new Mock<IAvaliacaoRepository>();
            var turmaService = new Mock<ITurmaService>();
            var questaoService = new Mock<IQuestaoService>();
            service = new AvaliacaoService(repository.Object, turmaService.Object, questaoService.Object);
        }
        [Fact]
        public void AtualizarAvaliacao_CorrectInput_DeveRetornarAvaliacaoAtualizada()
        {
            Mock<IAvaliacaoRepository> repository;
            AvaliacaoService service;
            InstanciarRepositorioEService(out repository, out service);

            int avaliacaoId = 1;
            var avaliacaoToUpdate = new AvaliacaoDTO
            {
                TipoAvaliacao = TipoAvaliacao.Simulado,
                IdTurma = 2,
                IdProfessor = 3,
                IdsQuestoes = new List<int> { 4, 5, 6 }
            };

            var avaliacaoDb = new Avaliacao
            {
                Id = avaliacaoId,
                TipoAvaliacao = TipoAvaliacao.Prova,
                IdTurma = 7,
                IdProfessor = 8,
                IdsQuestoes = new List<int> { 9, 10 }
            };

            repository.Setup(repo => repo.FindById(avaliacaoId))
                          .Returns(avaliacaoDb);

            repository.Setup(repo => repo.Update(It.IsAny<Avaliacao>()))
                          .Returns(avaliacaoDb);

            // Act
            var updatedAvaliacao = service.AtualizarAvaliacao(avaliacaoId, avaliacaoToUpdate);

            // Assert
            Assert.Equal(avaliacaoToUpdate.TipoAvaliacao, updatedAvaliacao.TipoAvaliacao);
            Assert.Equal(avaliacaoToUpdate.IdTurma, updatedAvaliacao.IdTurma);
            Assert.Equal(avaliacaoToUpdate.IdProfessor, updatedAvaliacao.IdProfessor);
            Assert.Equal(avaliacaoToUpdate.IdsQuestoes, updatedAvaliacao.IdsQuestoes);
        }

        [Fact]
        public void AtualizarAvaliacao_AvaliacaoNaoExiste_DeveLancarExcecao()
        {
            Mock<IAvaliacaoRepository> repository;
            AvaliacaoService service;
            InstanciarRepositorioEService(out repository, out service);

            int avaliacaoId = 1;
            var avaliacaoToUpdate = new AvaliacaoDTO
            {
                TipoAvaliacao = TipoAvaliacao.Simulado,
                IdTurma = 2,
                IdProfessor = 3,
                IdsQuestoes = new List<int> { 4, 5, 6 }
            };

            repository.Setup(repo => repo.FindById(avaliacaoId))
                          .Returns((Avaliacao)null);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => service.AtualizarAvaliacao(avaliacaoId, avaliacaoToUpdate));
        }

        [Fact]
        public void GerarAvaliacao_ValidInput_ShouldReturnGeneratedAvaliacao()
        {
            var mockTurmaService = new Mock<ITurmaService>();
            var mockQuestaoService = new Mock<IQuestaoService>();
            var mockAvaliacaoRepository = new Mock<IAvaliacaoRepository>();

            var service = new AvaliacaoService(mockAvaliacaoRepository.Object, mockTurmaService.Object, mockQuestaoService.Object);

            int turmaId = 1;
            int numeroQuestoes = 3;
            TipoAvaliacao tipoAvaliacao = TipoAvaliacao.Simulado;

            var turma = new Turma { Id = turmaId, IdPlanoEnsino = 2, Alunos = new List<Usuario>(), IdProfessor = 3 };
            var questoes = new List<Questao> { new Questao { Id = 4 }, new Questao { Id = 5 }, new Questao { Id = 6 } };

            mockTurmaService.Setup(service => service.BuscarTurmaPorId(turmaId))
                            .Returns(turma);

            mockQuestaoService.Setup(service => service.ObterQuestaoPorPlanoEnsino(turma.IdPlanoEnsino))
                             .Returns(questoes);

            mockAvaliacaoRepository.Setup(repo => repo.Insert(It.IsAny<Avaliacao>()))
                                  .Callback<Avaliacao>(avaliacao => avaliacao.Id = 7);

            var generatedAvaliacao = service.GerarAvaliacao(turmaId, numeroQuestoes, tipoAvaliacao);

            Assert.Equal(tipoAvaliacao, generatedAvaliacao.TipoAvaliacao);
            Assert.Equal(turma.Alunos, generatedAvaliacao.AlunosParticipantes);
            Assert.Equal(turma.IdProfessor, generatedAvaliacao.IdProfessor);
            Assert.Equal(questoes.ConvertAll(q => q.Id!.Value), generatedAvaliacao.IdsQuestoes);
            Assert.Equal(7, generatedAvaliacao.Id);
        }
    }
}
