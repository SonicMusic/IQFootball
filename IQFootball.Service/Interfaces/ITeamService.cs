using IQFootball.Domain.Entity;
using IQFootball.Domain.Response;
using IQFootball.Domain.ViewModels.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQFootball.Service.Interfaces
{
	public interface ITeamService
	{
		Task<BaseResponse<IEnumerable<Team>>> GetTeams();

		Task<BaseResponse<Team>> GetTeam(int id);

		Task<BaseResponse<TeamViewModel>> CreateTeam(TeamViewModel teamViewModel);

		Task<BaseResponse<bool>> DeleteTeam(int id);

		Task<BaseResponse<Team>> GetTeamByName(string name);

		Task<BaseResponse<Team>> Edit(int id, TeamViewModel model);
	}
}
