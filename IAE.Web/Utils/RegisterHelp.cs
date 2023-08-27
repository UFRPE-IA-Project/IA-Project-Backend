using IAE.Repository.Interfaces;
using IAE.Repository.Repositories;
using IAE.Services.Interfaces;
using IAE.Services.Services;

namespace IAE.Web.Utils
{
	public static class RegisterHelp
	{
		public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
		{
			builder.Services.AddScoped<IQuestaoService, QuestaoService>();
			builder.Services.AddScoped<IRespostaService, RespostaService>();
            builder.Services.AddScoped<ITurmaService, TurmaService>();
            builder.Services.AddScoped<IAvaliacaoService, AvaliacaoService>();
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();
            builder.Services.AddScoped<IPlanoEnsinoService, PlanoEnsinoService>();
            builder.Services.AddScoped<IOpenAiService, OpenAiService>();

			return builder;
		}

		public static WebApplicationBuilder RegisterRepositories(this WebApplicationBuilder builder)
		{
			builder.Services.AddScoped<IQuestaoRepository, QuestaoRepository>();
			builder.Services.AddScoped<IRespostaRepository, RespostaRepository>();
            builder.Services.AddScoped<ITurmaRepository, TurmaRepository> ();
            builder.Services.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<IPlanoEnsinoRepository, PlanoEnsinoRepository>();
            builder.Services.AddScoped<IOpenAiRepository, OpenAiRepository>();

			return builder;
		}
	}
}
