using System;
using System.Collections.Generic;
using System.Text;

namespace CreateTemplate.Core.Results.Gird
{
  public class GridModel
  {
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public string SortField { get; set; }
    public SortOrder SortOrder { get; set; }
  }
}
