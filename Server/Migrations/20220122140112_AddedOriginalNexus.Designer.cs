// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PurchaseNexus.Server.Data;

#nullable disable

namespace PurchaseNexus.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220122140112_AddedOriginalNexus")]
    partial class AddedOriginalNexus
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BrandStore", b =>
                {
                    b.Property<int>("AvailableBrandsId")
                        .HasColumnType("int");

                    b.Property<int>("AvailableStoresId")
                        .HasColumnType("int");

                    b.HasKey("AvailableBrandsId", "AvailableStoresId");

                    b.HasIndex("AvailableStoresId");

                    b.ToTable("BrandStore");
                });

            modelBuilder.Entity("PurchaseNexus.Shared.DomainModels.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("PurchaseNexus.Shared.DomainModels.GroceryDepartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("ProductsMostlyRefrigerated")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("GroceryDepartments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Produce",
                            ProductsMostlyRefrigerated = true
                        },
                        new
                        {
                            Id = 2,
                            Name = "Dry Goods",
                            ProductsMostlyRefrigerated = false
                        },
                        new
                        {
                            Id = 3,
                            Name = "Beverages",
                            ProductsMostlyRefrigerated = false
                        },
                        new
                        {
                            Id = 4,
                            Name = "Baking",
                            ProductsMostlyRefrigerated = false
                        },
                        new
                        {
                            Id = 5,
                            Name = "Frozen",
                            ProductsMostlyRefrigerated = true
                        },
                        new
                        {
                            Id = 6,
                            Name = "Dairy",
                            ProductsMostlyRefrigerated = true
                        },
                        new
                        {
                            Id = 7,
                            Name = "Bakery",
                            ProductsMostlyRefrigerated = false
                        },
                        new
                        {
                            Id = 8,
                            Name = "Meat",
                            ProductsMostlyRefrigerated = true
                        },
                        new
                        {
                            Id = 9,
                            Name = "Deli",
                            ProductsMostlyRefrigerated = true
                        },
                        new
                        {
                            Id = 10,
                            Name = "Seafood",
                            ProductsMostlyRefrigerated = true
                        },
                        new
                        {
                            Id = 11,
                            Name = "Household",
                            ProductsMostlyRefrigerated = false
                        },
                        new
                        {
                            Id = 12,
                            Name = "Health & Beauty",
                            ProductsMostlyRefrigerated = false
                        },
                        new
                        {
                            Id = 13,
                            Name = "Pet",
                            ProductsMostlyRefrigerated = false
                        },
                        new
                        {
                            Id = 14,
                            Name = "Alcohol",
                            ProductsMostlyRefrigerated = false
                        },
                        new
                        {
                            Id = 15,
                            Name = "Other",
                            ProductsMostlyRefrigerated = false
                        },
                        new
                        {
                            Id = 16,
                            Name = "Unknown",
                            ProductsMostlyRefrigerated = false
                        });
                });

            modelBuilder.Entity("PurchaseNexus.Shared.DomainModels.MeasurementType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("MeasurementTypes");
                });

            modelBuilder.Entity("PurchaseNexus.Shared.DomainModels.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Bardcode")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<int?>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("QuantityToAddWhenDisposed")
                        .HasColumnType("int");

                    b.Property<int?>("StoreId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("StoreId");

                    b.ToTable("Products");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Product");
                });

            modelBuilder.Entity("PurchaseNexus.Shared.DomainModels.ProductPurchaseHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDate")
                        .HasPrecision(0)
                        .HasColumnType("datetime2(0)");

                    b.Property<double>("PurchasePrice")
                        .HasColumnType("float");

                    b.Property<bool?>("PurchasedOnSale")
                        .HasColumnType("bit");

                    b.Property<double?>("RegularPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductPurchaseHistory");
                });

            modelBuilder.Entity("PurchaseNexus.Shared.DomainModels.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CookTimeMinutes")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ServerImagePath")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("SourceName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SourceUrl")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("PurchaseNexus.Shared.DomainModels.RecipeIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MeasurementTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<double>("RequiredMeasurement")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("MeasurementTypeId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeIngredient");
                });

            modelBuilder.Entity("PurchaseNexus.Shared.DomainModels.RecipeStep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<int>("StepOrder")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeStep");
                });

            modelBuilder.Entity("PurchaseNexus.Shared.DomainModels.ShoppingList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ShoppingList");
                });

            modelBuilder.Entity("PurchaseNexus.Shared.DomainModels.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Stores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Costco",
                            Url = "https://www.costco.ca/"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Super Store",
                            Url = "https://www.realcanadiansuperstore.ca/"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Amazon",
                            Url = "https://www.amazon.ca/"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Best Buy",
                            Url = "https://www.bestbuy.ca/en-ca"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Canadian Tire",
                            Url = "https://www.canadiantire.ca/en.html"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Home Depot",
                            Url = "https://www.homedepot.ca/en/home.html"
                        },
                        new
                        {
                            Id = 7,
                            Name = "American Eagle",
                            Url = "https://www.ae.com/ca/en"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Marks",
                            Url = "https://www.sportchek.ca/"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Sport Chek",
                            Url = "https://www.sportchek.ca/"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Shoppers Drug Mart",
                            Url = "https://www1.shoppersdrugmart.ca/en/home"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Petland",
                            Url = "https://www.petland.ca/"
                        },
                        new
                        {
                            Id = 12,
                            Name = "PetSmart",
                            Url = "https://www.petsmart.ca/"
                        });
                });

            modelBuilder.Entity("PurchaseNexus.Shared.Models.TodoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Done")
                        .HasColumnType("bit");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TodoListId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TodoListId");

                    b.ToTable("TodoItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Done = false,
                            Note = "",
                            Priority = 0,
                            State = 0,
                            Title = "Make a todo list",
                            TodoListId = 1
                        },
                        new
                        {
                            Id = 2,
                            Done = false,
                            Note = "",
                            Priority = 0,
                            State = 0,
                            Title = "Check off the first item",
                            TodoListId = 1
                        },
                        new
                        {
                            Id = 3,
                            Done = false,
                            Note = "",
                            Priority = 0,
                            State = 0,
                            Title = "Realise you've already done two things on the list!",
                            TodoListId = 1
                        },
                        new
                        {
                            Id = 4,
                            Done = false,
                            Note = "",
                            Priority = 0,
                            State = 0,
                            Title = "Reward yourself with a nice, long nap",
                            TodoListId = 1
                        });
                });

            modelBuilder.Entity("PurchaseNexus.Shared.Models.TodoList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TodoLists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Todo List"
                        });
                });

            modelBuilder.Entity("PurchaseNexus.Shared.DomainModels.Food", b =>
                {
                    b.HasBaseType("PurchaseNexus.Shared.DomainModels.Product");

                    b.Property<DateTime?>("ExpiryDate")
                        .HasPrecision(0)
                        .HasColumnType("datetime2(0)")
                        .HasColumnName("Food_ExpiryDate");

                    b.Property<int?>("GroceryDepartmentId")
                        .HasColumnType("int")
                        .HasColumnName("Food_GroceryDepartmentId");

                    b.Property<bool?>("IsRefrigerated")
                        .HasColumnType("bit")
                        .HasColumnName("Food_IsRefrigerated");

                    b.Property<double?>("Measurement")
                        .HasColumnType("float")
                        .HasColumnName("Food_Measurement");

                    b.Property<int?>("MeasurementTypeId")
                        .HasColumnType("int")
                        .HasColumnName("Food_MeasurementTypeId");

                    b.HasIndex("GroceryDepartmentId");

                    b.HasIndex("MeasurementTypeId");

                    b.HasDiscriminator().HasValue("Food");
                });

            modelBuilder.Entity("PurchaseNexus.Shared.DomainModels.ShoppingItem", b =>
                {
                    b.HasBaseType("PurchaseNexus.Shared.DomainModels.Product");

                    b.Property<bool>("AllowSubstitutions")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPurchased")
                        .HasColumnType("bit");

                    b.Property<string>("Notes")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ShoppingListId")
                        .HasColumnType("int");

                    b.HasIndex("ShoppingListId");

                    b.HasDiscriminator().HasValue("ShoppingItem");
                });

            modelBuilder.Entity("PurchaseNexus.Shared.DomainModels.GroceryItem", b =>
                {
                    b.HasBaseType("PurchaseNexus.Shared.DomainModels.ShoppingItem");

                    b.Property<DateTime?>("ExpiryDate")
                        .HasPrecision(0)
                        .HasColumnType("datetime2(0)");

                    b.Property<int?>("GroceryDepartmentId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsRefrigerated")
                        .HasColumnType("bit");

                    b.Property<double?>("Measurement")
                        .HasColumnType("float");

                    b.Property<int?>("MeasurementTypeId")
                        .HasColumnType("int");

                    b.HasIndex("GroceryDepartmentId");

                    b.HasIndex("MeasurementTypeId");

                    b.HasDiscriminator().HasValue("GroceryItem");
                });

            modelBuilder.Entity("BrandStore", b =>
                {
                    b.HasOne("PurchaseNexus.Shared.DomainModels.Brand", null)
                        .WithMany()
                        .HasForeignKey("AvailableBrandsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PurchaseNexus.Shared.DomainModels.Store", null)
                        .WithMany()
                        .HasForeignKey("AvailableStoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PurchaseNexus.Shared.DomainModels.Product", b =>
                {
                    b.HasOne("PurchaseNexus.Shared.DomainModels.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId");

                    b.HasOne("PurchaseNexus.Shared.DomainModels.Store", "Store")
                        .WithMany("Products")
                        .HasForeignKey("StoreId");

                    b.Navigation("Brand");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("PurchaseNexus.Shared.DomainModels.ProductPurchaseHistory", b =>
                {
                    b.HasOne("PurchaseNexus.Shared.DomainModels.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PurchaseNexus.Shared.DomainModels.RecipeIngredient", b =>
                {
                    b.HasOne("PurchaseNexus.Shared.DomainModels.MeasurementType", "MeasurementType")
                        .WithMany()
                        .HasForeignKey("MeasurementTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PurchaseNexus.Shared.DomainModels.Recipe", "Recipe")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MeasurementType");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("PurchaseNexus.Shared.DomainModels.RecipeStep", b =>
                {
                    b.HasOne("PurchaseNexus.Shared.DomainModels.Recipe", "Recipe")
                        .WithMany("RecipeSteps")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("PurchaseNexus.Shared.Models.TodoItem", b =>
                {
                    b.HasOne("PurchaseNexus.Shared.Models.TodoList", "TodoList")
                        .WithMany("Items")
                        .HasForeignKey("TodoListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TodoList");
                });

            modelBuilder.Entity("PurchaseNexus.Shared.DomainModels.Food", b =>
                {
                    b.HasOne("PurchaseNexus.Shared.DomainModels.GroceryDepartment", "GroceryDepartment")
                        .WithMany()
                        .HasForeignKey("GroceryDepartmentId");

                    b.HasOne("PurchaseNexus.Shared.DomainModels.MeasurementType", "MeasurementType")
                        .WithMany()
                        .HasForeignKey("MeasurementTypeId");

                    b.Navigation("GroceryDepartment");

                    b.Navigation("MeasurementType");
                });

            modelBuilder.Entity("PurchaseNexus.Shared.DomainModels.ShoppingItem", b =>
                {
                    b.HasOne("PurchaseNexus.Shared.DomainModels.ShoppingList", "ShoppingList")
                        .WithMany("ShoppingItems")
                        .HasForeignKey("ShoppingListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShoppingList");
                });

            modelBuilder.Entity("PurchaseNexus.Shared.DomainModels.GroceryItem", b =>
                {
                    b.HasOne("PurchaseNexus.Shared.DomainModels.GroceryDepartment", "GroceryDepartment")
                        .WithMany()
                        .HasForeignKey("GroceryDepartmentId");

                    b.HasOne("PurchaseNexus.Shared.DomainModels.MeasurementType", "MeasurementType")
                        .WithMany()
                        .HasForeignKey("MeasurementTypeId");

                    b.Navigation("GroceryDepartment");

                    b.Navigation("MeasurementType");
                });

            modelBuilder.Entity("PurchaseNexus.Shared.DomainModels.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("PurchaseNexus.Shared.DomainModels.Recipe", b =>
                {
                    b.Navigation("RecipeIngredients");

                    b.Navigation("RecipeSteps");
                });

            modelBuilder.Entity("PurchaseNexus.Shared.DomainModels.ShoppingList", b =>
                {
                    b.Navigation("ShoppingItems");
                });

            modelBuilder.Entity("PurchaseNexus.Shared.DomainModels.Store", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("PurchaseNexus.Shared.Models.TodoList", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
