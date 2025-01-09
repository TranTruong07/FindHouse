using FindHouseAndT.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindHouseAndT.Application.Repositories
{
	public interface IBookRequestRepository
	{
		Task CreateBookRequestAsync(BookRequest bookRequest);
		void UpdateBookRequestAsync(BookRequest bookRequest);
		Task<List<BookRequest>> GetBookRequestsByCustomerIdAsync(Guid customerId);
		Task<List<BookRequest>> GetAllBookRequestAsync();
	}
}
