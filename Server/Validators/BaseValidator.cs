using System.Linq.Expressions;
using System.Reflection;
using FluentValidation.Internal;
using FluentValidation.Validators;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace PurchaseNexus.Server.Validators;

public class BaseValidator<T> : AbstractValidator<T>
{
    private readonly ApplicationDbContext _appDbContext;

    protected BaseValidator(ApplicationDbContext appDbContext)
    {
        _appDbContext = appDbContext;

        // TODO: Try to get fluent api values from ApplicationDbContext
        // Reference:
        // https://blog.joaograssi.com/unit-testing-fluent-validation-rules-against-your-ef-core-model/
        // https://github.com/joaopgrassi/fluentvalidation-efcore-ruletesting/blob/main/tests/Shop.API.Tests/TestExtensions.cs
        FieldInfo[] allFields = typeof(T).GetFields();
        List<FieldInfo> stringFields = allFields.Where(x => x.GetType() == typeof(string)).ToList(); // may not include string?

        foreach (FieldInfo strfield in stringFields)
        {
            // if (appDbContext.ModelCreating.IncludesMaxLength)
            RuleFor(x => strfield.GetValue(x) as string).Length(2, 50);
        }
    }

    /// <summary>
    /// Returns all the <see cref="IPropertyValidator"/> of a given field
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TProperty"></typeparam>
    /// <param name="validator"></param>
    /// <param name="expression"></param>
    public static IPropertyValidator[] GetValidatorsForMember<T1, TProperty>(
        IValidator<T1> validator, Expression<Func<T1, TProperty>> expression)
    {
        var descriptor = validator.CreateDescriptor();
        var expressionMemberName = expression.GetMember()?.Name;

        return descriptor.GetValidatorsForMember(expressionMemberName).Select(x => x.Validator).ToArray();
    }

    public static IPropertyValidator[] GetValidatorsForMember<T1>(
        IValidator<T1> validator, string memberName)
    {
        var descriptor = validator.CreateDescriptor();
        return descriptor.GetValidatorsForMember(memberName).Select(x => x.Validator).ToArray();
    }

    /// <summary>
    /// Returns the <see cref="EntityTypeBuilder"/> of the given entity
    /// </summary>
    /// <typeparam name="TEntity">The entity</typeparam>
    /// <typeparam name="TEntityConfiguration">The entitie's configuration</typeparam>
    /// <returns>EntityTypeBuilder<TEntity></returns>
    public static EntityTypeBuilder<TEntity> GetEntityTypeBuilder<TEntity, TEntityConfiguration>(ApplicationDbContext appDbContext)
        where TEntity : class
        where TEntityConfiguration : IEntityTypeConfiguration<TEntity>, new()
    {
        /*var options = new DbContextOptionsBuilder<ShopDbContext>()
                .UseSqlite(new SqliteConnection("DataSource=:memory:"))
                .Options;

        var sut = new ShopDbContext(options);*/
        var conventionSet = ConventionSet.CreateConventionSet(appDbContext);
        var modelBuilder = new ModelBuilder(conventionSet);

        var entityBuilder = modelBuilder.Entity<TEntity>();
        var entityConfig = new TEntityConfiguration();
        entityConfig.Configure(entityBuilder);

        return entityBuilder;
    }
}
