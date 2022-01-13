namespace PurchaseNexus.Server.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<TodoList> TodoLists => Set<TodoList>();

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        SeedData(modelBuilder);

        // Navigation properties, likely only set by EF
        modelBuilder.Entity<TodoItem>()
            .HasOne(x => x.TodoList)
            .WithMany(x => x.Items);
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
