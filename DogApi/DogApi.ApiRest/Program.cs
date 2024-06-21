using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DogApi.ApiRest.Middleware;
using DogApi.ApiRest.Commands;
using DogApi.ApiRest.Handlers;
using MediatR;
using AutoMapper;
using DogApi.ApiRest.Queries;
using DogApi.ApiRest.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient("DogApi", client =>
{
    client.BaseAddress = new Uri("https://dog.ceo/");
    // Puedes añadir encabezados o configuraciones adicionales aquí
});
//Se adiciona configuración JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });
builder.Services.AddAuthorization();

builder.Services.AddControllers();
//Inyeción de servicios y manejadores
builder.Services.AddScoped<IDogApiClient, DogApiClient>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IRequestHandler<AuthenticateUserQuery, string>, AuthenticateUserQueryHandler>();
builder.Services.AddScoped<IRequestHandler<GetRandomDogImageQuery, string>, GetRandomDogImageQueryHandler>();
builder.Services.AddScoped<IRequestHandler<GetDogBreedImagesQuery, List<string>>, GetDogBreedImagesQueryHandler>();
builder.Services.AddScoped<IRequestHandler<GetBreedListQuery, List<string>>, GetBreedListQueryHandler>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Dog API", Version = "v1" });

    // Configuración de autenticación JWT 
    var securityScheme = new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "JWT Authorization using Bearer."
    };

    c.AddSecurityDefinition("Bearer", securityScheme);

    var securityRequirement = new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        { securityScheme, Array.Empty<string>() }
    };

    c.AddSecurityRequirement(securityRequirement);
});

//MediaTr Registro
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddHttpClient();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dog API V1");
    });
}



app.Run();
