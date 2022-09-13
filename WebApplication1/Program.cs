using WebApplication1;
using static WebApplication1.CosmosDbStore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddGraphQLServer()
                  .RegisterDbContext<StudentDbContext>()
                .AddQueryType<Query>()
            .AddProjections()
            .AddFiltering();

builder.Services.AddDbContext<StudentDbContext>();
builder.Services.AddSingleton<ICosmosDBStore, CosmosDBStore>();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.MapControllers();

app.Run();
