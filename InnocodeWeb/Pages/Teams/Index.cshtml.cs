using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.Models;
using DataAccessLayer;
using Services;

namespace InnocodeWeb.Pages.Teams
{
    public class IndexModel : PageModel
    {
        private readonly ITeamService _teamService;

        public IndexModel(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IList<Team> TeamList { get; set; } = new List<Team>();

        public IActionResult OnGet()
        {
            var role = HttpContext.Session.GetString("Role");

            if (role != "Lecturer")
            {
                return RedirectToPage("/Index");
            }

            TeamList = _teamService.GetAllTeams();
            return Page();
        }
    }

}
