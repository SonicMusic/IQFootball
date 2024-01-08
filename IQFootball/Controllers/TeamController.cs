using IQFootball.DAL.Interfaces;
using IQFootball.Domain.Entity;
using IQFootball.Service.Interfaces;
using IQFootball.Service.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IQFootball.Domain.ViewModels.Team;

namespace IQFootball.Controllers
{
	public class TeamController : Controller
	{
		private readonly ITeamService _teamService;

		public TeamController(ITeamService teamService)
		{
			_teamService = teamService;
		}

		[HttpGet]
		public async Task<IActionResult> GetTeams()
		{
			var response = await _teamService.GetTeams();

			if (response.StatusCode == Domain.Enum.StatusCode.OK)
			{
				return View(response.Data);
			}

			return RedirectToAction("Error");
		}

		[HttpGet]
		public async Task<IActionResult> GetTeam(int id)
		{
			var response = await _teamService.GetTeam(id);

			if (response.StatusCode == Domain.Enum.StatusCode.OK)
			{
				return View(response.Data);
			}

			return RedirectToAction("Error");
		}

		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Delete(int id)
		{
			var response = await _teamService.DeleteTeam(id);

			if (response.StatusCode == Domain.Enum.StatusCode.OK)
			{
				return RedirectToAction("GetTeams");
			}

			return RedirectToAction("Error");
		}

		[HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Save(int id)
		{
			if (id == 0)
			{
				return View();
			}

            var response = await _teamService.GetTeam(id);

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }

            return RedirectToAction("Error");
        }

		[HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Save(TeamViewModel model)
		{
            if (ModelState.IsValid)
            {
                if(model.Id == 0)
				{
					await _teamService.CreateTeam(model);
				}
				else
				{
					await _teamService.Edit(model.Id, model);
				}
            }

			return RedirectToAction("GetTeams");
        }

    }
}
