using WebApplication1.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddSingleton<IPeopleService, PeopleService2>();
builder.Services.AddKeyedSingleton<IPeopleService, PeopleService>("PeopleService");
builder.Services.AddKeyedSingleton<IPeopleService, PeopleService2>("PeopleService2");

builder.Services.AddKeyedSingleton<IRandomService, RandomService>("RandomServiceSingleton");
builder.Services.AddKeyedScoped<IRandomService, RandomService>("RandomServiceScoped");
builder.Services.AddKeyedTransient<IRandomService, RandomService>("RandomServiceTransient");

builder.Services.AddScoped<IPostsService, PostsService>();
builder.Services.AddHttpClient<IPostsService, PostsService>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["BaseUrlPosts"]);
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
