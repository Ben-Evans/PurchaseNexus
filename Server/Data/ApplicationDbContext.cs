using System.Reflection;

namespace PurchaseNexus.Server.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<TodoList> TodoLists => Set<TodoList>();

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        configurationBuilder
            .Properties<string>() //.AreUnicode(false)
            .HaveMaxLength(50);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        SeedData(modelBuilder);
    }

    private static void SeedData(ModelBuilder modelBuilder)
    {
        var todoList = new TodoList("Todo List") { Id = 1 };
        modelBuilder.Entity<TodoList>().HasData(todoList);

        modelBuilder.Entity<TodoItem>().HasData(
            new TodoItem("Make a todo list", todoList.Id) { Id = 1 },
            new TodoItem("Check off the first item", todoList.Id) { Id = 2 },
            new TodoItem("Realise you've already done two things on the list!", todoList.Id) { Id = 3 },
            new TodoItem("Reward yourself with a nice, long nap", todoList.Id) { Id = 4 });
    }
}
