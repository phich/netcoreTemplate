using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreateTemplate.Core.Results.Gird
{
  public class GridResponse<T>
  {
    public GridResponse(IEnumerable<T> data, int total)
    {
      this.data = data;
      Total = total;
    }

    public GridResponse(IQueryable<T> data, int total)
    {
      this.data = data;
      Total = total;
    }

    public IEnumerable<T> data { get; set; }
    public int Total { get; set; }
  }
}
