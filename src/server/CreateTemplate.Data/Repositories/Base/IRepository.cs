﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateTemplate.Data.Repositories.Base
{
  public interface IRepository<T> where T : class
  {
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<T> GetById(Guid id);
    IQueryable<T> GetAll();
  }
}