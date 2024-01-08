using IQFootball.DAL;
using IQFootball.DAL.Interfaces;
using IQFootball.Domain.Entity;
using IQFootball.Domain.Enum;
using IQFootball.Domain.Response;
using IQFootball.Domain.ViewModels.Team;
using IQFootball.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQFootball.Service.Implementations
{
	public class TeamService : ITeamService
	{
		private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

		public async Task<BaseResponse<TeamViewModel>> CreateTeam(TeamViewModel teamViewModel)
		{
			var baseResponse = new BaseResponse<TeamViewModel>();
			try
			{
				var team = new Team()
				{
					Id = teamViewModel.Id,
					Name = teamViewModel.Name,
					League = teamViewModel.League,
					Season = teamViewModel.Season,
					Country = teamViewModel.Country,
					Code = teamViewModel.Code,
					Venue = teamViewModel.Venue,
					Search = teamViewModel.Search
				};

				await _teamRepository.Create(team);
				return baseResponse;
			}
			catch (Exception ex)
			{

				return new BaseResponse<TeamViewModel>()
				{
					Description = $"{CreateTeam} : {ex.Message}",
					StatusCode = StatusCode.InternalServerError
				};
			}
		}

		public async Task<BaseResponse<bool>> DeleteTeam (int id)
		{
			var baseResponse = new BaseResponse<bool>();
			try
			{
				var team = await _teamRepository.Get(id);
				if (team == null)
				{
					baseResponse.Description = "Team not found";
					baseResponse.StatusCode = StatusCode.TeamNotFound;
					return baseResponse;
				}

				await _teamRepository.Delete(team);
				return baseResponse;
			}
			catch (Exception ex)
			{

				return new BaseResponse<bool>()
				{
					Description = $"{DeleteTeam} : {ex.Message}",
					StatusCode = StatusCode.InternalServerError
				};
			}
		}

		public async Task<BaseResponse<Team>> GetTeamByName(string name)
		{
			var baseResponse = new BaseResponse<Team>();

			try
			{
				var team = await _teamRepository.GetByName(name);
				if (team == null)
				{
					baseResponse.Description = "Team not found";
					baseResponse.StatusCode = StatusCode.TeamNotFound;
					return baseResponse;
				}

				baseResponse.Data = team;
				return baseResponse;
			}
			catch (Exception ex)
			{
				return new BaseResponse<Team>()
				{
					Description = $"{GetTeamByName} : {ex.Message}",
					StatusCode = StatusCode.InternalServerError
				};
			}
		}

		public async Task<BaseResponse<Team>> GetTeam(int id)
		{ 
			var baseResponse = new BaseResponse<Team>();

			try
			{
				var team = await _teamRepository.Get(id);
				if (team == null)
				{
					baseResponse.Description = "Team not found";
					baseResponse.StatusCode = StatusCode.TeamNotFound; 
					return baseResponse;
				}

				baseResponse.Data = team;
				return baseResponse;
			}
			catch (Exception ex)
			{
				return new BaseResponse<Team>()
				{
					Description = $"{GetTeam} : {ex.Message}",
					StatusCode = StatusCode.InternalServerError
				};
			}
		}

        public async Task<BaseResponse<IEnumerable<Team>>> GetTeams()
		{
			var baseResponse = new BaseResponse<IEnumerable<Team>>();

			try
			{
				var teams = await _teamRepository.Select();
				if (teams.Count == 0)
				{
					baseResponse.Description = "Найдено 0 элементов";
					baseResponse.StatusCode = StatusCode.OK;
					return baseResponse;
				}

				baseResponse.Data = teams;
				baseResponse.StatusCode = StatusCode.OK;
				return baseResponse;
			}
			catch (Exception ex) 
			{
				return new BaseResponse<IEnumerable<Team>>() 
				{ 
					Description = $"{GetTeams} : {ex.Message}",
					StatusCode = StatusCode.InternalServerError
				};
			}
		}

        public async Task<BaseResponse<Team>> Edit(int id, TeamViewModel model)
        {
            var baseResponse = new BaseResponse<Team>();

            try
            {
                var team = await _teamRepository.Get(id);
                if (team == null)
                {
                    baseResponse.Description = "Team not found";
                    baseResponse.StatusCode = StatusCode.TeamNotFound;
                    return baseResponse;
                }

                team.Code = model.Code;
				team.Name = model.Name;
				team.Country = model.Country;
				team.League = model.League;
				team.Search = model.Search;
				team.Season = model.Season;
				team.Venue = model.Venue;

				await _teamRepository.Update(team);

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Team>()
                {
                    Description = $"{Edit} : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
