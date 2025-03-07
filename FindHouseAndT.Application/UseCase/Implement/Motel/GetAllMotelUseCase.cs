﻿using FindHouseAndT.Application.Repositories;
using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.UseCase
{
	public class GetAllMotelUseCase : IGetAllMotelUseCase
	{
		private readonly IMotelRepository _repository;

		public GetAllMotelUseCase(IMotelRepository repository)
		{
			_repository = repository;
		}
		public Task<List<Motel>> ExecuteAsync()
		{
			return _repository.GetAllMotelAsync();
		}
	}
}
