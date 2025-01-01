using FindHouseAndT.Application.Repositories;
using FindHouseAndT.Infrastructure.Data.AppDbContext;
using FindHouseAndT.Models.Entities;

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

		public void UpdateBookRequestAsync(BookRequest bookRequest)
		{
			_dbContext.Update(bookRequest);
		}
	}
}
