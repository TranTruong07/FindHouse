using FindHouseAndT.Application.Repositories;
using FindHouseAndT.Infrastructure.Data.AppDbContext;
using FindHouseAndT.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FindHouseAndT.Infrastructure.Data.Repositories
{
	public class BookRequestRepository : IBookRequestRepository
	{
		private readonly FindHouseDbContext _dbContext;

		public BookRequestRepository(FindHouseDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public Task CreateBookRequestAsync(BookRequest bookRequest)
		{
			_dbContext.AddAsync(bookRequest);
			return Task.CompletedTask;
		}

        public Task<List<BookRequest>> GetAllBookRequestAsync()
        {
            return _dbContext.BookRequests.Include(x => x.Room).ToListAsync();
        }

		public Task<BookRequest?> GetBookRequestById(int id)
		{
			return _dbContext.BookRequests.Where(x => x.Id == id).Include(x => x.Room).SingleOrDefaultAsync();
		}

		public Task<List<BookRequest>> GetBookRequestsByCustomerIdAsync(Guid customerId)
        {
            return _dbContext.BookRequests.Where(x => x.IdCustomer.Equals(customerId)).Include(x => x.Room).Include(x => x.Customer).ToListAsync();
        }

        public void UpdateBookRequest(BookRequest bookRequest)
		{
			_dbContext.Update(bookRequest);
		}
	}
}
