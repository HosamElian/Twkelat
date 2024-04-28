using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twkelat.Persistence.Consts;

namespace Twkelat.Persistence.NotDbModels
{
    public class Result
    {
        public Result()
        {
            Message = ResultMessages.ProcessNotCompleted;
            IsCompleted = false;
            Value = null;
        }
        public bool IsCompleted { get; set; }
        public string Message { get; set; }
        public object? Value { get; set; } 
    }
}
