using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQFootball.Domain.Enum
{
	public enum StatusCode
	{
		TeamNotFound = 0,
		OK = 200,
		InternalServerError = 500
	}
}
