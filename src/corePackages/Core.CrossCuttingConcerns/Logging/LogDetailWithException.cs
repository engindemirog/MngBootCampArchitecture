using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Logging
{
    public class LogDetailWithException:LogDetail
    {
        public string ExceptionMessage { get; set; }
    }
}
