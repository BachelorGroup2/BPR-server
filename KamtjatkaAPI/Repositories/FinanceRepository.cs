﻿using KamtjatkaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KamtjatkaAPI.Repositories
{
    public class FinanceRepository : RepositoryBase<Finance>, IFinanceRepository
    {
        private readonly vujeeaxiContext appDbContext;

        public FinanceRepository(vujeeaxiContext appDbContext)
          : base(appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Finance>> GetFinances()
        {
            return await appDbContext.Finances
            .Include(f => f.FinanceCategory).Include(f => f.Customer) // Include the related FinanceCategory entity
            .Select(f => new Finance // Project the result to a new Finance object with required properties
            {
                Id = f.Id,
                Name = f.Name,
                AmountOfMoney = f.AmountOfMoney,
                Description = f.Description,
                FinanceCategory = f.FinanceCategory,
                Customer = f.Customer // New property to hold the Name of FinanceCategory
            })
            .ToListAsync();
        }
    }
}
