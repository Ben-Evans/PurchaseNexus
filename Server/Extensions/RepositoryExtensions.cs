namespace PurchaseNexus.Server.Extensions;

public static class RepositoryExtensions
{
    public static IQueryable<TDomainModel> IncludeProperties<TDomainModel>(
        this IQueryable<TDomainModel> queryable,
        params string[] includedPropertyPaths) where TDomainModel : class, IDomainModel
    {
        foreach (var include in includedPropertyPaths)
        {
            queryable = queryable.Include(include);
        }
        return queryable;
    }

    public static IQueryable<TDomainModel> WithTracking<TDomainModel>(
        this IQueryable<TDomainModel> queryable,
        bool? enableTracking) where TDomainModel : class, IDomainModel
    {
        queryable = enableTracking.HasValue && enableTracking.Value ? queryable.AsTracking() : queryable.AsNoTracking();
        return queryable;
    }
}
