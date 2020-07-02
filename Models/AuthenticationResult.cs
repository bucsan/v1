using v1.Models;

namespace v1.Models
{
    public class AuthenticationResult : BaseResult<object>
    {
        public bool Authenticated { get; set; }
        public string Created { get; set; }
        public string Expiration { get; set; }
        public string AccessToken { get; set; }
    }
}