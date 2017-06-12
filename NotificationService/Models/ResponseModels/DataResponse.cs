using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bootstrap.Service.NotificationService.Models.ResponseModels
{
    public class DataResponse<T> : BaseResponse
    {
        public T Data { get; set; }

        public DataResponse()
        {
        }

        public DataResponse(T data)
        {
            Data = data;
        }

        public DataResponse(int code) : base(code)
        {
        }

        public DataResponse(int code, string message) : base(code, message)
        {
        }
    }
}
