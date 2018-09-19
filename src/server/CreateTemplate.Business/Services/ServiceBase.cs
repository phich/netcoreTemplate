using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using CreateTemplate.Core.Results;
using CreateTemplate.Core.Results.Gird;
using CreateTemplate.Data.UnitOfWork;

namespace CreateTemplate.Business.Services
{
   public class ServiceBase
    {
      public IUnitOfWork _unitOfWork;

      public ServiceBase(IUnitOfWork unitOfWork)
      {
        _unitOfWork = unitOfWork;
      }

    protected IQueryable<T> OrderAndPaging<T>( IQueryable<T> records, GridModel girdModel)
      {
        if (string.IsNullOrEmpty(girdModel.SortField))
          return records;

        var method = girdModel.SortOrder == SortOrder.Asc ? "OrderBy" : "OrderByDescending";
        var parameter = Expression.Parameter(records.ElementType, "p");
        var memberAccess = Expression.Property(parameter, girdModel.SortField);
        var orderByLamba = Expression.Lambda(memberAccess, parameter);
        var result = Expression.Call(typeof(Queryable), method, new[] { records.ElementType, memberAccess.Type },
          records.Expression, Expression.Quote(orderByLamba));
        records = records.Provider.CreateQuery<T>(result);
        records = records.Skip((girdModel.PageIndex - 1) * girdModel.PageSize).Take(girdModel.PageSize);
        return records;
      }
  }
}
