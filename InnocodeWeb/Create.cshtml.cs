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

namespace InnocodeWeb
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

        public IActionResult OnGet()
        {
            ViewData["TeamId"] = new SelectList(_teamService.GetAllTeams(), "TeamId", "TeamName");
            return Page();
        }

        [BindProperty]
        public Project Project { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["TeamId"] = new SelectList(_teamService.GetAllTeams(), "TeamId", "TeamName");
                return Page();
            }

            _projectService.SaveProject(Project);
            return RedirectToPage("./Index");
        }
    }
}
