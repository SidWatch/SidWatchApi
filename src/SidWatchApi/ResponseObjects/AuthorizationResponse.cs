using Sidwatch.Library.Objects;

namespace SidWatchApi.ResponseObjects
{
    public class AuthorizationResponse : BaseResponse
    {
        public User User { get; set; }
    }
}