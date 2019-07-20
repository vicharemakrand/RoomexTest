using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomexTest.ViewModel
{
    public class ResponseResult
    {
        public ResponseResult()
        {
            IsSucceed = true;
            Message = "Succeed";
        }
        public string Message { get; set; }
        public double Result { get; set; }

        public bool IsSucceed { get; set; }
    }
}
