using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeamChat.Models.Authentication;
using TeamChat.Models.DTO;
using TeamChat.Models.Interfaces.Authentication;
using TeamChat.Models.Interfaces.Data;

namespace TeamChat.Pages.Account
{
    public class LoginModel : PageModel
    {
        private IUserAuthService authService;
        private IUserService userService;

        public LoginModel(IUserAuthService authService, IUserService userService)
        {
            this.authService = authService;
            this.userService = userService;
        }

        [BindProperty] 
        public Login Login{ get; set; } = new Login();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string? returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return new PageResult();
            }

            User user = userService.ValidateUser(Login);

            if (user == null)
            {
                ModelState.AddModelError("Login.UserName", "The UserName or Password is incorrect.");
                return new PageResult();
            }

            await authService.SignIn(user);

            if (returnUrl != null)
            {
                return new RedirectResult(returnUrl);
            }

            return new RedirectToPageResult("/Index");
        }
    }
}
