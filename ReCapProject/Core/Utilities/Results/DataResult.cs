using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T>:Result, IDataResult<T>
    {
        // datayı kendisi set eder, success ve message ise base de set edilir
        public DataResult(T data, bool success, string message):base(success, message)
        {
            Data = data;
        }

        // datayı kendisi set eder success base de set edilir, "mesaj bilgisi vermeden" 
        public DataResult(T data, bool success):base(success)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
