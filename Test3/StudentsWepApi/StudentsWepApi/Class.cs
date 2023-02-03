//using Serilog;
//using System.Reflection;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Tokens;
//using System.Text;
//using Sanlam.Chat.Gateway.Client.Contract;
//using Sanlam.Chat.Gateway.Client.Services;
//using Sanlam.Chat.WhatsApp.Api.Contract;
//using Sanlam.Chat.WhatsApp.EntityFramework;
//using Sanlam.Chat.WhatsApp.EntityFramework.Repository.Contract;
//using Sanlam.Chat.WhatsApp.EntityFramework.Repository;
//using Sanlam.Chat.Encryption.Library;
//using Sanlam.Chat.Whatsapp.Api.Enums;
//using Sanlam.Chat.Whatsapp.Api.Contract;
//using Sanlam.Chat.Whatsapp.Api.Services;
//using Sanlam.Chat.Gateway.Client.Config;
//using GatewayClientEnums = Sanlam.Chat.Gateway.Client.Enums;
//using Sanlam.Chat.Whatsapp.Api.RecurringJobs;
//using Sanlam.Chat.Whatsapp.Api.Middleware;
//using Sanlam.Chat.Whatsapp.Api.Dto;
//using Sanlam.Chat.Whatsapp.Api.Helpers;
//using Sanlam.Chat.Message.Redis.Contract;
//using Sanlam.Chat.Message.Redis.Dto;
//using Microsoft.VisualBasic;

//var builder = WebApplication.CreateBuilder(args);
//var configuration = builder.Configuration;


//// Adding Authentication
//var jwtValidationSection = configuration.GetSection("JwtValidation");
//var jwtAudiences = jwtValidationSection["audiences"].Split(',');

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//})

//// Adding Jwt Bearer
//.AddJwtBearer(options =>
//{
//    options.Authority = jwtValidationSection["authority"];
//    options.IncludeErrorDetails = jwtValidationSection.GetValue<bool>("showErrorDetails");
//    options.SaveToken = true;
//    options.RequireHttpsMetadata = false;
//    options.TokenValidationParameters = new TokenValidationParameters()
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidAudiences = jwtAudiences,
//        ValidateIssuerSigningKey = true
//    };
//});

//// Add services to the container.
//builder.Services.AddScoped<IForwardingApiService, ForwardingApiService>();
//builder.Services.AddScoped<IOutboundService, OutboundService>();
//builder.Services.AddScoped<IInboundService, InboundService>();
//builder.Services.AddSingleton<IConfigService, ConfigService>();
//builder.Services.AddSingleton<IMessageTransformService, MessageTransformService>();
//builder.Services.AddSingleton<IOAuthTokenService, OAuthTokenService>();
//builder.Services.AddSingleton<IConfigApiService, ConfigApiService>();
//builder.Services.AddSingleton<IAWSEncryptionService, AWSEncryptionService>();
//builder.Services.AddScoped<IOptoutApiService, OptoutApiService>();
//builder.Services.AddScoped<ISchedulerService, SchedulerService>();

////Repositories
//builder.Services.AddSingleton<IGlobalConfigRepository, GlobalConfigRepository>();
//builder.Services.AddSingleton<IRedisService, RedisCacheService>();
////builder.Services.AddScoped<IInteractionRepository, InteractionRepository>();

////Controllers
//builder.Services.AddControllers();

////Configuration sections
//builder.Services.Configure<GatewayConfig>(configuration.GetSection("GatewayConfig"));

////HttpClients
//builder.Services.AddHttpClient(GatewayClientEnums.Constants.ConfigApiClient);
//builder.Services.AddHttpClient(GatewayClientEnums.Constants.ForwardingApiClient);
//builder.Services.AddHttpClient(GatewayClientEnums.Constants.OptoutApiClient);

////Memory cache
//builder.Services.AddMemoryCache();

//// Hosted Services
//builder.Services.AddHostedService<OutboundCacheJob>();
//builder.Services.AddHostedService<InboundCacheJob>();

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(options =>
//{
//    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
//    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
//});
//builder.Host.UseSerilog((ctx, lc) => lc
//    .WriteTo.Console()
//    .ReadFrom.Configuration(ctx.Configuration));

//using (var encr = new ChatEncryptionLibrary(Constants.EncryptionKey))
//{
//    var connStr = encr.DecryptConnectionString(builder.Configuration.GetConnectionString("WhatsAppContext"));
//    builder.Services.AddDbContext<WhatsAppContext>(options => options.UseSqlServer(connStr));
//}

//var app = builder.Build();


//// Configure the HTTP request pipeline.
////if (app.Environment.IsDevelopment())
////{
//app.UseSwagger();


//app.UseSwaggerUI(options =>
//{
//    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Chat.Whatsapp.Api v1");
//    //options.SwaggerEndpoint("v1/swagger.json", "Chat.Whatsapp.Api V1");
//    options.RoutePrefix = string.Empty;
//});
////}

//app.UseAuthorization();

//app.MapControllers();

//app.UseMiddleware<GlobalExceptionMiddleware>();

//using (var serviceScope = app.Services.CreateScope())
//{
//    var services = serviceScope.ServiceProvider;
//    var redisConfig = configuration.GetSection("Redis").Get<RedisConfig>();
//    redisConfig.Password = EncryptionHelper.Decrypt(redisConfig.Password);
//    var redisService = services.GetRequiredService<IRedisService>();
//    await redisService.Initialize(redisConfig);
//}

//app.Run();