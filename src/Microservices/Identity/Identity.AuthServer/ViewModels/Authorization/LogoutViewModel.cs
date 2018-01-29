using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Identity.AuthServer.ViewModels.Authorization
{
    public class LogoutViewModel
    {
        [BindNever]
        public string RequestId { get; set; }
    }
}
