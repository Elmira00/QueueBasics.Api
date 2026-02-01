using QueueBasics.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetValue<string>("AzureStorage:ConnectionString");
var queueName = builder.Configuration.GetValue<string>("AzureStorage:QueueName");

builder.Services.AddSingleton<IQueueService>
    (sp => new QueueService(connectionString, queueName));
//bu service her kes uchun umumidir(globaldadir) deye ve project boyunca
//bir defe yaransin deye addsingleton edirik.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
