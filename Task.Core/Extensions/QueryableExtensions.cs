using AutoMapper.QueryableExtensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Task.Core.Base;
using System.Linq.Expressions;
using Task.Core.Exceptions;

namespace Task.Core.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<TDto> MapProjectTo<T, TDto>(
    this IQueryable<T> query,
    IMapper mapper)
    {
        var mappedQuery = query.ProjectTo<TDto>(mapper.ConfigurationProvider);

        return mappedQuery;
    }

    public static async Task<PagedList<T>> PagedResult<T>(
    this IQueryable<T> query,
    int pageNumber,
    int pageSize,
    SortOrder? sortOrder,
    string? sortField,
    CancellationToken cancellationToken)
    {
        var skip = (pageNumber - 1) * pageSize;

        var pageInfoResult = new PageInfoResult()
        {
            TotalItems = await query.CountAsync(cancellationToken),

            PageSize = pageSize,

            CurrentPage = pageNumber

        };

        if (!string.IsNullOrEmpty(sortField) && sortOrder != null)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, sortField) ?? throw new ValidationException("SortField Not Valid!", 400);


            var lambda = Expression.Lambda<Func<T, object>>(
                Expression.Convert(property, typeof(object)), parameter);

            if (sortOrder == SortOrder.Asc) query = query.OrderBy(lambda);
            else query = query.OrderByDescending(lambda);
        }

        var pagedQuery = query.Skip(skip).Take(pageSize);

        var paginatedList = new PagedList<T>
        {
            PageInfoResult = pageInfoResult,

            Result = await pagedQuery.ToListAsync(cancellationToken)
        };

        return paginatedList;
    }
}