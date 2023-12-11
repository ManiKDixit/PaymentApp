using PaymentsApi.Data;
using PaymentsApi.Interfaces;
using PaymentsApi.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDB"));

builder.Services.AddSingleton<MongoDbSettings>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options => options.AddPolicy("AngularClient", policy => { policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader(); })
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AngularClient");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
