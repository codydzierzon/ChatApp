using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeamChat.Models.Interfaces.Authentication;

namespace TeamChat.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private IUserAuthService authService;

        public LogoutModel(IUserAuthService authService)
        {
            this.authService = authService;
        }

        public async Task<IActionResult> OnGet()
        {
            await authService.SignOut();

            return RedirectToPage("/Index");
        }
    }
}
