using AutoMapper;
using Eunis.Data;
using Eunis.Helpers;
using Eunis.Infrastructure.Repositories;
using Eunis.Infrastructure.Services;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;

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

            //services.AddCors(options => {
            //    options.AddPolicy("AllowSpecificOrigin", builder => {
            //        builder.WithOrigins(new string[] {"10.129.2.16"})
            //               .AllowAnyHeader()
            //               .AllowAnyMethod();
            //    });
            //});

            //..logging
            services.AddScoped<IServiceLogger, ServiceLogger>();
            ServiceLogger logger = new();
            logger.LogToFile("EUNIS SERVICE :: Service started....");

            //..db connection
            var configValue = Configuration.GetConnectionString("dbConectionString");
            var envValue = Utils.IsLive ? 
                Environment.GetEnvironmentVariable(configValue):
                configValue;

            if (!string.IsNullOrWhiteSpace(envValue)) {
                var connectionString = Secure.DecryptString(envValue, Utils.PassKey);
                logger.LogToFile($"DATA CONNECTION :: Eunis Connection string :: {connectionString}", "INFO");
                services.AddDbContext<EunisDbContext>(o => o.UseNpgsql(connectionString));

                logger.LogToFile($"LOCAL SERVICE :: Connection to database established...", "INFO");

                //..register repositories
                services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
                services.AddScoped<ICredentialsRepository, CredentialsRepository>();
                services.AddScoped<ISettingsRepository, SettingsRepository>();
                services.AddScoped<ITransactionRepository, TransactionRepository>();
                services.AddScoped<IClientRepository, ClientRepository>();
                services.AddScoped<IBankAccountRepository, BankAccountRepository>();

                //..register services
                services.AddScoped<ICredentialService, CredentialService>();
                services.AddScoped<ISettingService, SettingService>();
                services.AddScoped<ITransactionService, TransactionService>();
                services.AddScoped<IClientService, ClientService>();
                services.AddScoped<IBankAccountService, BankAccountService>();

                // Mappers
                services.AddAutoMapper(m => m.AddProfile(new MappingProfile()));

                //..add Client service connection
                logger.LogToFile("EUNIS SERVICE :: Registering External Client URL...", "INFO");
                var thirdPartyUrl = Configuration.GetValue<string>("ThirdPartyUrl");
                string envPValue = thirdPartyUrl;
                if (Utils.IsLive) {
                    //Environmental variable set
                    envPValue = Environment.GetEnvironmentVariable(thirdPartyUrl);
                }

                if (!string.IsNullOrWhiteSpace(envValue)) {
                    var connectionUrl = Secure.DecryptString(envPValue, Utils.PassKey);
                    logger.LogToFile($"EXTERNAL SERVICE URL STRING: {connectionUrl}");
                    services.AddHttpClient("ThirdPartyLink", c => {
                        c.BaseAddress = new Uri(connectionUrl);
                    });
                } else {
                    logger.LogToFile($"EXTERNAL SERVICE:: URL Environmental variable '{thirdPartyUrl}' not set", "SYSTEM ERROR");
                }
                
                //..add Auto Mapper Configurations
                var mappingConfig = new MapperConfiguration(mc => {
                    mc.AddProfile(new MappingProfile());
                });

                IMapper mapper = mappingConfig.CreateMapper();
                services.AddSingleton(mapper);
                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
                logger.LogToFile("EUNIS SERVICE :: Service Started...");
            } else {
                logger.LogToFile($"EUNIS SERVICE:: URL Environmental variable '{configValue}' not set. Database connection cannot be established", "CRITICAL");
                logger.LogToFile("Service connection stopped...");
            }
            
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
