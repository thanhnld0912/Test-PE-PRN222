using BusinessLogic.Models;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InnocodeWeb.Pages.Teams
{
    public class CreateModel : PageModel
    {
        private readonly ITeamService _teamService;
        private readonly IUserService _userService;

        public CreateModel(ITeamService teamService, IUserService userService)
        {
            _teamService = teamService;
            _userService = userService;
        }

        [BindProperty]
        public Team Team { get; set; } = default!;

        public IActionResult OnGet()
        {
            var role = HttpContext.Session.GetString("Role");
            var userIdStr = HttpContext.Session.GetString("UserId");

            if (role != "Student" || string.IsNullOrEmpty(userIdStr))
            {
                return RedirectToPage("/Login");
            }

            var userId = int.Parse(userIdStr);
            var existingTeam = _teamService.GetAllTeams()
                                           .FirstOrDefault(t => t.LeaderId == userId);

            if (existingTeam != null)
            {
                TempData["Error"] = "Bạn đã tạo 1 team rồi.";
                return RedirectToPage("/Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userIdStr = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userIdStr)) return RedirectToPage("/Login");

            var userId = int.Parse(userIdStr);
            Team.LeaderId = userId; 
            try
            {
                _teamService.SaveTeam(Team);
                TempData["SuccessMessage"] = "Tạo team thành công.";
                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Tạo team không thành công.";
                return Page();
            }
        }
    }
}
