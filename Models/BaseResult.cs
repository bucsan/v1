using System;

namespace v1.Models
{
    public class BaseResult<T>
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public MyLoggedUser Data { get; set; }
    }
}