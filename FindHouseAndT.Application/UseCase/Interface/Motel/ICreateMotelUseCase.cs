using FindHouseAndT.Models.Entities;
using FindHouseAndT.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindHouseAndT.Application.UseCase
{
	public interface ICreateMotelUseCase
	{
		Task ExecuteAsync(Motel motel);
	}
}
