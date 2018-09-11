using System;
using System.Collections.Generic;
using System.Text;

namespace CreateTemplate.Core.Results
{
   public class ResponseResult
    {
    public ResponseResult(bool isSuccess, params string[] erroMessage)
    {
      IsSuccess = isSuccess;
      ErroMessage = erroMessage;
    }

    public bool IsSuccess { get; set; }
    public string[] ErroMessage { get; set; }
  }
}
