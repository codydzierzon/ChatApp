using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeamChat.Models.Authentication;
using TeamChat.Models.Interfaces.Data;

namespace TeamChat.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private IUserService userService;

        public RegisterModel(IUserService userService)
        {
            this.userService = userService;
        }

        [BindProperty] public Registration Registration { get; set; } = new Registration();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return new PageResult();
            }

            var user = userService.Register(Registration);

            if (user == null)
            {
                return new PageResult();
            }

            return new RedirectToPageResult("/Account/Login");

        }
    }
}
