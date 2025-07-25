using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Models;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Services;

namespace InnocodeWeb.Pages.Projects
{
    public class IndexModel : PageModel
    {
        private readonly IProjectService _projectService;

        public IndexModel(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public IList<Project> ProjectList { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != "Lecturer")
            {
                return RedirectToPage("/Login");
            }

            ProjectList = _projectService.GetAllProjects();
            return Page();
        }

        public IActionResult OnPostApprove(int id)
        {
            var project = _projectService.GetProjectById(id);
            if (project == null)
            {
                TempData["Error"] = "Project không tồn tại.";
                return RedirectToPage();
            }

            project.IsApproved = true;
            _projectService.UpdateProject(project);

            TempData["Success"] = $"Project '{project.Title}' đã được duyệt.";
            return RedirectToPage();
        }
    }
}
