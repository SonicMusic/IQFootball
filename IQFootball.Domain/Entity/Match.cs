using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQFootball.Domain.Entity
{
	public class Match
	{
		public int Id { get; set; }

		public required Team TeamHome { get; set; }

		public required Team TeamAway { get; set; }

		public int GoalHome { get; set; }

		public int GoalAway { get; set; }

		public DateTime DateTimeStart { get; set; }

        public bool IsFinished { get; set; }
    }
}
