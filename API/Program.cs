/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/

using System.Reflection;
using System.Text;
using Backend.Examples;
using Swashbuckle.AspNetCore.Filters;
using Backend.Mapping;
using DAL.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MQTT;
using MQTT.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//AutoMapper
builder.Services.AddAutoMapper(typeof(Mapping));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.ExampleFilters();
    var xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "SmartRooms",
        Description = "Gestão das salas do IPCA",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }

    });

    //Para inserir jwt token iniciar a sessão
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description =
                 "JWT Autorização header using the Bearer scheme. " +
                 "Escrever 'Bearer' [espaço] e asseguir inserir o token na caixa Value." +
                 "Exemplo: \"Bearer 12345abcdef\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement() {
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            },
            Scheme = "oauth2",
            Name = "Bearer",
            Type = SecuritySchemeType.Http,
            In = ParameterLocation.Header,
        },
        new List<string>()
        }
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        
        ValidIssuer = builder.Configuration.GetValue<String>("Jwt:Issuer"),
        ValidAudience = builder.Configuration.GetValue<String>("Jwt:Audience"),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<String>("Jwt:Key")))
    };
});

builder.Services.AddSwaggerExamplesFromAssemblyOf<UserExamples>();

//Inicializar escuta Mqtt
Application.Application.Mqtt().StartListening(arduinoDataList =>
{
    foreach (var dataArduino in arduinoDataList)
    {
        //para cada dado enviar para a BD e converter em outros unidades de medidas
        DataDTO data = new DataDTO()
        {
            IdDataType = dataArduino.IdDataType,
            RegistrationDate = DateTime.Now,
            IdHardware = dataArduino.IdHardware,
            Value = dataArduino.Value
        };

        if (Application.Application.GetAlertDao().CheckAlert(Int32.Parse(data.Value), data.IdHardware) != null)
        {
            Application.Application.GetAlertDao().AlertEvent(new AlertDTO
            {
                Id = data.IdHardware,
                ActualValue = Int32.Parse(data.Value),
            });
        }
        Application.Application.GetDataDao().SaveData(data);

        if (Application.Application.GetDataTypeDao().GetDataTypeByShortTypeName("C").Id == data.IdDataType)
        {
            // Converter dados para Fahrenheit
            data.Value = Application.Application.GetDataDao().ConverterTemperature(data.Value, "C", "F");
            data.IdDataType = Application.Application.GetDataTypeDao().GetDataTypeByShortTypeName("F").Id;
            // Converter dados para Kelvin
            Application.Application.GetDataDao().SaveData(data);
            data.Value = Application.Application.GetDataDao().ConverterTemperature(data.Value, "C", "K");
            data.IdDataType = Application.Application.GetDataTypeDao().GetDataTypeByShortTypeName("K").Id;
            Application.Application.GetDataDao().SaveData(data);
        }
        
    }
});


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();