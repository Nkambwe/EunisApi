using AutoMapper;
using Eunis.Helpers;
using Microsoft.AspNetCore.HttpOverrides;

namespace Eunis {

    public class Startup {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
            => Configuration = configuration;

        /// <summary>
        /// Servervice configuration
        /// </summary>
        /// <param name="services">Service Interface</param>
        public void ConfigureServices(IServiceCollection services) {
            services.AddRazorPages();

            services.AddControllers()
                .AddXmlSerializerFormatters()
                .AddXmlDataContractSerializerFormatters();

            services.AddEndpointsApiExplorer();
            services.AddEndpointsApiExplorer();

            //..swagger
            services.AddSwaggerGen();

            //..logging
            services.AddScoped<IServiceLogger, ServiceLogger>();
            ServiceLogger logger = new();
            logger.LogToFile("EUNIS SERVICE :: Service started....");

            //..db connection
            //var connectionString = Configuration.GetConnectionString("dbConectionString");

            //..testing
            // var descrString = connectionString;
            //var connString = descrString;

            //..production
            //var descrString = Environment.GetEnvironmentVariable(connectionString);
            //if (descrString == null) {
            //    logger.LogToFile($"LOCAL SERVICE:: URL Environmental variable '{connectionString}' not set", "CRITICAL");
            // }

            //var connString = encrypt.DecryptString(descrString, AppUtil.CredentialKey);

            //services.AddDbContext<EunisDbContext>(o => o.UseSqlServer(connString));
            //logger.LogToFile($"LOCAL Service Database connection string :: {connectionString}", "INFO");
            //logger.LogToFile($"DB CONNECTION: {connString}");
            //logger.LogToFile($"LOCAL SERVICE :: Connection to database established...", "INFO");

            //..register repositories
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //services.AddScoped<IEunisRepository, EunisRepository>();
            //services.AddScoped<IBankRepository, BankRepository>();
            //services.AddScoped<ISettingRepository, SettingRepository>();
            //services.AddScoped<IEunisCredentialRepository, EunisCredentialRepository>();

            //..register services
            //services.AddScoped<IEuniService, EuniService>();
            //services.AddScoped<IBankService, BankService>();
            //services.AddScoped<ISettingService, SettingService>();
            //services.AddScoped<ICredentialService, CredentialService>();

            //..add ABC client
            logger.LogToFile("EUNIS SERVICE :: Registering External Client URL...", "INFO");

            //var extUrl = Configuration.GetValue<string>("AbcUrl");

            //..test
            //var descrExtUrl = extUrl;
            //var extUrlString = descrExtUrl;

            //..production
            //var descrExtUrl = Environment.GetEnvironmentVariable(extUrlString);
            //if (descrExtUrl == null) {
            //    logger.LogToFile($"ABC SERVICE:: Eunis Connection string Environmental variable '{extUrlString}' not set", "CRITICAL");
            //}

            //var extUrlString = encrypt.DecryptString(descrExtUrl, AppUtil.CredentialKey);
            //logger.LogToFile($"EXTERNAL URL STRING: {extUrlString}");
            //services.AddHttpClient("PbuAbcLink", c => {
            //    c.BaseAddress = new Uri(extUrlString);
            //});

            //..add Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc => {
                mc.AddProfile(new MappingProfile());
            });

            logger.LogToFile("EUNIS SERVICE :: Registering mappers...", "INFO");
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            logger.LogToFile("EUNIS SERVICE :: Registering Http Content Accessor...", "INFO");
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            logger.LogToFile("EUNIS SERVICE :: Service Started...");
        }

        /// <summary>
        /// Configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Application Builder</param>
        public void Configure(WebApplication app) {

            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            if (!app.Environment.IsDevelopment()) {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseForwardedHeaders(new ForwardedHeadersOptions {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor |
                ForwardedHeaders.XForwardedProto
            });

            //app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
