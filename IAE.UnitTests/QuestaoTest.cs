using IAE.Entities.Entities;
using IAE.Repository.Interfaces;
using IAE.Services.Interfaces;
using IAE.Services.Services;
using Moq;

namespace IAE.UnitTests
{
    public class QuestaoTest
    {
        private Questao _questao = new Questao()
        {
            Enunciado = "ENUNCIADO: Your question goes here\n" +
                           "RESPOSTA 1: Answer 1\n" +
                           "RESPOSTA 2: Answer 2\n" +
                           "RESPOSTA 3: Answer 3\n" +
                           "RESPOSTA 4: Answer 4"
        };

        [Fact]
        public void AdicionarQuestao_CorrectInput_DevePopularPropriedades()
        {
            Mock<IQuestaoRepository> repository;
            QuestaoService service;
            InstanciarRepositorioEService(out repository, out service);

            var questao = new Questao() { Enunciado = _questao.Enunciado };
            var questaoEsperada = new Questao()
            {
                Enunciado = "Your question goes here",
                Alt1 = "Answer 1",
                Alt2 = "Answer 2",
                Alt3 = "Answer 3",
                Alt4 = "Answer 4"
            };

            repository.Setup(repo => repo.Insert(It.IsAny<Questao>()))
                          .Returns(questaoEsperada);

            var questaoRetornada = service.AdicionarQuestao(questao);

            Assert.Equal("Your question goes here", questao.Enunciado);
            Assert.Equal("Answer 1", questao.Alt1);
            Assert.Equal("Answer 2", questao.Alt2);
            Assert.Equal("Answer 3", questao.Alt3);
            Assert.Equal("Answer 4", questao.Alt4);
        }




        [Fact]
        public void AdicionarQuestao_IncorrectInput_DeveLancarExcecao()
        {
            Mock<IQuestaoRepository> repository;
            QuestaoService service;
            InstanciarRepositorioEService(out repository, out service);

            var questao = new Questao()
            {
                Enunciado = ""
            };

            Assert.Throws<ArgumentNullException>(() => service.AdicionarQuestao(questao));
        }

        [Fact]
        public void AtualizarQuestao_CorrectInput_DeveRetornarQuestaoComId()
        {
            var repository = new Mock<IQuestaoRepository>();
            var service = new QuestaoService(repository.Object);

            int questaoId = 1;
            var questaoToUpdate = new Questao { Id = questaoId, Enunciado = "Updated Enunciado" };

            var questaoDb = new Questao { Id = questaoId, Enunciado = "Original Enunciado" };

            repository.Setup(repo => repo.FindById(questaoId))
                          .Returns(questaoDb);

            repository.Setup(repo => repo.Update(It.IsAny<Questao>()))
                          .Returns(questaoToUpdate);

            var updatedQuestao = service.AtualizarQuestao(questaoId, questaoToUpdate);

            Assert.Equal(questaoToUpdate.Id, updatedQuestao.Id);
            Assert.Equal(questaoToUpdate.Enunciado, updatedQuestao.Enunciado);
        }

        [Fact]
        public void AtualizarQuestao_NonexistentQuestaoId_ShouldThrowException()
        {
            var repository = new Mock<IQuestaoRepository>();
            var service = new QuestaoService(repository.Object);

            int questaoId = 1;
            var questaoToUpdate = new Questao { Id = questaoId, Enunciado = "Updated Enunciado" };

            repository.Setup(repo => repo.FindById(questaoId))
                          .Returns((Questao)null);

            Assert.Throws<ArgumentNullException>(() => service.AtualizarQuestao(questaoId, questaoToUpdate));
        }

        [Fact]
        public void ApagarQuestao_QuestaoExistente_DeveDeletarCorretamente()
        {
            var repository = new Mock<IQuestaoRepository>();
            var service = new QuestaoService(repository.Object);

            int questaoId = 1;
            var questaoExistente = new Questao { Id = questaoId, Enunciado = "Existing Enunciado" };

            repository.Setup(repo => repo.FindById(questaoId))
                          .Returns(questaoExistente);

            repository.Setup(repo => repo.Delete(questaoId))
                          .Returns(1);

            service.ApagarQuestao(questaoId);

            repository.Verify(repo => repo.Delete(questaoId), Times.Once);
        }

        [Fact]
        public void ApagarQuestao_NonexistentQuestao_ShouldNotThrowException()
        {
            var mockRepository = new Mock<IQuestaoRepository>();
            var service = new QuestaoService(mockRepository.Object);

            int questaoId = 1;

            mockRepository.Setup(repo => repo.FindById(questaoId))
                          .Returns((Questao)null);

            Assert.Throws<ArgumentNullException>(() => service.ApagarQuestao(questaoId));
        }

        private static void InstanciarRepositorioEService(out Mock<IQuestaoRepository> repository, out QuestaoService service)
        {
            repository = new Mock<IQuestaoRepository>();
            service = new QuestaoService(repository.Object);
        }
    }
}