using System.Linq;
using Core.Entities;
using Core.Specification;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
       public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,
                                                  ISpecification<TEntity> spec)
        {
            var query = inputQuery;
            if(spec.Createria != null)
            {
                query = query.Where(spec.Createria);
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;

        }
    }
}