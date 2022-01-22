using System.Reflection;

namespace PurchaseNexus.Server.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<TodoList> TodoLists => Set<TodoList>();
    public DbSet<TodoItem> TodoItems => Set<TodoItem>();

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Food> Foods => Set<Food>();
    public DbSet<MeasurementType> MeasurementTypes => Set<MeasurementType>();
    public DbSet<GroceryDepartment> GroceryDepartments => Set<GroceryDepartment>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Store> Stores => Set<Store>();

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

        modelBuilder.Entity<MeasurementType>()
            .HasData(typeof(MeasurementTypes)
                .GetEnumerations<MeasurementTypeEnum>()
                .Select(x => new MeasurementType(x.Name) { Id = x.Id })
                .ToArray());

        modelBuilder.Entity<GroceryDepartment>()
            .HasData(
                new GroceryDepartment("Produce", true) { Id = 1 },
                new GroceryDepartment("Dry Goods", false) { Id = 2 },
                new GroceryDepartment("Beverages", false) { Id = 3 },
                new GroceryDepartment("Baking", false) { Id = 4 },
                new GroceryDepartment("Frozen", true) { Id = 5 },
                new GroceryDepartment("Dairy", true) { Id = 6 },
                new GroceryDepartment("Bakery", false) { Id = 7 },
                new GroceryDepartment("Meat", true) { Id = 8 },
                new GroceryDepartment("Deli", true) { Id = 9 },
                new GroceryDepartment("Seafood", true) { Id = 10 },
                new GroceryDepartment("Household", false) { Id = 11 },
                new GroceryDepartment("Health & Beauty", false) { Id = 12 },
                new GroceryDepartment("Pet", false) { Id = 13 },
                new GroceryDepartment("Alcohol", false) { Id = 14 },
                new GroceryDepartment("Other", false) { Id = 15 },
                new GroceryDepartment("Unknown", false) { Id = 16 }
            );

        modelBuilder.Entity<Store>()
            .HasData(
                new Store("Costco", "https://www.costco.ca/") { Id = 1 },
                new Store("Super Store", "https://www.realcanadiansuperstore.ca/") { Id = 2 },
                new Store("Amazon", "https://www.amazon.ca/") { Id = 3 },
                new Store("Best Buy", "https://www.bestbuy.ca/en-ca") { Id = 4 },
                new Store("Canadian Tire", "https://www.canadiantire.ca/en.html") { Id = 5 },
                new Store("Home Depot", "https://www.homedepot.ca/en/home.html") { Id = 6 },
                new Store("American Eagle", "https://www.ae.com/ca/en") { Id = 7 },
                new Store("Marks", "https://www.sportchek.ca/") { Id = 8 },
                new Store("Sport Chek", "https://www.sportchek.ca/") { Id = 9 },
                new Store("Shoppers Drug Mart", "https://www1.shoppersdrugmart.ca/en/home") { Id = 10 },
                new Store("Petland", "https://www.petland.ca/") { Id = 11 },
                new Store("PetSmart", "https://www.petsmart.ca/") { Id = 12 }
            );
    }
}
