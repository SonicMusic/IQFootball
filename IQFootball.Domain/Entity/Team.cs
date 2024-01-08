using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQFootball.Domain.Entity
{
	public class Team
	{
        public int Id { get; set; }

        public required string Name { get; set; }

		/*The id of the league*/
		public int League { get; set; }

		/*The season of the league*/
		[MinLength(4)]
		[MaxLength(4)]
		public int Season { get; set; }

		public string? Country { get; set; }

		[MinLength(3)]
		[MaxLength(3)]
		public string? Code { get; set; }

		/*The id of the venue*/
		public int Venue { get; set; }

		/*The name or the country name of the team*/
		[MinLength(3)]
		public string? Search { get; set; }

		public string? Logo { get; set; }

		[NotMapped]
		public IEnumerable<Match>? Matches { get; set; }
	}
}
