using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

namespace InnocodeWeb.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;

        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;

        public string ErrorMessage { get; set; } = string.Empty;

        public async Task<IActionResult> OnGetAsync()
        {
            var role = HttpContext.Session.GetString("Role");
            if (!string.IsNullOrEmpty(role))
            {
                return RedirectToPage("/Projects/Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = _userService.GetUserByEmail(Email);
            if (user == null || user.Password != Password)
            {
                ViewData["Error"] = "Invalid email or password";
                return Page();
            }

            HttpContext.Session.SetString("UserId", user.Id.ToString());
            HttpContext.Session.SetString("Role", user.Role);


            if (user.Role == "Lecturer")
            {
                return RedirectToPage("/Projects/Index");
            }
            else if (user.Role == "Student")
            {
                return RedirectToPage("/Students/Index"); 
            }
            else
            {
                return RedirectToPage("/AccessDenied");
            }
        }

    }
}
