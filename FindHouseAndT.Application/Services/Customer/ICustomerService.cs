using FindHouseAndT.Application.DTOs;
using FindHouseAndT.Models.Entities;
using FindHouseAndT.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindHouseAndT.Application.Services
{
	public interface ICustomerService
	{
		Task<ResultStatus> Register(Customer customer);
		Task<ProfileCustomerDTO> GetProfileCustomerAsync(Guid customerId);
		Task<Customer?> GetCustomerByIdAsync(Guid id);
		Task<ResultStatus> UpdateCustomer(ProfileCustomerDTO customerDTO);
	}
}
