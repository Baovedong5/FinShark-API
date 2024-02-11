using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinShark.models;

namespace FinShark.Interfaces
{
    public interface IPortfolioRepository
    {
        Task<List<Stock>> GetUserportfolio(AppUser user);

        Task<Portfolio> CreateAsync (Portfolio portfolio);

        Task<Portfolio> DeletePortfolio (AppUser appUser, string symbol);
    }
}