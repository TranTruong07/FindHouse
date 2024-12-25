﻿using FindHouseAndT.Application.Repositories;
using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.UseCase
{
	public class UpdateCustomerUseCase : IUpdateCustomerUseCase
	{
		private readonly ICustomerRepository _repository;

		public UpdateCustomerUseCase(ICustomerRepository repository)
		{
			_repository = repository;
		}

		public async Task<bool> ExecuteAsync(Customer customer)
		{
			await _repository.UpdateCustomerAsync(customer);
			return true;
		}
	}
}
