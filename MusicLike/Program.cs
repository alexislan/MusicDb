using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MusicLike.Config;
using MusicLike.Models.Users;
using MusicLike.Models.UserType;
using MusicLike.Repositories;
using MusicLike.Services;
using System.Text;
using UsersApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Users API",
        Description = "An ASP.NET Core Web API for managing users",
    });
    options.AddSecurityDefinition("Token", new OpenApiSecurityScheme()
    {
        BearerFormat = "JWT",
        Description = "JWT Authorization header using the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });
    options.OperationFilter<JwtAuthOperationsFilter>();
});


//SERVICES
builder.Services.AddAutoMapper(typeof(Mapping));
builder.Services.AddScoped<IEncoderService, EncoderService>();
builder.Services.AddScoped<AuthService, AuthService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserService, UserService>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IGenderRepository, GenderRepository>();
builder.Services.AddScoped<IUserTypeRepository, UserTRepository>();
builder.Services.AddScoped<ArtistService, ArtistService>();
builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
builder.Services.AddScoped<IReleasesRepository, ReleaseRepository>();
builder.Services.AddScoped<ReleaseRepository, ReleaseRepository>();
builder.Services.AddScoped<ReleaseService, ReleaseService>();
builder.Services.AddScoped<RatingRepository, RatingRepository>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddScoped<IReleaseTypeRepo, ReleaseTypeRepo>();
builder.Services.AddScoped<IGenresRepository, GenresRepository>();
builder.Services.AddScoped<ReviewService, ReviewService>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();





builder.Services.AddDbContext<MusicDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("conn"));
});

// secret key
var secretKey = builder.Configuration.GetSection("jwtSettings").GetSection("secretKey").ToString();

// jwt
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
