﻿using FindHouseAndT.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindHouseAndT.Application.UseCase
{
    public interface IGetAllBookRequestUseCase
    {
        Task<List<BookRequest>> ExecuteAsync();
    }
}
