using Bookmory.Components;
using Bookmory.Data;
using Bookmory.Repositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// libros
builder.Services.AddScoped<IRepositorioLibros, RepositorioLibros>();

//autores 
builder.Services.AddScoped<IRepositorioAutores, RepositorioAutores>();

// Generos
builder.Services.AddScoped<IRepositorioGeneros, RepositorioGeneros>();

// Editoriales
builder.Services.AddScoped<IRepositorioEditoriales, RepositorioEditoriales>();

// Usuarios
builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuarios>();

// dbcontext
builder.Services.AddDbContext<DirectorioDBContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
