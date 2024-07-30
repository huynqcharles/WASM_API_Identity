using Shared;

namespace API.Repos
{
    public interface IAuthRepo
    {
        Task<HttpResponseMessage> RegisterAsync(RegisterModel registerModel, string role);
        Task<HttpResponseMessage> LoginAsync(LoginModel loginModel);
    }
}
