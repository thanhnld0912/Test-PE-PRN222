using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessLogic.Models;
using DataAccessLayer;
using Services;

namespace InnocodeWeb.Pages.Projects
{
    public class CreateModel : PageModel
    {
        private readonly IProjectService _projectService;
        private readonly ITeamService _teamService;

        public CreateModel(IProjectService projectService, ITeamService teamService)
        {
            _projectService = projectService;
            _teamService = teamService;
        }

        [BindProperty]
        public Project Project { get; set; } = default!;

        public IActionResult OnGet()
        {
            var userIdStr = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userIdStr))
                return RedirectToPage("/Login");

            var userId = int.Parse(userIdStr);
            var team = _teamService.GetAllTeams()
                                   .FirstOrDefault(t => t.LeaderId == userId);

            if (team == null)
            {
                TempData["Error"] = "Bạn chưa có team. Vui lòng tạo team trước.";
                return RedirectToPage("/Index");
            }

            var existingProjects = _projectService.GetProjectsByTeamId(team.Id);
            if (existingProjects.Any())
            {
                TempData["Error"] = "Team đã có project. Không thể tạo thêm.";
                return RedirectToPage("/Index");
            }

            ViewData["TeamId"] = new SelectList(new[] { team }, "Id", "TeamName");
            return Page();
        }

        public IActionResult OnPost()
        {
            _projectService.SaveProject(Project);
            TempData["Success"] = "Tạo project thành công!";
            return RedirectToPage("./Index");
        }

    }
}
