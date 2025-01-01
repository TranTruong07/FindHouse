using FindHouseAndT.Application.UnitOfWork;
using FindHouseAndT.Application.UseCase;
using FindHouseAndT.Models.Entities;
using FindHouseAndT.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindHouseAndT.Application.Services
{
	public class BookRequestService
	{
		private readonly ICreateBookRequestUseCase createBookRequestUseCase;
		private readonly IUnitOfWork unitOfWork;

		public BookRequestService(ICreateBookRequestUseCase createBookRequestUseCase, IUnitOfWork unitOfWork)
		{
			this.createBookRequestUseCase = createBookRequestUseCase;
			this.unitOfWork = unitOfWork;
		}

		public async Task<ResultStatus> CreateNewBookRequestAsync(BookRequest bookRequest)
		{
			await createBookRequestUseCase.ExecuteAsync(bookRequest);
			var result = await unitOfWork.CommitAsync();
			if(result != 0)
			{
				return ResultStatus.Success;
			}
			return ResultStatus.Failure;
		}
	}
}
