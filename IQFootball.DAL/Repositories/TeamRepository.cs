using IQFootball.DAL.Interfaces;
using IQFootball.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQFootball.DAL.Repositories
{
	public class TeamRepository : ITeamRepository
	{
		private readonly ApplicationDbContext _db;

        public TeamRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Team entity)
		{
			await _db.Team.AddAsync(entity);
			await _db.SaveChangesAsync();

			return true;
		}

		public async Task<bool> Delete(Team entity)
		{
			_db.Team.Remove(entity);
			await _db.SaveChangesAsync();

			return true;
		}

		public async Task<Team> Get(int id)
		{
			return await _db.Team.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<Team> GetByName(string name)
		{
			return await _db.Team.FirstOrDefaultAsync(x => x.Name == name);
		}

		public async Task<List<Team>> Select()
		{
			return await _db.Team.ToListAsync();
		}

        public async Task<Team> Update(Team entity)
        {
            _db.Update(entity);
			await _db.SaveChangesAsync();

			return entity;
        }
    }
}
