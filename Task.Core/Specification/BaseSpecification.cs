using System.Linq.Expressions;

namespace Task.Core.Specification
{
    public class BaseSpecification<T> : ISpecification<T> where T : class
    {
        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Expression<Func<T, bool>>> CriteriaList { get; set; } = new List<Expression<Func<T, bool>>>();
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDescending { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public bool IsPaginationEnabled { get; set; }

        public BaseSpecification()
        {

        }

        public BaseSpecification(Expression<Func<T, bool>> Criteria)
        {
            this.Criteria = Criteria;
        }

        public void AddOrderBy(Expression<Func<T, object>> OrderBy)
        {
            this.OrderBy = OrderBy;
        }

        public void AddOrderByDescending(Expression<Func<T, object>> OrderByDescending)
        {
            this.OrderByDescending = OrderByDescending;
        }

        public void ApplyPagination(int skip, int take)
        {
            IsPaginationEnabled = true;
            Skip = skip;
            Take = take;
        }

        public void AddSorting(int sortOrder, Expression<Func<T, object>> OrderBy)
        {
            if (sortOrder == 1) this.OrderBy = OrderBy;
            else OrderByDescending = OrderBy;
        }

        public void AddSorting(int sortOrder, string sortColumn)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, sortColumn);

            // Create a lambda expression (e.g., x => x.Property)
            var lambda = Expression.Lambda<Func<T, object>>(
                Expression.Convert(property, typeof(object)), parameter);

            if (sortOrder == 1)
                OrderBy = lambda;
            else
                OrderByDescending = lambda;
        }
    }
}
