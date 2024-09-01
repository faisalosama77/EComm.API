using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.RunTime.Classes
{
    public class SuccessResponse<T> : BaseResponse
    {
        public T Data { get; set; }
    }
}
