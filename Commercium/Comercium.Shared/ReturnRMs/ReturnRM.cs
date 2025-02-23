using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Commercium.Shared.ReturnRMs
{
    public class ReturnRM<T> //herhangi bir şey
    {
        public T Data { get; set; }
        public List<string>? ErrorMessages { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        #region Başarılı
        public static ReturnRM<T> Success(T data, int StatusCode)
        {
            return new ReturnRM<T> { Data = data, StatusCode = StatusCode };
        }

        public static ReturnRM<T> Success(int StatusCode)
        {
            return new ReturnRM<T> { Data = default(T), StatusCode = StatusCode };
        }

        #endregion

        #region Başarısız
        public static ReturnRM<T> Fail(string ErrorMessage, int StatusCode)
        {
            return new ReturnRM<T>
            {
                ErrorMessages = new List<string>(),
                StatusCode = StatusCode
            };
        }

        public static ReturnRM<T> Fail(List<string> ErrorMessages, int StatusCode)
        {
            return new ReturnRM<T>
            {
                ErrorMessages = ErrorMessages,
                StatusCode = StatusCode
            };
        }
        #endregion

    }
}
